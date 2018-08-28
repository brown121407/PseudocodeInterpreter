namespace PseudocodeInterpreter
{
	public enum TokenType
	{
		Integer,
		IntegerLit,
		Real,
		RealLit,
		Text,
		TextLit,
		If,
		Then,
		Else,
		ElseIf,
		End,
		While,
		Until,
		Times,
		Do,
		Function,
		Return,
		Write,
		WriteLine,
		Read,
		ToText,
		Length,
		LPar,
		RPar,
		LSquBra,
		RSquBra,
		LCurBra,
		RCurBra,
		Dot,
		NL,
		EOF,
		Plus,
		Minus,
		Mult,
		Div,
		DivInt,
		Pow
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

		public string Representation()
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