using System;
using System.Linq;

namespace PseudocodeInterpreter
{
	public class Lexer
	{
		private int _pos;

		private readonly string _text;
		private readonly LanguageManager _languageManager;
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
			var result = string.Empty;
			while (_currentChar.HasValue && char.IsLetterOrDigit(_currentChar.Value))
			{
				result += _currentChar;
				Advance();
			}

			var shouldSearchFurther = 
				Peek(2) != null 
				&& _languageManager.Keywords.Dict.Values
					.Any(x => x.Length > result.Length && x.StartsWith(result + _currentChar + Peek()))
				&& _currentChar.HasValue;
			
			if (shouldSearchFurther)
			{
				var howFar = 1;
				var peeked = Peek(howFar);
				var extendedResult = result + _currentChar + peeked;

				while (peeked != null)
				{
					var possibleKeywords =
						_languageManager.Keywords.Dict.Values.Where(x => x.StartsWith(extendedResult));

					if (possibleKeywords.Contains(extendedResult))
					{
						for (var i = 0; i < peeked.Length + 1; i++)
						{
							Advance();
						}

						var enumName = _languageManager.Keywords.Dict.First(x => x.Value == extendedResult).Key
							.ToUpper();
						
						return new Token(Enum.Parse<TokenType>(enumName), extendedResult);
					}
					
					peeked = Peek(++howFar);
					extendedResult = result + _currentChar + peeked;
				}	
			}

			if (_languageManager.Keywords.Dict.Values.Contains(result)) // if the result is a keyword
			{
				var enumName = _languageManager.Keywords.Dict.First(x => x.Value == result).Key.ToUpper();
				return new Token(Enum.Parse<TokenType>(enumName), result);
			}
			else if (_languageManager.Builtins.Dict.Values.Contains(result))
			{
				var enumName = _languageManager.Builtins.Dict.First(x => x.Value == result).Key.ToUpper();
				return new Token(Enum.Parse<TokenType>(enumName), result);
			}
			else
			{
				return new Token(TokenType.Identifier, result);
			}
		}
		
		private void Error() => throw new Exception(_languageManager.Messages.InvalidCharacter(_currentChar.Value));
	}
}