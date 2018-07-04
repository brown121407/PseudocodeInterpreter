using System;
using System.Collections.Generic;
using System.Linq;
using Antlr4.Runtime;
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

		public override object VisitReadBuiltin(PseudoParser.ReadBuiltinContext context)
		{
			var values = Console.ReadLine()?.Split(" ");

			if (values == null)
			{
				throw new Exception(ErrorMessages.NullInput);
			}

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
				Console.WriteLine(toWrite);
			}
			else
			{
				Console.Write(toWrite);
			}

			return null;
		}

		public override object VisitVariableDeclaration(PseudoParser.VariableDeclarationContext context)
		{
			var varType = context.type().GetText();
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
			else
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
				throw new Exception($"{varName} is undefined.");
			}
		}

		public override object VisitVariableAssignment(PseudoParser.VariableAssignmentContext context)
		{
			var varName = context.ID().GetText();
			if (!_scopes.DoesVariableExist(varName))
			{
				throw new Exception(ErrorMessages.UndefinedSymbol(varName));
			}
			
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
			var rightValue = ((BooleanLiteral)Visit(context.boolOp(1))).ToBoolean();
			return new BooleanLiteral(leftValue && rightValue);
		}

		public override object VisitOrOp(PseudoParser.OrOpContext context)
		{
			var leftValue = ((BooleanLiteral)Visit(context.boolOp(0))).ToBoolean();
			var rightValue = ((BooleanLiteral)Visit(context.boolOp(1))).ToBoolean();
			return new BooleanLiteral(leftValue && rightValue);
		}

		public override object VisitAreEqual(PseudoParser.AreEqualContext context)
		{
			var leftValue = (NumberLiteral) Visit(context.plusOrMinus(0));
			var rightValue = (NumberLiteral) Visit(context.plusOrMinus(1));
			return new BooleanLiteral(Math.Abs(leftValue.Value - rightValue.Value) < Single.Epsilon);
		}

		public override object VisitGreaterThan(PseudoParser.GreaterThanContext context)
		{
			var leftValue = (NumberLiteral)Visit(context.plusOrMinus(0));
			var rightValue = (NumberLiteral)Visit(context.plusOrMinus(1));
			return new BooleanLiteral(leftValue.Value > rightValue.Value);
		}

		public override object VisitGreaterOrEqual(PseudoParser.GreaterOrEqualContext context)
		{
			var leftValue = (NumberLiteral)Visit(context.plusOrMinus(0));
			var rightValue = (NumberLiteral)Visit(context.plusOrMinus(1));
			return new BooleanLiteral(leftValue.Value >= rightValue.Value);
		}

		public override object VisitLessThan(PseudoParser.LessThanContext context)
		{
			var leftValue = (NumberLiteral)Visit(context.plusOrMinus(0));
			var rightValue = (NumberLiteral)Visit(context.plusOrMinus(1));
			return new BooleanLiteral(leftValue.Value < rightValue.Value);
		}

		public override object VisitLessOrEqual(PseudoParser.LessOrEqualContext context)
		{
			var leftValue = (NumberLiteral)Visit(context.plusOrMinus(0));
			var rightValue = (NumberLiteral)Visit(context.plusOrMinus(1));
			return new BooleanLiteral(leftValue.Value <= rightValue.Value);
		}

		public override object VisitString(PseudoParser.StringContext context)
		{
			return new StringLiteral(context.STRING().GetText().Trim('"'));
		}

		public override object VisitMult(PseudoParser.MultContext context)
		{
			var left = Visit(context.multOrDiv()) as NumberLiteral;
			var right = Visit(context.unarySign()) as NumberLiteral;
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