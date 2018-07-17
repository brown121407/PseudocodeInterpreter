namespace PseudocodeInterpreter.Exceptions
{
    class ErrorMessages
    {
	    public const string NullInput = "Datele de intrare nu pot fi nule.";
	    public const string ArgumentsNumber = "Prea multi sau prea putini parametri.";
	    public const string ModuloOnFloats = "Nu se poate executa modulo pe numere reale.";

	    public static string IncompatibleTypes(string typeName, string incompatType)
		    => $"Tipul {typeName} nu e compatibil cu tipul {incompatType}.";

	    public static string IncompatibleTypes(string typeName, params string[] incompatTypes)
		    => $"Tipul {typeName} nu e compatibil cu tipurile {string.Join(" ,", incompatTypes)}.";

	    public static string IncorrectFormat(string value, string wantedType)
		    => $"Format gresit: {value} nu este {wantedType}.";

	    public static string UndefinedSymbol(string symbol)
		    => $"Simbol nedefinit: {symbol}.";
    }
}
