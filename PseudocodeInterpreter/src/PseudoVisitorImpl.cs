using System;
using System.Collections.Generic;
using System.Linq;
using Antlr4.Runtime;
using AntlrGenerated;
using PseudocodeInterpreter.Objects;

namespace PseudocodeInterpreter
{
	public class PseudoVisitorImpl : PseudoBaseVisitor<object>
	{
		private Dictionary<string, Literal> _variables = new Dictionary<string, Literal>();
		private const string IntType = "intreg";
		private const string RealType = "real";
		private const string StringType = "text";

		public override object VisitFile(PseudoParser.FileContext context)
		{
			object result = null;
			foreach (var statement in context.stat())
			{
				result = Visit(statement);
			}

			return result;
		}

		public override object VisitReadBuiltinStat(PseudoParser.ReadBuiltinStatContext context)
		{
			return base.VisitReadBuiltinStat(context);
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
			var varName = context.ID().GetText();
			var varType = context.type().GetText();
			
			var expr = context.expr();
			if (expr != null)
			{
				var exprResult = Visit(expr) as Literal;
				if (exprResult is NumberLiteral number)
				{
					if (varType == IntType)
					{
						if (number.IsInteger)
						{
							_variables.Add(varName, number);
						}
						else
						{
							throw new Exception("Can't fit floats into integers");
						}
					}
					else if (varType == RealType)
					{
						_variables.Add(varName, number);
					}
					else
					{
						throw new Exception($"{varType} cannot hold numbers");
					}
				}
				else if (exprResult is StringLiteral text)
				{
					if (varType == StringType)
					{
						_variables.Add(varName, text);
					}
					else
					{
						throw new Exception($"{varType} cannot hold text");
					}
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