using System;
using System.IO;
using System.Text.RegularExpressions;
using Antlr4.Runtime;
using AntlrGenerated;

namespace PseudocodeInterpreter
{
	public static class Interpreter
	{
		public static Action<string> Output { get; set; } = Console.Write;
		public static Func<string> Input { get; set; } = Console.ReadLine;

		public static void ExecuteFile(string fileName)
		{
			var source = File.ReadAllText(fileName);

			// Remove all empty lines
			source = Regex.Replace(source, @"^\s*$\n|\r", string.Empty, RegexOptions.Multiline).TrimEnd();

			var input = CharStreams.fromstring(source);
			
			var lexer = new PseudoLexer(input);
			var tokens = new CommonTokenStream(lexer);
			var parser = new PseudoParser(tokens);
			var tree = parser.file();

			var calcVisitor = new PseudoVisitorImpl();

			try
			{
				calcVisitor.Visit(tree);
			}
			catch (Exception e)
			{
				Output(e.Message);
			}
		}
	}
}