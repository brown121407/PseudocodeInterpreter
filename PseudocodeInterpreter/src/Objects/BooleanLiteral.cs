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
