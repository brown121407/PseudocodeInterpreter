using System;

namespace PseudocodeInterpreter
{
	public class Lexer
	{
		private int _pos;

		private string _text;
		private LanguageManager _languageManager;
		private char? _currentChar;

		public Lexer(string text, LanguageManager languageManager)
		{
			_text = text;
			_pos = 0;
			_currentChar = _text[_pos];
			_languageManager = languageManager;
		}
		
		public Token GetNextToken()
		{
			while (_currentChar.HasValue)
			{
				if (char.IsWhiteSpace(_currentChar.Value))
				{
					if (_currentChar.ToString() == Environment.NewLine)
					{
						return new Token(TokenType.NL, Environment.NewLine);
					}
					SkipWhitespace();
					continue;
				}

				if (_currentChar == '#')
				{
					Advance();
					SkipComment();
					continue;
				}

				if (char.IsLetter(_currentChar.Value))
				{
					return Identifier();
				}
				
				if (char.IsDigit(_currentChar.Value))
				{
					return Number();
				}

				switch (_currentChar)
				{
					case '+':
						Advance();
						return new Token(TokenType.Plus, "+");
					case '-':
						Advance();
						return new Token(TokenType.Minus, "-");
					case '*':
					{
						Advance();
						if (_currentChar == '*')
						{
							Advance();
							return new Token(TokenType.Pow, "**");
						}
						return new Token(TokenType.Mult, "*");
					}
					case '/':
					{
						Advance();
						if (_currentChar == '/')
						{
							Advance();
							return new Token(TokenType.DivInt, "//");
						}
						return new Token(TokenType.Div, "/");
					}
					case '.':
						Advance();
						return new Token(TokenType.Dot, ".");
					case '(':
						Advance();
						return new Token(TokenType.LPar, "(");
					case ')':
						Advance();
						return new Token(TokenType.RPar, ")");	
					case '[':
						Advance();
						return new Token(TokenType.LSquBra, "[");
					case ']':
						Advance();
						return new Token(TokenType.RSquBra, "]");
					case '{':
						Advance();
						return new Token(TokenType.LCurBra, "{");
					case '}':
						Advance();
						return new Token(TokenType.RCurBra, "}");
				}

				// if the current char does not match any token
				// throw an error
				Error();
			}
			
			return new Token(TokenType.EOF, null);
		}

		private void Advance()
		{
			_pos++;
			if (_pos > _text.Length - 1)
			{
				_currentChar = null;
			}
			else
			{
				_currentChar = _text[_pos];
			}
		}

		private string Peek(int howFar = 1)
		{
			var peekPos = _pos + howFar;
			return peekPos > _text.Length - 1 ? null : _text.Substring(_pos + 1, peekPos - _pos);
		}

		private void SkipWhitespace()
		{
			while (_currentChar.HasValue && char.IsWhiteSpace(_currentChar.Value))
			{
				Advance();
			}
		}
		
		private void SkipComment()
		{
			while (_currentChar.ToString() != Environment.NewLine)
			{
				Advance();
			}
		}

		private Token Number()
		{
			var result = string.Empty;
			Token token;
			
			while (_currentChar.HasValue && char.IsDigit(_currentChar.Value))
			{
				result += _currentChar;
				Advance();
			}

			if (_currentChar == '.')
			{
				result += _currentChar;
				Advance();
				
				while (_currentChar.HasValue && char.IsDigit(_currentChar.Value))
				{
					result += _currentChar;
					Advance();
				}
				
				token = new Token(TokenType.RealLit, result);
			}
			else
			{
				token = new Token(TokenType.IntegerLit, result);
			}

			return token;
		}
		
		private Token Identifier()
		{
			throw new NotImplementedException();
		}
		
		private void Error() => throw new Exception(_languageManager.Messages.InvalidCharacter(_currentChar.Value));
	}
}