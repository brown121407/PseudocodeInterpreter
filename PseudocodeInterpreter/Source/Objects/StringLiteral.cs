using System;

namespace PseudocodeInterpreter.Objects
{
    class StringLiteral : Literal
    {
	    private string _value;

	    public StringLiteral(string value)
	    {
			// Handle escaped quotes
		    _value = value.Replace("\\\"", "\"").Replace("\\n", Environment.NewLine);
		    Type = TypeNames.StringType;
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
