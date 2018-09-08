using System;
using Xunit;

namespace PseudocodeInterpreter.Tests
{
	public class UnitTest1
	{
		[Fact]
		public void Test_TokenRepresentation_IntegerLit()
		{
			var token = new Token(TokenType.NUMBERLIT, "123");
			
			Assert.Equal("Token(NumberLit, 123)", token.ToString());
		}

		[Fact]
		public void Test_TokenRepresentation_Integer()
		{
			var langManager = new LanguageManager("en");
			
			var token = new Token(TokenType.NUMBER, langManager.Keywords.Number);
			
			Assert.Equal("Token(NUMBER, number)", token.ToString());
		}
	}
}