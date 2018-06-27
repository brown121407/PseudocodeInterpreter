namespace PseudocodeInterpreter.Exceptions
{
    class ErrorMessages
    {
	    public const string NullInput = "Input cannot be null.";
	    public const string ArgumentsNumber = "Too many or too few arguments.";

	    public static string IncompatibleTypes(string typeName, string incompatType)
		    => $"Type {typeName} is not compatible with type {incompatType}.";

	    public static string IncompatibleTypes(string typeName, params string[] incompatTypes)
		    => $"Type {typeName} is not compatible with types {string.Join(" ,", incompatTypes)}.";

	    public static string IncorrectFormat(string value, string wantedType)
		    => $"Incorrect format: {value} is not a {wantedType}.";

	    public static string UndefinedSymbol(string symbol)
		    => $"Undefine symbol: {symbol}.";
    }
}
