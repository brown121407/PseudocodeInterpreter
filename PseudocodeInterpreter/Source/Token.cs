namespace PseudocodeInterpreter
{
	public enum TokenType
	{
		NUMBER,
		NUMBERLIT,
		TEXT,
		TEXTLIT,
		IF,
		THEN,
		ELSE,
		ELSEIF,
		END,
		WHILE,
		UNTIL,
		TIMES,
		DO,
		FUNCTION,
		RETURN,
		WRITE,
		WRITELINE,
		READ,
		TOTEXT,
		LENGTH,
		CONTINUE,
		BREAK,
		LPAR,
		RPAR,
		LSQUBRA,
		RSQUBRA,
		LCURBRA,
		RCURBRA,
		DOT,
		NL,
		EOF,
		PLUS,
		MINUS,
		MULT,
		DIV,
		DIVINT,
		MOD,
		POW,
		BITAND,
		BITOR,
		BITNEG,
		XOR,
		SHIFTL,
		SHIFTR,
		COLON,
		EQUAL,
		NOTEQUAL,
		LESS,
		LESSEQUAL,
		GREATER,
		GREATEREQUAL,
		ASSIGN,
		IDENTIFIER
	}
	
	public class Token
	{
		public string Value { get; }
		public TokenType Type { get; }

		public Token(TokenType type, string value)
		{
			Value = value;
			Type = type;
		}

		public override string ToString()
		{
			return $"Token({Type.ToString()}, {Value})";
		}

		public override bool Equals(object obj) 
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((Token) obj);
		}

		protected bool Equals(Token other)
		{
			return string.Equals(Value, other.Value) && Type == other.Type;
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return ((Value != null ? Value.GetHashCode() : 0) * 397) ^ (int) Type;
			}
		}
	}
}