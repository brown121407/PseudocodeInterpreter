using System;
using PseudocodeInterpreter.Exceptions;

namespace PseudocodeInterpreter.Objects
{
    public abstract class Literal
    {
		public string Type { get; protected set; }

	    public virtual bool ToBoolean()
	    {
		    throw new Exception(ErrorMessages.IncompatibleTypes(Type, TypeNames.Boolean));
	    }
    }
}
