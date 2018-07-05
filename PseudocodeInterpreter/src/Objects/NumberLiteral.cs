using System;

namespace PseudocodeInterpreter.Objects
{
    class NumberLiteral : Literal
    {
	    public float Value { get; }

	    public NumberLiteral(float value)
	    {
		    Value = value;
		    Type = TypeNames.RealType;
	    }

	    public NumberLiteral(int value)
	    {
		    Value = value;
		    Type = TypeNames.IntegerType;
	    }

	    public NumberLiteral(float value, string type = TypeNames.RealType)
	    {
		    Value = ((type == TypeNames.RealType) ? value : (int) value);
		    Type = type;
	    }

	    public bool IsInteger => Type == TypeNames.IntegerType;

	    public static implicit operator int(NumberLiteral number)
	    {
		    return (int) number.Value;
	    }

	    public static implicit operator float(NumberLiteral number)
	    {
		    return number.Value;
	    }

		public static implicit operator NumberLiteral(int number)
	    {
			return new NumberLiteral(number);
	    }

	    public static implicit operator NumberLiteral(float number)
	    {
		    return new NumberLiteral(number);
	    }

		public static NumberLiteral operator +(NumberLiteral number1, NumberLiteral number2)
	    {
			if (number1.IsInteger && number2.IsInteger)
		    {
			    return new NumberLiteral((int)number1.Value + (int)number2.Value);
		    }
		    return new NumberLiteral(number1.Value + number2.Value);
		}

		public static NumberLiteral operator -(NumberLiteral number1, NumberLiteral number2)
	    {
			if (number1.IsInteger && number2.IsInteger)
		    {
			    return new NumberLiteral((int)number1.Value - (int)number2.Value);
		    }
		    return new NumberLiteral(number1.Value - number2.Value);
		}

		public static NumberLiteral operator *(NumberLiteral number1, NumberLiteral number2)
	    {
		    if (number1.IsInteger && number2.IsInteger)
		    {
			    return new NumberLiteral((int) number1.Value * (int) number2.Value);
		    }
			return new NumberLiteral(number1.Value * number2.Value);
	    }

	    public static NumberLiteral operator /(NumberLiteral number1, NumberLiteral number2)
	    {
		    if (number1.IsInteger && number2.IsInteger)
		    {
			    int left = (int) number1.Value, right = (int) number2.Value;
			    if (left % right == 0)
			    {
					return new NumberLiteral(left / right);
			    }
		    }
			return new NumberLiteral(number1.Value / number2.Value);
	    }

	    public static NumberLiteral operator %(NumberLiteral number1, NumberLiteral number2)
	    {
		    if (!number1.IsInteger || !number2.IsInteger)
		    {
				// TODO Store error message in a field
			    throw new Exception("Can't perform modulo on floats.");
		    }

		    return new NumberLiteral((int)number1.Value % (int)number2.Value);
	    }

	    public static NumberLiteral operator -(NumberLiteral number)
	    {
			if (number.IsInteger)
				return new NumberLiteral((int) number.Value * -1);
			
			return new NumberLiteral(number.Value * -1);
	    }

	    public override string ToString()
	    {
		    return Value.ToString();
	    }

	    public override bool ToBoolean()
	    {
		    return Math.Abs(Value) >= float.Epsilon;
	    }
    }
}
