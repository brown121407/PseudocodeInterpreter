namespace PseudocodeInterpreter.Objects
{
    public abstract class Literal : IValue
    {
	    Literal IValue.GetValue()
	    {
		    return this;
	    }
    }
}
