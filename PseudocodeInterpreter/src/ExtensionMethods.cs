using System;
using System.Collections.Generic;
using PseudocodeInterpreter.Objects;

namespace PseudocodeInterpreter
{
	public static class ExtensionMethods
	{
		public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
		{
			foreach(T item in enumeration)
			{
				action(item);
			}
		}

		public static bool IsLiteralOfType<T>(this Literal literal) where T : Literal
		{
			return literal is T;
		}
	}
}