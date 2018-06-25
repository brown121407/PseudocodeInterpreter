namespace PseudocodeInterpreter.Objects
{
    class StringLiteral : Literal
    {
	    private string _value;

	    public StringLiteral(string value)
	    {
		    _value = value.Replace("\\\"", "\"");
	    }

	    public static implicit operator string(StringLiteral text)
	    {
		    return text._value;
	    }

	    public static implicit operator StringLiteral(string text)
	    {
			return new StringLiteral(text);
	    }

	    public override string ToString()
	    {
		    return _value;
	    }
    }
}
