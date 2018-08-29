using System;
using System.Linq;

namespace PseudocodeInterpreter
{
	public class Lexer
	{
		private int _pos;
		private uint _line = 0;

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
		
		/// <summary>
		/// Advance through the text looking for the next token
		/// </summary>
		/// <returns>The next available token</returns>
		public Token GetNextToken()
		{
			while (_currentChar.HasValue)
			{
				if (char.IsWhiteSpace(_currentChar.Value))
				{
					var result = SkipWhitespace();
					
					// if found a new line char
					if (result != null)
					{
						return result;
					}
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
					case '"':
						Advance();
						return String();
					case '=':
					{
						Advance();
						if (_currentChar == '=')
						{
							Advance();
							return new Token(TokenType.Equals, "==");
						}

						return new Token(TokenType.Attrib, "=");
					}
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
					case '>':
					{
						Advance();
						if (_currentChar == '=')
						{
							Advance();
							return new Token(TokenType.GreaterEqual, ">=");
						}
						return new Token(TokenType.GreaterThan, ">");
					}
					case '<':
					{
						Advance();
						if (_currentChar == '=')
						{
							Advance();
							return new Token(TokenType.LessEqual, "<=");
						}
						return new Token(TokenType.LessThan, "<");
					}
				}

				// if the current char does not match any token
				// throw an error
				InvalidCharError();
			}
			
			return new Token(TokenType.EOF, null);
		}

		/// <summary>
		/// Move the current character to the next one or assign <c>null</c> if the string ends.
		/// </summary>
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

		/// <summary>
		/// Peek at the following string of characters
		/// </summary>
		/// <param name="howFar">How far front to look</param>
		/// <returns>The substring from the current position to current position + howFar or null if the string ends</returns>
		private string PeekStr(int howFar = 1)
		{
			var peekPos = _pos + howFar;
			return peekPos > _text.Length - 1 ? null : _text.Substring(_pos + 1, peekPos - _pos);
		}

		/// <summary>
		/// Peek at a farther character
		/// </summary>
		/// <param name="howFar">How far front to look</param>
		/// <returns>The character at the <c>howFar</c> distance or null if the string ends</returns>
		private char? PeekChar(int howFar = 1)
		{
			var peekPos = _pos + howFar;
			return peekPos > _text.Length - 1 ? (char?) null : _text[peekPos];
		}

		/// <summary>
		/// Skip whitespace characters, except for new lines
		/// </summary>
		/// <returns>A NewLine Token if it encounters new line character, else null</returns>
		private Token SkipWhitespace()
		{
			while (_currentChar.HasValue && char.IsWhiteSpace(_currentChar.Value))
			{
				if (_currentChar.ToString() == Environment.NewLine)
				{
					Advance();
					_line++;
					return new Token(TokenType.NL, Environment.NewLine);
				}
				Advance();
			}

			return null;
		}
		
		/// <summary>
		/// Skip the whole line, used after a comment start ('#')
		/// </summary>
		private void SkipComment()
		{
			while (_currentChar.ToString() != Environment.NewLine)
			{
				Advance();
			}
		}

		/// <summary>
		/// Read text for an integer or real number
		/// </summary>
		/// <returns>A token of type IntegerLit or RealLit</returns>
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

		private Token String()
		{
			var text = string.Empty;
			
			while (_currentChar.HasValue && _currentChar != '"')
			{
				if (_currentChar == '\\')
				{
					text += _currentChar;
					Advance();
					if (!_currentChar.HasValue)
					{
						UnfinishedStringError(text);
					}
				}
				text += _currentChar;
				Advance();
			}

			if (_currentChar != '"')
			{
				UnfinishedStringError(text);
			}
			
			Advance();
			return new Token(TokenType.TextLit, System.Text.RegularExpressions.Regex.Unescape(text));
		}
		
		/// <summary>
		/// Lexer rule for identifiers.
		/// <para>Any identifier has the form: [a-zA-Z][a-zA-Z0-9]. The only exceptions are multi-word-keywords
		/// which also include spaces.</para>
		/// </summary>
		/// <returns>A token which can have any of the Keyword types, Builtin types or a simple Identifier type</returns>
		private Token Identifier()
		{
			var result = string.Empty;
			
			// read until while the current char is a letter or digit
			while (_currentChar.HasValue && char.IsLetterOrDigit(_currentChar.Value))
			{
				result += _currentChar;
				Advance();
			}

			// if there are more characters and the current string plus the next two chars
			// represents the start of a keyword it should search further
			var shouldSearchFurther =
				_currentChar.HasValue
				&& PeekStr() != null
				&& _languageManager.Keywords.Dict.Values
					.Any(x => x.Length > result.Length && x.StartsWith(result + _currentChar + PeekStr()));
			
			if (shouldSearchFurther)
			{
				var howFar = 1;
				var peeked = PeekStr(howFar);
				var extendedResult = result + _currentChar + peeked;

				while (peeked != null)
				{
					var possibleKeywords =
						_languageManager.Keywords.Dict.Values.Where(x => x.StartsWith(extendedResult)).ToList();

					if (!possibleKeywords.Any())
					{
						break;
					}

					if (possibleKeywords.Contains(extendedResult))
					{
						var nextChar = PeekChar(howFar + 1);
						
						// if the next character is not a space (is alphanum) break
						// for example: else ifBreak
						if (nextChar.HasValue && !char.IsWhiteSpace(nextChar.Value))
						{
							break;
						}
						
						// Fast forward to after the whole keyword
						for (var i = 0; i < peeked.Length + 1; i++)
						{
							Advance();
						}

						var enumName = _languageManager.Keywords.Dict.First(x => x.Value == extendedResult).Key
							.ToUpper();
						
						return new Token(Enum.Parse<TokenType>(enumName), extendedResult);
					}
					
					peeked = PeekStr(++howFar);
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

		/// <summary>
		/// Throw an exception saying that the current character is invalid.
		/// <para>The exception's message is <see cref="Messages.InvalidCharacter"/></para>
		/// </summary>
		private void InvalidCharError() =>
			throw new Exception(_languageManager.Messages.InvalidCharacter(_line, _currentChar.Value));

		private void UnfinishedStringError(string str) =>
			throw new Exception(_languageManager.Messages.UnfinishedString(_line, str));
	}
}