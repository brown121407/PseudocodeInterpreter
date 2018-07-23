using System;
using System.Diagnostics;
using System.IO;
using PseudocodeInterpreter.Exceptions;

namespace PseudocodeInterpreter
{
	static class Program
	{
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

					Stopwatch stopwatch = Stopwatch.StartNew();

					Interpreter.ExecuteFile(args);

					stopwatch.Stop();

					Interpreter.Output($"{Environment.NewLine}> Executia a durat: {stopwatch.Elapsed}{Environment.NewLine}");
					Interpreter.Output("> Apasati tasta ENTER pentru a inchide programul...");
					Interpreter.Input();
				}
			}
		}
	}
}
