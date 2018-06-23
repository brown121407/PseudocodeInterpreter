using System;
using System.IO;
using Antlr4.Runtime;
using AntlrGenerated;

namespace PseudocodeInterpreter
{
	internal static class Program
	{
		private static void Main(string[] args)
		{
			string str = "scrie 3.22, 2, 5, 6";
			ICharStream input = CharStreams.fromstring(str);
			
			PseudoLexer lexer = new PseudoLexer(input);
			CommonTokenStream tokens = new CommonTokenStream(lexer);
			PseudoParser parser = new PseudoParser(tokens);
			var tree = parser.file();

			PseudoVisitorImpl calcVisitor = new PseudoVisitorImpl();
			calcVisitor.Visit(tree);
		}
	}
}