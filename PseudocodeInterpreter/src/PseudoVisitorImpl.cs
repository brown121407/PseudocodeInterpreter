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
			string toWrite =  string.Empty;
			toWrite = context.expr().Aggregate(toWrite, (current, exprContext) => current + (" " + Visit(exprContext).ToString()));

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

		public override object VisitInteger(PseudoParser.IntegerContext context)
		{
			return int.Parse(context.GetText());
		}

		public override object VisitFloatingPoint(PseudoParser.FloatingPointContext context)
		{
			return float.Parse(context.GetText());
		}
	}
}