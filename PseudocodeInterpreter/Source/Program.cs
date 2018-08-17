using System;
using System.Diagnostics;
using System.IO;
using CommandLine;

namespace PseudocodeInterpreter
{
	static class Program
	{
		public static void Main(string[] args)
		{
			ParseCommandLineArguments(args);
		}

		private static void ParseCommandLineArguments(string[] args)
		{
			var parser = new Parser(with =>
			{
				with.EnableDashDash = true;
				with.HelpWriter = Console.Out;
			});

			var result = parser.ParseArguments<CommandLineOptions>(args);
			
			result.WithParsed(ProcessCommandLineArguments);
		}

		private static void ProcessCommandLineArguments(CommandLineOptions options)
		{		
			var languageManager = new LanguageManager(options.Language);
			
			if (!File.Exists(options.File))
			{
				Console.WriteLine($"{options.File} does not exist.");
				return;
			}

			if (options.Stats)
			{
				// TODO use the specified language for messages
				Console.WriteLine($"Executing {options.File}.{Environment.NewLine}");

				var stopWatch = Stopwatch.StartNew();
				
				Interpreter.ExecuteFile(options.File);
				
				stopWatch.Stop();

				Console.WriteLine($"{Environment.NewLine}" +
				                   $"Execution took {stopWatch.Elapsed}." +
				                   $"{Environment.NewLine}" +
				                   $"Press ENTER to quit...");

				Console.ReadLine();
			}
			else
			{
				Interpreter.ExecuteFile(options.File);
			}
		}
	}
}
