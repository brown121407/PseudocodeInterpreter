using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace PseudocodeInterpreter
{
	public class Messages
	{
		private Dictionary<string, string> _values = new Dictionary<string, string>();
		
		public Messages(JToken messagesToken)
		{
			foreach (var property in messagesToken.Children<JProperty>())
			{
				_values.Add(property.Name, property.Value.ToString());
			}
		}
		
		private string GetMessage(string messageName)
		{
			try
			{
				return _values[messageName];
			}
			catch (Exception)
			{
				throw new Exception(message: LanguageManager.GetInstructions());
			}
		}
	}
}