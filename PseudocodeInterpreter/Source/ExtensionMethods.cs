using System;
using System.Collections.Generic;

namespace PseudocodeInterpreter
{
	public static class ExtensionMethods
	{
		public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
		{
			foreach(var item in enumeration)
			{
				action(item);
			}
		}
	}
}