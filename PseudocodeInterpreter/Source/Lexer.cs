using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace PseudocodeInterpreter
{
	public class Lexer
	{
		private int _pos;
		private uint _line = 0;

		private readonly string _text;
		public LanguageManager LanguageManager { get; }
		private char? _currentChar;	
		
		public Lexer(string text, LanguageManager languageManager)
		{
			// string normalized = Regex.Replace(originalString, @"\r\n|\n\r|\n|\r", "\r\n");
			_text = Regex.Replace(text, @"\r\n|\n", "\n");
			_pos = 0;
			_currentChar = _text[_pos];
			LanguageManager = languageManager;
			
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
							return new Token(TokenType.EQUAL, "==");
						}

						return new Token(TokenType.ASSIGN, "=");
					}
					case '+':
						Advance();
						return new Token(TokenType.PLUS, "+");
					case '-':
						Advance();
						return new Token(TokenType.MINUS, "-");
					case '*':
					{
						Advance();
						if (_currentChar == '*')
						{
							Advance();
							return new Token(TokenType.POW, "**");
						}

						return new Token(TokenType.MULT, "*");
					}
					case '/':
					{
						Advance();
						if (_currentChar == '/')
						{
							Advance();
							return new Token(TokenType.DIVINT, "//");
						}
						return new Token(TokenType.DIV, "/");
					}
					case '%':
						Advance();
						return new Token(TokenType.MOD, "%");
					case '^':
						Advance();
						return new Token(TokenType.XOR, "^");
					case '|':
						Advance();
						return new Token(TokenType.BITOR, "|");
					case '&':
						Advance();
						return new Token(TokenType.BITAND, "&");
					case '~':
						Advance();
						return new Token(TokenType.BITNEG, "~");
					case '.':
						Advance();
						return new Token(TokenType.DOT, ".");
					case ':':
						Advance();
						return new Token(TokenType.COLON, ":");
					case '(':
						Advance();
						return new Token(TokenType.LPAR, "(");
					case ')':
						Advance();
						return new Token(TokenType.RPAR, ")");	
					case '[':
						Advance();
						return new Token(TokenType.LSQUBRA, "[");
					case ']':
						Advance();
						return new Token(TokenType.RSQUBRA, "]");
					case '{':
						Advance();
						return new Token(TokenType.LCURBRA, "{");
					case '}':
						Advance();
						return new Token(TokenType.RCURBRA, "}");
					case '>':
					{
						Advance();
						if (_currentChar == '=')
						{
							Advance();
							return new Token(TokenType.GREATEREQUAL, ">=");
						}
						else if (_currentChar == '>')
						{
							Advance();
							return new Token(TokenType.SHIFTR, ">>");
						}
						return new Token(TokenType.GREATER, ">");
					}
					case '<':
					{
						Advance();
						if (_currentChar == '=')
						{
							Advance();
							return new Token(TokenType.LESSEQUAL, "<=");
						}
						else if (_currentChar == '<')
						{
							Advance();
							return new Token(TokenType.SHIFTR, "<<");
						}
						return new Token(TokenType.LESS, "<");
					}
					case '!':
					{
						if (PeekChar() == '=')
						{
							Advance(); Advance();
							return new Token(TokenType.NOTEQUAL, "!=");
						}
						InvalidCharError();
						break;
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
				if (_currentChar == '\n')
				{
					Advance();
					_line++;
					return new Token(TokenType.NL, "\n");
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
		/// <returns>A token of type NumberLit</returns>
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
			}
			token = new Token(TokenType.NUMBERLIT, result);

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
			return new Token(TokenType.TEXTLIT, Regex.Unescape(text));
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
				&& LanguageManager.Keywords.Dict.Values
					.Any(x => x.Length > result.Length && x.StartsWith(result + _currentChar + PeekStr()));
			
			if (shouldSearchFurther)
			{
				var howFar = 1;
				var peeked = PeekStr(howFar);
				var extendedResult = result + _currentChar + peeked;

				while (peeked != null)
				{
					var possibleKeywords =
						LanguageManager.Keywords.Dict.Values.Where(x => x.StartsWith(extendedResult)).ToList();

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

						var enumName = LanguageManager.Keywords.Dict.First(x => x.Value == extendedResult).Key
							.ToUpper();
						
						return new Token(Enum.Parse<TokenType>(enumName), extendedResult);
					}
					
					peeked = PeekStr(++howFar);
					extendedResult = result + _currentChar + peeked;
				}	
			}

			if (LanguageManager.Keywords.Dict.Values.Contains(result)) // if the result is a keyword
			{
				var enumName = LanguageManager.Keywords.Dict.First(x => x.Value == result).Key.ToUpper();
				return new Token(Enum.Parse<TokenType>(enumName), result);
			}
			else if (LanguageManager.Builtins.Dict.Values.Contains(result))
			{
				var enumName = LanguageManager.Builtins.Dict.First(x => x.Value == result).Key.ToUpper();
				return new Token(Enum.Parse<TokenType>(enumName), result);
			}
			else
			{
				return new Token(TokenType.IDENTIFIER, result);
			}
		}

		/// <summary>
		/// Throw an exception saying that the current character is invalid.
		/// <para>The exception's message is <see cref="Messages.InvalidCharacter"/></para>
		/// </summary>
		private void InvalidCharError()
		{
			if (_currentChar.HasValue)
				throw new Exception(LanguageManager.Messages.InvalidCharacter(_line, _currentChar.Value));
		}

		private void UnfinishedStringError(string str) =>
			throw new Exception(LanguageManager.Messages.UnfinishedString(_line, str));
	}
}