using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace PseudocodeInterpreter
{
	public class Messages
	{
		public Dictionary<string, string> Values { get; } = new Dictionary<string, string>();

		public Messages(JToken messagesToken)
		{
			foreach (var property in messagesToken.Children<JProperty>())
			{
				Values.Add(property.Name, property.Value.ToString());
			}
		}
		
		private string GetMessage(string messageName)
		{
			try
			{
				return Values[messageName];
			}
			catch (Exception)
			{
				throw new Exception(message: LanguageManager.GetInstructions());
			}
		}
	}
}