using System;
using PseudocodeInterpreter.Exceptions;

namespace PseudocodeInterpreter.Objects
{
    public abstract class Literal : IValue
    {
	    Literal IValue.GetValue()
	    {
		    return this;
	    }

		public string Type { get; protected set; }

	    public virtual bool ToBoolean()
	    {
		    throw new Exception(ErrorMessages.IncompatibleTypes(this.Type, TypeNames.Boolean));
	    }
    }
}
