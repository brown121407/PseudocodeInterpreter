using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace PseudocodeInterpreter
{
	public class Builtins
	{
		public Dictionary<string, string> Values { get; } = new Dictionary<string, string>();

		public Builtins(JToken builtinsToken)
		{
			foreach (var property in builtinsToken.Children<JProperty>())
			{
				Values.Add(property.Name, property.Value.ToString());
			}
		}
		
		private string GetBuiltin(string builtinName)
		{
			try
			{
				return Values[builtinName];
			}
			catch (Exception)
			{
				throw new Exception(message: LanguageManager.GetInstructions());
			}
		}

		public string Write 	=> GetBuiltin("write");
		public string WriteLine => GetBuiltin("writeLine");
		public string Read		=> GetBuiltin("read");
		public string ToText	=> GetBuiltin("toText");
		public string Length	=> GetBuiltin("length");
	}
}