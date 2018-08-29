using System;
using Xunit;

namespace PseudocodeInterpreter.Tests
{
	public class UnitTest1
	{
		[Fact]
		public void Test_TokenRepresentation_IntegerLit()
		{
			var token = new Token(TokenType.IntegerLit, "123");
			
			Assert.Equal("Token(IntegerLit, 123)", token.ToString());
		}

		[Fact]
		public void Test_TokenRepresentation_Integer()
		{
			var langManager = new LanguageManager("en");
			
			var token = new Token(TokenType.INTEGER, langManager.Keywords.Integer);
			
			Assert.Equal("Token(INTEGER, integer)", token.ToString());
		}
	}
}