using System.Collections.Generic;
using Xunit;

namespace PseudocodeInterpreter.Tests
{
	public class LanguageTest
	{
		[Fact]
		public void Test_LanguageKeywords_En()
		{
			var keywords = new Dictionary<string, string>
			{
				{"integer", 	"integer"},
				{"real", 		"real"},
				{"text", 		"text"},
				{"if", 			"if"},
				{"then", 		"then"},
				{"else", 		"else"},
				{"elseIf", 		"else if"},
				{"while", 		"while"},   
				{"until", 		"until"},
				{"times", 		"times"},
				{"do", 			"do"},
				{"end", 		"end"},
				{"function", 	"function"},
				{"return", 		"return"}
			};
			
			var langManager = new LanguageManager();
			
			Assert.Equal(keywords, langManager.Keywords.Dict);
		}
		
		[Fact]
		public void Test_LanguageKeywords_Ro()
		{
			var keywords = new Dictionary<string, string>
			{
				{"integer", 	"intreg"},
				{"real", 		"real"},
				{"text", 		"text"},
				{"if", 			"daca"},
				{"then", 		"atunci"},
				{"else", 		"altfel"},
				{"elseIf", 		"altfel daca"},
				{"while", 		"cat timp"},   
				{"until", 		"pana cand"},
				{"times", 		"ori"},
				{"do", 			"executa"},
				{"end", 		"sfarsit"},
				{"function", 	"functie"},
				{"return", 		"returneaza"}
			};
			
			var langManager = new LanguageManager("ro");
			
			Assert.Equal(keywords, langManager.Keywords.Dict);
		}

		[Fact]
		public void Test_LanguageBuiltins_En()
		{
			var builtins = new Dictionary<string, string>
			{
				{"write", "write"},
				{"writeLine", "writeLine"},
				{"read", "read"},
				{"toText", "toText"},
				{"length", "length"}
			};
			
			var langManager = new LanguageManager();
			
			Assert.Equal(builtins, langManager.Builtins.Dict);
		}
		
		[Fact]
		public void Test_LanguageBuiltins_Ro()
		{
			var builtins = new Dictionary<string, string>
			{
				{"write", "scrie"},
				{"writeLine", "scrieln"},
				{"read", "citeste"},
				{"toText", "inText"},
				{"length", "lungime"}
			};
			
			var langManager = new LanguageManager("ro");
			
			Assert.Equal(builtins, langManager.Builtins.Dict);
		}

		[Fact]
		public void Test_LanguageMessages_En()
		{
			var messages = new Dictionary<string, string>
			{
				{"invalidChar", "Invalid character: {0}"}
			};

			var langManager = new LanguageManager();
			
			Assert.Equal(messages, langManager.Messages.Values);
		}

		[Fact]
		public void Test_LanguageMessages_Ro()
		{
			var messages = new Dictionary<string, string>
			{
				{"invalidChar", "Caracter invalid: {0}"}
			};

			var langManager = new LanguageManager("ro");
			
			Assert.Equal(messages, langManager.Messages.Values);
		}
	}
}