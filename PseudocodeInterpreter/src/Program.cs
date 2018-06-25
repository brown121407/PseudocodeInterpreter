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
			ICharStream input = CharStreams.fromStream(File.OpenRead(args[0]));
			
			PseudoLexer lexer = new PseudoLexer(input);
			CommonTokenStream tokens = new CommonTokenStream(lexer);
			PseudoParser parser = new PseudoParser(tokens);
			var tree = parser.file();

			PseudoVisitorImpl calcVisitor = new PseudoVisitorImpl();

			try
			{
				calcVisitor.Visit(tree);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
			}
		}
	}
}