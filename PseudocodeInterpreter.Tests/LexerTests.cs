using Xunit;

namespace PseudocodeInterpreter.Tests
{
	public class LexerTests
	{
		[Fact]
		public void Test_Lexer_NextTokenInteger()
		{
			var langManager = new LanguageManager();
			var expected = new Token(TokenType.Integer, langManager.Keywords.Integer);
			
			var lexer = new Lexer("integer test text 432", langManager);
			
			Assert.Equal(expected, lexer.GetNextToken());
		}
		
		[Fact]
		public void Test_Lexer_NextTokenIntegerLit()
		{
			var langManager = new LanguageManager();
			const string integerLit = "343";
			var expected = new Token(TokenType.IntegerLit, integerLit);
			var input = $"   {integerLit} integer test text";
			
			var lexer = new Lexer(input, langManager);
			
			Assert.Equal(expected, lexer.GetNextToken());
		}
		
		[Fact]
		public void Test_Lexer_NextTokenReal()
		{
			var langManager = new LanguageManager();
			var expected = new Token(TokenType.Real, langManager.Keywords.Real);
			
			var lexer = new Lexer(" real test text 44.55", langManager);
			
			Assert.Equal(expected, lexer.GetNextToken());
		}
		
		[Fact]
		public void Test_Lexer_NextTokenRealLit()
		{
			var langManager = new LanguageManager();
			const string realLit = "44.55";
			var expected = new Token(TokenType.RealLit, realLit);
			var input = $" {realLit} real test text";
			
			var lexer = new Lexer(input, langManager);
			
			Assert.Equal(expected, lexer.GetNextToken());
		}
		
		[Fact]
		public void Test_Lexer_NextTokenText()
		{
			var langManager = new LanguageManager();
			var expected = new Token(TokenType.Text, langManager.Keywords.Text);
			
			var lexer = new Lexer(" text test \"text 44.55\"", langManager);
			
			Assert.Equal(expected, lexer.GetNextToken());
		}
		
		[Fact]
		public void Test_Lexer_NextTokenTextLit()
		{
			var langManager = new LanguageManager();
			const string textLit = "\"weeee\"";
			var expected = new Token(TokenType.TextLit, textLit);
			var input = $" {textLit} real test text  ";
			
			var lexer = new Lexer(input, langManager);
			
			Assert.Equal(expected, lexer.GetNextToken());
		}
		
		[Fact]
		public void Test_Lexer_NextTokenIf()
		{
			var langManager = new LanguageManager();
			var expected = new Token(TokenType.If, langManager.Keywords.If);
			
			var lexer = new Lexer(" if test \"text 44.55\"", langManager);
			
			Assert.Equal(expected, lexer.GetNextToken());
		}
		
		[Fact]
		public void Test_Lexer_NextTokenThen()
		{
			var langManager = new LanguageManager();
			var expected = new Token(TokenType.Then, langManager.Keywords.Then);
			
			var lexer = new Lexer("then test \"text 44.55\"", langManager);
			
			Assert.Equal(expected, lexer.GetNextToken());
		}
		
		[Fact]
		public void Test_Lexer_NextTokenElse()
		{
			var langManager = new LanguageManager();
			var expected = new Token(TokenType.Else, langManager.Keywords.Else);
			
			var lexer = new Lexer("else test \"text 44.55\"", langManager);
			
			Assert.Equal(expected, lexer.GetNextToken());
		}
		
		[Fact]
		public void Test_Lexer_NextTokenElseIf()
		{
			var langManager = new LanguageManager();
			var expected = new Token(TokenType.ElseIf, langManager.Keywords.ElseIf);
			
			var lexer = new Lexer("else if test \"text 44.55\"", langManager);
			
			Assert.Equal(expected, lexer.GetNextToken());
		}
		
		[Fact]
		public void Test_Lexer_NextTokenWhile()
		{
			var langManager = new LanguageManager();
			var expected = new Token(TokenType.While, langManager.Keywords.While);
			
			var lexer = new Lexer("while test \"text 44.55\"", langManager);
			
			Assert.Equal(expected, lexer.GetNextToken());
		}
		
		[Fact]
		public void Test_Lexer_NextTokenUntil()
		{
			var langManager = new LanguageManager();
			var expected = new Token(TokenType.Until, langManager.Keywords.Until);
			
			var lexer = new Lexer("until test \"text 44.55\"", langManager);
			
			Assert.Equal(expected, lexer.GetNextToken());
		}
		
		[Fact]
		public void Test_Lexer_NextTokenTimes()
		{
			var langManager = new LanguageManager();
			var expected = new Token(TokenType.Times, langManager.Keywords.Times);
			
			var lexer = new Lexer("times test \"text 44.55\"", langManager);
			
			Assert.Equal(expected, lexer.GetNextToken());
		}
		
		[Fact]
		public void Test_Lexer_NextTokenDo()
		{
			var langManager = new LanguageManager();
			var expected = new Token(TokenType.Do, langManager.Keywords.Do);
			
			var lexer = new Lexer("do test \"text 44.55\"", langManager);
			
			Assert.Equal(expected, lexer.GetNextToken());
		}
		
		[Fact]
		public void Test_Lexer_NextTokenEnd()
		{
			var langManager = new LanguageManager();
			var expected = new Token(TokenType.End, langManager.Keywords.End);
			
			var lexer = new Lexer("end test \"text 44.55\"", langManager);
			
			Assert.Equal(expected, lexer.GetNextToken());
		}
		
		[Fact]
		public void Test_Lexer_NextTokenFunction()
		{
			var langManager = new LanguageManager();
			var expected = new Token(TokenType.Function, langManager.Keywords.Function);
			
			var lexer = new Lexer("function test \"text 44.55\"", langManager);
			
			Assert.Equal(expected, lexer.GetNextToken());
		}
		
		[Fact]
		public void Test_Lexer_NextTokenReturn()
		{
			var langManager = new LanguageManager();
			var expected = new Token(TokenType.Return, langManager.Keywords.Return);
			
			var lexer = new Lexer("return test \"text 44.55\"", langManager);
			
			Assert.Equal(expected, lexer.GetNextToken());
		}
		
		[Fact]
		public void Test_Lexer_NextTokenWrite()
		{
			var langManager = new LanguageManager();
			var expected = new Token(TokenType.Write, langManager.Builtins.Write);
			
			var lexer = new Lexer("write test \"text 44.55\"", langManager);
			
			Assert.Equal(expected, lexer.GetNextToken());
		}
		
		[Fact]
		public void Test_Lexer_NextTokenWriteLine()
		{
			var langManager = new LanguageManager();
			var expected = new Token(TokenType.WriteLine, langManager.Builtins.WriteLine);
			
			var lexer = new Lexer("writeLine test \"text 44.55\"", langManager);
			
			Assert.Equal(expected, lexer.GetNextToken());
		}
		
		[Fact]
		public void Test_Lexer_NextTokenRead()
		{
			var langManager = new LanguageManager();
			var expected = new Token(TokenType.Read, langManager.Builtins.Read);
			
			var lexer = new Lexer("read test \"text 44.55\"", langManager);
			
			Assert.Equal(expected, lexer.GetNextToken());
		}
		
		[Fact]
		public void Test_Lexer_NextTokenToText()
		{
			var langManager = new LanguageManager();
			var expected = new Token(TokenType.ToText, langManager.Builtins.ToText);
			
			var lexer = new Lexer("toText test \"text 44.55\"", langManager);
			
			Assert.Equal(expected, lexer.GetNextToken());
		}
		
		[Fact]
		public void Test_Lexer_NextTokenLength()
		{
			var langManager = new LanguageManager();
			var expected = new Token(TokenType.Length, langManager.Builtins.Length);
			
			var lexer = new Lexer("length test \"text 44.55\"", langManager);
			
			Assert.Equal(expected, lexer.GetNextToken());
		}
	}
}