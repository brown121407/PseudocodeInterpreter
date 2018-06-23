namespace PseudocodeInterpreter
{
	public class Number
	{
		private int? _integer = null;
		private float? _float = null;
		
		public int? Integer
		{
			get => _integer;
			set
			{
				_integer = value;
				_float = null;
			}
		}

		public float? Float 
		{
			get => _float;
			set
			{
				_float = value;
				_integer = null;
			}
		}
		
		public bool IsInteger => _integer.HasValue;
		public bool IsFloat => _float.HasValue;

		public Number(int? integer)
		{
			this.Integer = integer;
		}

		public Number(float? floatingPoint)
		{
			this.Float = floatingPoint;
		}

		public Number Negate()
		{
			if (IsFloat) _float *= -1;
			else _integer *= -1;
			return this;
		}
		
		public static Number operator +(Number number1, Number number2)
		{
			if (number1.IsInteger && number2.IsInteger)
			{
				return new Number(number1.Integer + number2.Integer);
			}

			if (number1.IsFloat)
			{
				return number2.IsFloat 
					? new Number(number1.Float + number2.Float)
					: new Number(number1.Float + number2.Integer);
			}

			return new Number(number1.Integer + number2.Float);
		}

		public static Number operator -(Number number1, Number number2)
		{
			if (number1.IsInteger && number2.IsInteger)
			{
				return new Number(number1.Integer - number2.Integer);
			}

			if (number1.IsFloat)
			{
				return number2.IsFloat 
					? new Number(number1.Float - number2.Float)
					: new Number(number1.Float - number2.Integer);
			}

			return new Number(number1.Integer - number2.Float);
		}
		
		public static Number operator *(Number number1, Number number2)
		{
			if (number1.IsInteger && number2.IsInteger)
			{
				return new Number(number1.Integer * number2.Integer);
			}

			if (number1.IsFloat)
			{
				return number2.IsFloat 
					? new Number(number1.Float * number2.Float)
					: new Number(number1.Float * number2.Integer);
			}

			return new Number(number1.Integer * number2.Float);
		}
		
		public static Number operator /(Number number1, Number number2)
		{
			if (number1.IsInteger && number2.IsInteger)
			{
				return new Number(number1.Integer / number2.Integer);
			}

			if (number1.IsFloat)
			{
				return number2.IsFloat 
					? new Number(number1.Float / number2.Float)
					: new Number(number1.Float / number2.Integer);
			}

			return new Number(number1.Integer / number2.Float);
		}

		public override string ToString()
		{
			return IsInteger ? _integer.ToString() : _float.ToString();
		}
	}
}