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
		    return new NumberLiteral(number1.Value + number2.Value);
	    }

		public static NumberLiteral operator -(NumberLiteral number1, NumberLiteral number2)
	    {
		    return new NumberLiteral(number1.Value - number2.Value);
	    }

		public static NumberLiteral operator *(NumberLiteral number1, NumberLiteral number2)
	    {
			return new NumberLiteral(number1.Value * number2.Value);
	    }

	    public static NumberLiteral operator /(NumberLiteral number1, NumberLiteral number2)
	    {
			return new NumberLiteral(number1.Value / number2.Value);
	    }

	    public static NumberLiteral operator %(NumberLiteral number1, NumberLiteral number2)
	    {
		    return new NumberLiteral(number1.Value % number2.Value);
	    }

	    public static NumberLiteral operator -(NumberLiteral number)
	    {
			return new NumberLiteral(-number.Value);
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
