using System;
using System.Diagnostics;
using System.IO;
using PseudocodeInterpreter.Exceptions;

namespace PseudocodeInterpreter
{
	static class Program
	{
		/// <param name="args">
		/// Represents the command line args. Should be &lt;filename&gt;.
		/// "diagnostics" is optional but should come after the &lt;filename&gt;
		/// </param>
		public static void Main(string[] args)
		{
			if (!File.Exists(args[0]))
			{
				Interpreter.Output(ErrorMessages.FileDoesNotExist);
			}

			if (args.Length > 1)
			{
				if (args[1].Equals("diagnostics"))
				{
					Interpreter.Output($"> Se executa {args[0]}{Environment.NewLine}");

					// Start to count execution time
					Stopwatch stopwatch = Stopwatch.StartNew();

					Interpreter.ExecuteFile(args[0]);

					stopwatch.Stop();

					Interpreter.Output(
						$"{Environment.NewLine}> Executia a durat: {stopwatch.Elapsed}{Environment.NewLine}");
					Interpreter.Output("> Apasati tasta ENTER pentru a inchide programul...");

					// Ask for ENTER-ending input so the user can see the output of the program before quiting
					Interpreter.Input();
				}
			}
			else
			{
				Interpreter.ExecuteFile(args[0]);
			}
		}
	}
}
