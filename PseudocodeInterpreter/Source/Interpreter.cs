using System;
using System.IO;
using System.Text.RegularExpressions;

namespace PseudocodeInterpreter
{
	public static class Interpreter
	{
		public static void ExecuteFile(string fileName)
		{
			var source = File.ReadAllText(fileName);
			
			// Remove all empty lines
			source = Regex.Replace(source, @"^\s*$\n|\r", string.Empty, RegexOptions.Multiline).TrimEnd();
			
			// Translate the pseudocode
			
			// Execute the result
		}
	}
}