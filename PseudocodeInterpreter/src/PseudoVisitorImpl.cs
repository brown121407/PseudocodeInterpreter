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
		private Dictionary<string, Literal> _variables = new Dictionary<string, Literal>();

		public override object VisitFile(PseudoParser.FileContext context)
		{
			Visit(context.statList());
			
			return null;
		}

		public override object VisitStatList(PseudoParser.StatListContext context)
		{
			foreach (var statContext in context.stat())
			{
				Visit(statContext);
			}

			return null;
		}

		public override object VisitReadBuiltinStat(PseudoParser.ReadBuiltinStatContext context)
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
				if (_variables.ContainsKey(ids[i]))
				{
					var variable = _variables[ids[i]];

					if (variable is NumberLiteral)
					{
						if (float.TryParse(values[i], out var numValue))
						{
							_variables[ids[i]] = new NumberLiteral(numValue);
						}
						else
						{
							throw new Exception(ErrorMessages.IncorrectFormat(values[i], TypeNames.NumberType));
						}
					}
					else if (variable is StringLiteral)
					{
						_variables[ids[i]] = new StringLiteral(values[i]);
					}
				}
				else
				{
					throw new Exception(ErrorMessages.UndefinedSymbol(ids[i]));
				}
			}

			return null;
		}

		public override object VisitWriteBuiltinStat(PseudoParser.WriteBuiltinStatContext context)
		{
			string toWrite = string.Empty;
			context.expr().ForEach(x => toWrite += Visit(x).ToString());

			Console.WriteLine(toWrite);

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
							_variables.Add(varName, exprNum);
						}
						else
						{
							throw new Exception(ErrorMessages.IncompatibleTypes(varType, exprNum.Type));
						}
					}
					else if (varType == TypeNames.RealType)
					{
						_variables.Add(varName, exprNum);
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
						_variables.Add(varName, text);
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
					_variables.Add(varName, new NumberLiteral(0));
				}
				else if (varType == TypeNames.RealType)
				{
					_variables.Add(varName, new NumberLiteral(0.0f));
				}
				else if (varType == TypeNames.StringType)
				{
					_variables.Add(varName, new StringLiteral(string.Empty));
				}
			}

			return null;
		}

		public override object VisitGetVariable(PseudoParser.GetVariableContext context)
		{
			var varName = context.ID().GetText();
			if (_variables.ContainsKey(varName))
			{
				return _variables[varName];
			}
			else
			{
				throw new Exception($"{varName} is undefined.");
			}
		}

		public override object VisitVariableAssignment(PseudoParser.VariableAssignmentContext context)
		{
			var varName = context.ID().GetText();
			if (!_variables.ContainsKey(varName))
			{
				throw new Exception(ErrorMessages.UndefinedSymbol(varName));
			}

			var exprResult = (Literal) Visit(context.expr());

			if (exprResult is NumberLiteral exprNum)
			{
				if (_variables[varName] is NumberLiteral varNum)
				{
					if (varNum.IsInteger && !exprNum.IsInteger)
					{
						throw new Exception(ErrorMessages.IncompatibleTypes(varNum.Type, exprNum.Type));
					}
					else
					{
						_variables[varName] = varNum;
					}
				}
				else
				{
					throw new Exception(ErrorMessages.IncompatibleTypes(_variables[varName].Type, TypeNames.NumberType));
				}
			}
			else if (exprResult is StringLiteral text)
			{
				if (_variables[varName] is StringLiteral)
				{
					_variables[varName] = text;
				}
				else
				{
					throw new Exception(ErrorMessages.IncompatibleTypes(_variables[varName].Type, TypeNames.StringType));
				}
			}


			return null;
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
			var left = Visit(context.multOrDiv()) as NumberLiteral;
			var right = Visit(context.unarySign()) as NumberLiteral;
			return left / right;
		}

		public override object VisitAdd(PseudoParser.AddContext context)
		{
			var left = Visit(context.plusOrMinus()) as NumberLiteral;
			var right = Visit(context.multOrDiv()) as NumberLiteral;
			return left + right;
		}

		public override object VisitSub(PseudoParser.SubContext context)
		{
			var left = Visit(context.plusOrMinus()) as NumberLiteral;
			var right = Visit(context.multOrDiv()) as NumberLiteral;
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