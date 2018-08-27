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
	}
}