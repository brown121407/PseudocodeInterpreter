using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScintillaNET;

namespace PseudoIDE
{
	static class SyntaxHighlighter
	{
		public enum Styles
		{
			Default,
			Keyword,
			Identifier,
			Number,
			String
		}

		private enum States
		{
			Unknown,
			Identifier,
			Number,
			String
		}

		private static readonly HashSet<string> Keywords = new HashSet<string>
		{
			"intreg", "real", "text",
			"scrie", "scrieln", "citeste",
			"daca", "altfel", "atunci", "cat timp", "executa",
			"sfarsit"
		};

		public static void Style(Scintilla scintilla, int startPos, int endPos)
		{
			// Back up to the line start
			var line = scintilla.LineFromPosition(startPos);
			startPos = scintilla.Lines[line].Position;

			var length = 0;
			var state = States.Unknown;

			// Start styling
			scintilla.StartStyling(startPos);
			while (startPos < endPos)
			{
				var c = (char)scintilla.GetCharAt(startPos);

				REPROCESS:
				switch (state)
				{
					case States.Unknown:
						if (c == '"')
						{
							// Start of "string"
							scintilla.SetStyling(1, (int) Styles.String);
							state = States.String;
						}
						else if (Char.IsDigit(c))
						{
							state = States.Number;
							goto REPROCESS;
						}
						else if (Char.IsLetter(c))
						{
							state = States.Identifier;
							goto REPROCESS;
						}
						else
						{
							// Everything else
							scintilla.SetStyling(1, (int) Styles.Default);
						}
						break;

					case States.String:
						if (c == '"')
						{
							length++;
							scintilla.SetStyling(length, (int) Styles.String);
							length = 0;
							state = States.Unknown;
						}
						else
						{
							length++;
						}
						break;

					case States.Number:
						if (Char.IsDigit(c) || (c >= 'a' && c <= 'f') || (c >= 'A' && c <= 'F') || c == 'x')
						{
							length++;
						}
						else
						{
							scintilla.SetStyling(length, (int) Styles.Number);
							length = 0;
							state = States.Unknown;
							goto REPROCESS;
						}
						break;

					case States.Identifier:
						if (Char.IsLetterOrDigit(c))
						{
							length++;
						}
						else
						{
							var style = (int) Styles.Identifier;
							var identifier = scintilla.GetTextRange(startPos - length, length);
							if (Keywords.Contains(identifier))
								style = (int) Styles.Keyword;

							scintilla.SetStyling(length, style);
							length = 0;
							state = States.Unknown;
							goto REPROCESS;
						}
						break;
				}

				startPos++;
			}
		}

		private static string PeekNextWord(string text)
		{
			string word = string.Empty;
			int pos = 0;
			while (!char.IsWhiteSpace(word[pos]))
			{
				word += word[pos];
				pos++;
			}

			return word;
		}
	}
}
