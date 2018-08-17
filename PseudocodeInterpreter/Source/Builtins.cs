using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace PseudocodeInterpreter
{
	public class Builtins
	{
		private Dictionary<string, string> _values = new Dictionary<string, string>();
		
		public Builtins(JToken builtinsToken)
		{
			foreach (var property in builtinsToken.Children<JProperty>())
			{
				_values.Add(property.Name, property.Value.ToString());
			}
		}
		
		private string GetBuiltin(string builtinName)
		{
			try
			{
				return _values[builtinName];
			}
			catch (Exception)
			{
				throw new Exception(message: LanguageManager.GetInstructions());
			}
		}

		public string Write 	=> GetBuiltin("write");
		public string WriteLine => GetBuiltin("writeLine");
		public string Read		=> GetBuiltin("read");
	}
}