namespace PseudocodeInterpreter.Objects
{
    public abstract class Literal : IValue
    {
	    Literal IValue.GetValue()
	    {
		    return this;
	    }

		public string Type { get; protected set; }
    }
}
