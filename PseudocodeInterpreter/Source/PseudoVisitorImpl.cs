﻿using System;
using System.Linq;
using AntlrGenerated;
using PseudocodeInterpreter.Exceptions;
using PseudocodeInterpreter.Objects;

namespace PseudocodeInterpreter
{
	public class PseudoVisitorImpl : PseudoBaseVisitor<object>
	{
		private ScopeStack _scopes = new ScopeStack();

		public override object VisitFile(PseudoParser.FileContext context)
		{
			Visit(context.statList());
			
			return null;
		}

		/// <summary>
		/// Enter a list/ block of statements, and manages the scope creation for it
		/// </summary>
		public override object VisitStatList(PseudoParser.StatListContext context)
		{
			_scopes.Push();

			foreach (var statContext in context.stat())
			{
				Visit(statContext);
			}

			_scopes.Pop();

			return null;
		}

		public override object VisitIfStat(PseudoParser.IfStatContext context)
		{
			// Evaluate the boolean condition
			var condRes = ((Literal) Visit(context.boolOp())).ToBoolean();
			if (condRes)
			{
				Visit(context.statList());
			}
			else
			{
				foreach (var elseIf in context.elseIfStat())
				{
					condRes = ((Literal) Visit(elseIf.boolOp())).ToBoolean();
					if (condRes)
					{
						Visit(elseIf.statList());
						return null;
					}
				}

				if (context.elseStat() != null)
				{
					Visit(context.elseStat().statList());
				}
			}
			
			return null;
		}

		public override object VisitWhileStat(PseudoParser.WhileStatContext context)
		{
			while ((BooleanLiteral) Visit(context.boolOp()))
			{
				Visit(context.statList());
			}

			return null;
		}

		public override object VisitForStat(PseudoParser.ForStatContext context)
		{
			var varName = context.varAssign().ID().GetText();
			var varType = _scopes.GetVar(varName).Type;
			Visit(context.varAssign());

			// Loops through the for as long as the incremented variable meets the condition
			for (
				float i = (NumberLiteral) _scopes.GetVar(varName);
				i < (NumberLiteral) Visit(context.expr());
				++i, _scopes.SetVar(varName, new NumberLiteral(i, varType))
				)
			{
				Visit(context.statList());
			}

			return null;
		}

		public override object VisitReadBuiltin(PseudoParser.ReadBuiltinContext context)
		{
			// Separate input using spaces into multiple values
			var values = Interpreter.Input()?.Split(' ');

			if (values == null)
			{
				throw new Exception(ErrorMessages.NullInput);
			}

			// Check if the number of values read is bigger than the number of values requested
			if (values.Length != context.ID().Length)
			{
				throw new Exception(ErrorMessages.ArgumentsNumber);
			}

			var ids = context.ID().Select(x => x.GetText()).ToArray();
			for (int i = 0; i < ids.Length; i++)
			{
				if (_scopes.DoesVariableExist(ids[i]))
				{
					var variable = _scopes.GetVar(ids[i]);

					// Try to fit the value into the type of the variable that requested the value

					if (variable is NumberLiteral numVar)
					{
						if (numVar.IsInteger)
						{
							if (int.TryParse(values[i], out var intValue))
							{
								_scopes.SetVar(ids[i], new NumberLiteral(intValue));
							}
							else
							{
								throw new Exception(ErrorMessages.IncorrectFormat(values[i], TypeNames.IntegerType));
							}
						}
						else if (float.TryParse(values[i], out var floatValue))
						{
							_scopes.SetVar(ids[i], new NumberLiteral(floatValue));
						}
						else
						{
							throw new Exception(ErrorMessages.IncorrectFormat(values[i], TypeNames.NumberType));
						}
					}
					else if (variable is StringLiteral)
					{
						_scopes.SetVar(ids[i], new StringLiteral(values[i]));
					}
				}
				else
				{
					throw new Exception(ErrorMessages.UndefinedSymbol(ids[i]));
				}
			}

			return null;
		}

		public override object VisitWriteBuiltin(PseudoParser.WriteBuiltinContext context)
		{
			string toWrite = string.Empty;
			context.expr().ForEach(x => toWrite += Visit(x).ToString());

			if (context.WRITELN_BUILTIN() != null)
			{
				Interpreter.Output(toWrite + Environment.NewLine);
			}
			else
			{
				Interpreter.Output(toWrite);
			}

			return null;
		}

		public override object VisitVariableDeclaration(PseudoParser.VariableDeclarationContext context)
		{
			var varType = context.type().GetText();

			// Check for each declaration if it includes initialization or not

			foreach (var optionalAssignContext in context.optionalAssign())
			{
				VisitOptionalAssign(optionalAssignContext, varType);
			}

			return null;
		}

		public object VisitOptionalAssign(PseudoParser.OptionalAssignContext context, string varType)
		{
			var varName = context.ID().GetText();

			var expr = context.expr();
			if (expr != null)
			{
				// Try to fit the initialization value into the variable

				var exprResult = Visit(expr) as Literal;
				if (exprResult is NumberLiteral exprNum)
				{
					if (varType == TypeNames.IntegerType)
					{
						if (exprNum.IsInteger)
						{
							_scopes.CreateVariable(varName, exprNum);
						}
						else
						{
							throw new Exception(ErrorMessages.IncompatibleTypes(varType, exprNum.Type));
						}
					}
					else if (varType == TypeNames.RealType)
					{
						_scopes.CreateVariable(varName, exprNum);
					}
					else
					{
						throw new Exception(ErrorMessages.IncompatibleTypes(varType, TypeNames.IntegerType, TypeNames.RealType));
					}
				}
				else if (exprResult is StringLiteral text)
				{
					if (varType == TypeNames.StringType)
					{
						_scopes.CreateVariable(varName, text);
					}
					else
					{
						throw new Exception(ErrorMessages.IncompatibleTypes(varType, TypeNames.StringType));
					}
				}
			}
			else // if the variable is not initialized, assign a default value for its type
			{
				if (varType == TypeNames.IntegerType)
				{
					_scopes.CreateVariable(varName, new NumberLiteral(0));
				}
				else if (varType == TypeNames.RealType)
				{
					_scopes.CreateVariable(varName, new NumberLiteral(0.0f));
				}
				else if (varType == TypeNames.StringType)
				{
					_scopes.CreateVariable(varName, new StringLiteral(string.Empty));
				}
			}

			return null;
		}

		public override object VisitGetVariable(PseudoParser.GetVariableContext context)
		{
			var varName = context.ID().GetText();

			var varValue = _scopes.GetVar(varName);
			if (varValue != null)
			{
				return varValue;
			}
			else
			{
				throw new Exception(ErrorMessages.UndefinedSymbol(varName));
			}
		}

		public override object VisitVarAssign(PseudoParser.VarAssignContext context)
		{
			var varName = context.ID().GetText();
			if (!_scopes.DoesVariableExist(varName))
			{
				throw new Exception(ErrorMessages.UndefinedSymbol(varName));
			}
			
			// Try to fit the assigned value into the variable

			var exprResult = (Literal) Visit(context.expr());

			if (exprResult is NumberLiteral exprNum)
			{
				if (_scopes.GetVar(varName) is NumberLiteral varNum)
				{
					if (varNum.IsInteger && !exprNum.IsInteger)
					{
						throw new Exception(ErrorMessages.IncompatibleTypes(varNum.Type, exprNum.Type));
					}
					else
					{
						_scopes.SetVar(varName, exprNum);
					}
				}
				else
				{
					throw new Exception(ErrorMessages.IncompatibleTypes(_scopes.GetVar(varName).Type, TypeNames.NumberType));
				}
			}
			else if (exprResult is StringLiteral text)
			{
				if (_scopes.GetVar(varName) is StringLiteral)
				{
					_scopes.SetVar(varName, text);
				}
				else
				{
					throw new Exception(ErrorMessages.IncompatibleTypes(_scopes.GetVar(varName).Type, TypeNames.StringType));
				}
			}


			return null;
		}

		public override object VisitAndOp(PseudoParser.AndOpContext context)
		{
			var leftValue = ((BooleanLiteral) Visit(context.boolOp(0))).ToBoolean();
			var rightValue = ((BooleanLiteral) Visit(context.boolOp(1))).ToBoolean();
			return new BooleanLiteral(leftValue && rightValue);
		}

		public override object VisitOrOp(PseudoParser.OrOpContext context)
		{
			var leftValue = ((BooleanLiteral) Visit(context.boolOp(0))).ToBoolean();
			var rightValue = ((BooleanLiteral) Visit(context.boolOp(1))).ToBoolean();
			return new BooleanLiteral(leftValue || rightValue);
		}

		public override object VisitNegateBoolOp(PseudoParser.NegateBoolOpContext context)
		{
			return !((BooleanLiteral) Visit(context.boolOp()));
		}

		public override object VisitParanBoolOp(PseudoParser.ParanBoolOpContext context)
		{
			return Visit(context.boolOp());
		}

		public override object VisitAreEqual(PseudoParser.AreEqualContext context)
		{
			var leftValue = (NumberLiteral) Visit(context.plusOrMinus(0));
			var rightValue = (NumberLiteral) Visit(context.plusOrMinus(1));
			return context.NOT() != null 
				? new BooleanLiteral(!(Math.Abs(leftValue.Value - rightValue.Value) < float.Epsilon))
				: new BooleanLiteral(Math.Abs(leftValue.Value - rightValue.Value) < float.Epsilon);
		}

		public override object VisitGreaterThan(PseudoParser.GreaterThanContext context)
		{
			var leftValue = (NumberLiteral) Visit(context.plusOrMinus(0));
			var rightValue = (NumberLiteral) Visit(context.plusOrMinus(1));
			return new BooleanLiteral(leftValue.Value > rightValue.Value);
		}

		public override object VisitGreaterOrEqual(PseudoParser.GreaterOrEqualContext context)
		{
			var leftValue = (NumberLiteral) Visit(context.plusOrMinus(0));
			var rightValue = (NumberLiteral) Visit(context.plusOrMinus(1));
			return new BooleanLiteral(leftValue.Value >= rightValue.Value);
		}

		public override object VisitLessThan(PseudoParser.LessThanContext context)
		{
			var leftValue = (NumberLiteral) Visit(context.plusOrMinus(0));
			var rightValue = (NumberLiteral) Visit(context.plusOrMinus(1));
			return new BooleanLiteral(leftValue.Value < rightValue.Value);
		}

		public override object VisitLessOrEqual(PseudoParser.LessOrEqualContext context)
		{
			var leftValue = (NumberLiteral) Visit(context.plusOrMinus(0));
			var rightValue = (NumberLiteral) Visit(context.plusOrMinus(1));
			return new BooleanLiteral(leftValue.Value <= rightValue.Value);
		}

		public override object VisitString(PseudoParser.StringContext context)
		{
			return new StringLiteral(context.STRING().GetText().Trim('"'));
		}

		public override object VisitMult(PseudoParser.MultContext context)
		{
			var left = (NumberLiteral) Visit(context.multOrDiv());
			var right = (NumberLiteral) Visit(context.unarySign());
			return left * right;
		}

		public override object VisitDiv(PseudoParser.DivContext context)
		{
			var left = (NumberLiteral) Visit(context.multOrDiv());
			var right = (NumberLiteral) Visit(context.unarySign());
			return left / right;
		}

		public override object VisitModulo(PseudoParser.ModuloContext context)
		{
			var left = (NumberLiteral) Visit(context.multOrDiv());
			var right = (NumberLiteral) Visit(context.unarySign());
			return left % right;
		}

		public override object VisitAdd(PseudoParser.AddContext context)
		{
			var left = (NumberLiteral) Visit(context.plusOrMinus());
			var right = (NumberLiteral) Visit(context.multOrDiv());
			return left + right;
		}

		public override object VisitSub(PseudoParser.SubContext context)
		{
			var left = (NumberLiteral) Visit(context.plusOrMinus());
			var right = (NumberLiteral) Visit(context.multOrDiv());	
			return left - right;
		}

		public override object VisitUnaryPlus(PseudoParser.UnaryPlusContext context)
		{
			return Visit(context.unarySign());
		}

		public override object VisitUnaryMinus(PseudoParser.UnaryMinusContext context)
		{
			return -(NumberLiteral) Visit(context.unarySign());
		}

		public override object VisitWholePart(PseudoParser.WholePartContext context)
		{
			var number = (NumberLiteral) Visit(context.plusOrMinus());
			return new NumberLiteral((int) Math.Floor(number.Value));
		}

		public override object VisitInteger(PseudoParser.IntegerContext context)
		{
			return new NumberLiteral(int.Parse(context.GetText()));
		}

		public override object VisitFloatingPoint(PseudoParser.FloatingPointContext context)
		{
			return new NumberLiteral(float.Parse(context.GetText()));
		}

		public override object VisitToParenPlusOrMinus(PseudoParser.ToParenPlusOrMinusContext context)
		{
			return Visit(context.plusOrMinus());
		}
	}
}