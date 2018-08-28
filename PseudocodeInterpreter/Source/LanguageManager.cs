using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json.Linq;

namespace PseudocodeInterpreter
{
	public class LanguageManager
	{
		private const string LangFilePath = "Config/languages.json";
		
		public Keywords Keywords { get; private set; }
		public Builtins Builtins { get; private set; }
		public Messages Messages { get; private set; }

		public LanguageManager(string languageName = "en")
		{
			var assemblyDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			var langFileFullPath = Path.Combine(assemblyDir, LangFilePath);
			if (!File.Exists(langFileFullPath))
			{
				throw new Exception(message: GetInstructions());
			}

			var json = JObject.Parse(File.ReadAllText(langFileFullPath));

			try
			{
				var lang = json.Children<JProperty>().Single(x => x.Name == languageName);

				var langComponents = lang.Value.Children<JProperty>();
				Keywords = new Keywords(langComponents.Single(x => x.Name == "keywords").First);
				Builtins = new Builtins(langComponents.Single(x => x.Name == "builtins").First);
				Messages = new Messages(langComponents.Single(x => x.Name == "messages").First);
			}
			catch (InvalidOperationException)
			{
				var message =
					"The selected language does not exist, is incomplete or is specified multiple times in the config file." +
					$"{Environment.NewLine}{Environment.NewLine}" +
					GetInstructions();

				throw new Exception(message);

			}
			catch (ArgumentNullException)
			{
				var message = $"There are no languages specified in the config file ({LangFilePath})" +
				              $"{Environment.NewLine}{Environment.NewLine}" +
				              GetInstructions();

				throw new Exception(message);
			}
			catch (Exception)
			{
				throw new Exception(message: GetInstructions());
			}
		}

		public static string GetInstructions()
		{
			return "Download a verified language configuration from: " +
			       "https://raw.githubusercontent.com/brown121407/" +
			       "PseudocodeInterpreter/master/PseudocodeInterpreter/" +
			       $"Config/languages.json{Environment.NewLine}" +
			       $"Language configuration file must be located at {LangFilePath}";
		}
	}
}