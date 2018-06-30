using System;
using System.IO;
using System.Text.RegularExpressions;
using Antlr4.Runtime;
using AntlrGenerated;

namespace PseudocodeInterpreter
{
	internal static class Program
	{
		private static void Main(string[] args)
		{
			string source = File.ReadAllText(args[0]);
			source = Regex.Replace(source, @"^\s*$\n|\r", string.Empty, RegexOptions.Multiline).TrimEnd();

			ICharStream input = CharStreams.fromstring(source);
			
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