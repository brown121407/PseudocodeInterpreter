namespace PseudocodeInterpreter.Objects
{
    class BooleanLiteral : Literal
    {
		public bool Value { get; }

	    public BooleanLiteral(bool value)
	    {
		    Type = TypeNames.Boolean;
		    Value = value;
		}

	    public static implicit operator bool(BooleanLiteral literal)
	    {
		    return literal.Value;
	    }

		public static BooleanLiteral operator !(BooleanLiteral literal)
	    {
			return new BooleanLiteral(!literal.Value);
	    }
	    
	    public override bool ToBoolean()
	    {
		    return Value;
	    }

	    public override string ToString()
	    {
		    return Value.ToString();
	    }
    }
}
