using System;
using System.Collections.Generic;
using System.Linq;
using Antlr4.Runtime;
using AntlrGenerated;

namespace PseudocodeInterpreter
{
	public class PseudoVisitorImpl : PseudoBaseVisitor<object>
	{
		private Dictionary<string, int> _ints = new Dictionary<string, int>();
		private Dictionary<string, float> _floats = new Dictionary<string, float>();


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
			string toWrite = Visit(context.expr(0)).ToString();
			context.expr().Skip(1).ForEach(x => toWrite += " " + Visit(x).ToString());

			Console.WriteLine(toWrite);

			return null;
		}

		public override object VisitVariableDeclaration(PseudoParser.VariableDeclarationContext context)
		{
			// create var
			
			var expr = context.expr();
			if (expr != null)
			{
				// attrib value
			}

			return null;
		}

		public override object VisitMult(PseudoParser.MultContext context)
		{
			var left = Visit(context.multOrDiv()) as Number;
			var right = Visit(context.unarySign()) as Number;
			return left * right;
		}

		public override object VisitDiv(PseudoParser.DivContext context)
		{
			var left = Visit(context.multOrDiv()) as Number;
			var right = Visit(context.unarySign()) as Number;
			return left / right;
		}

		public override object VisitAdd(PseudoParser.AddContext context)
		{
			var left = Visit(context.plusOrMinus()) as Number;
			var right = Visit(context.multOrDiv()) as Number;
			return left + right;
		}

		public override object VisitSub(PseudoParser.SubContext context)
		{
			var left = Visit(context.plusOrMinus()) as Number;
			var right = Visit(context.multOrDiv()) as Number;
			return left - right;
		}

		public override object VisitUnaryPlus(PseudoParser.UnaryPlusContext context)
		{
			return Visit(context.unarySign());
		}

		public override object VisitUnaryMinus(PseudoParser.UnaryMinusContext context)
		{
			var toNegate = Visit(context.unarySign()) as Number;
			return toNegate?.Negate();
		}

		public override object VisitInteger(PseudoParser.IntegerContext context)
		{
			return new Number(int.Parse(context.GetText()));
		}

		public override object VisitFloatingPoint(PseudoParser.FloatingPointContext context)
		{
			return new Number(float.Parse(context.GetText()));
		}

		public override object VisitToParenExpr(PseudoParser.ToParenExprContext context)
		{
			return Visit(context.plusOrMinus());
		}
	}
}