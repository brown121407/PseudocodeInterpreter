namespace PseudocodeInterpreter
{
	public enum TokenType
	{
		Integer,
		IntegerLit,
		Real,
		RealLit,
		Text,
		TextLit
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