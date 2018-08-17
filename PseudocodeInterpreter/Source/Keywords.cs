using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace PseudocodeInterpreter
{
	public class Keywords
	{
		private Dictionary<string, string> _values = new Dictionary<string, string>();

		public Keywords(JToken keywordsToken)
		{
			foreach (var property in keywordsToken.Children<JProperty>())
			{
				_values.Add(property.Name, property.Value.ToString());
			}
		}

		private string GetKeyword(string keywordName)
		{
			try
			{
				return _values[keywordName];
			}
			catch (Exception)
			{
				throw new Exception(message: LanguageManager.GetInstructions());
			}
		}
			
		public string Integer 	=> GetKeyword("integer");
		public string Real		=> GetKeyword("real");
		public string Text 		=> GetKeyword("text");
		public string If 		=> GetKeyword("if");      
		public string Else 		=> GetKeyword("else");    
		public string ElseIf 	=> GetKeyword("elseIf");
		public string Then 		=> GetKeyword("then");
		public string While		=> GetKeyword("while");
		public string Until 	=> GetKeyword("until");
		public string Times 	=> GetKeyword("times");
		public string Do 		=> GetKeyword("do");      
		public string End 		=> GetKeyword("end");
		public string Function 	=> GetKeyword("function");
		public string Return 	=> GetKeyword("return");
	}
}