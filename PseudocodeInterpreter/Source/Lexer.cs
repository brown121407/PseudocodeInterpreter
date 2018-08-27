using System;

namespace PseudocodeInterpreter
{
	public class Lexer
	{
		private int _pos = 0;
		private string _text;
		private LanguageManager _languageManager;

		public Lexer(string text, LanguageManager languageManager)
		{
			_text = text;
		}
		
		public Token GetNextToken()
		{
			throw new NotImplementedException();
		}
	}
}