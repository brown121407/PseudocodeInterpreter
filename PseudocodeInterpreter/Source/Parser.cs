using System;
using PseudocodeInterpreter.AST;

namespace PseudocodeInterpreter
{
	public class Parser
	{
		private Lexer _lexer;
		private Token _currentToken;
		
		public Parser(Lexer lexer)
		{
			_lexer = lexer;
			_currentToken = lexer.GetNextToken();
		}

		public ProgramNode Parse()
		{
			var node = Program();

			if (_currentToken.Type != TokenType.EOF)
			{
				// TODO: syntax error
			}
			
			return node;
		}

		private ProgramNode Program()
		{
			throw new NotImplementedException();	
		}

		private INode Stmt()
		{
			throw new NotImplementedException();	
		}

		private INode SimpleStmt()
		{
			throw new NotImplementedException();	
		}
		
		private INode SmallStmt()
		{
			throw new NotImplementedException();	
		}

		private INode ExprStmt()
		{
			throw new NotImplementedException();
		}

		private INode FlowStmt()
		{
			throw new NotImplementedException();
		}

		private INode BreakStmt()
		{
			throw new NotImplementedException();
		}

		private INode ContinueStmt()
		{
			throw new NotImplementedException();
		}

		private INode ReturnStmt()
		{
			throw new NotImplementedException();
		}

		private INode CompStmt()
		{
			throw new NotImplementedException();
		}

		private INode IfStmt()
		{
			throw new NotImplementedException();
		}

		private INode WhileStmt()
		{
			throw new NotImplementedException();
		}

		private INode UntilStmt()
		{
			throw new NotImplementedException();
		}

		private INode TimesStmt()
		{
			throw new NotImplementedException();
		}

		private INode Funcdef()
		{
			throw new NotImplementedException();
		}

		private INode Suite()
		{
			throw new NotImplementedException();
		}

		private INode Test()
		{
			throw new NotImplementedException();
		}

		private INode OrTest()
		{
			throw new NotImplementedException();
		}

		private INode AndTest()
		{
			throw new NotImplementedException();
		}

		private INode NotTest()
		{
			throw new NotImplementedException();
		}

		private INode Comparison()
		{
			throw new NotImplementedException();
		}

		private INode CompOp()
		{
			throw new NotImplementedException();
		}

		private INode Expr()
		{
			throw new NotImplementedException();
		}

		private INode XorExpr()
		{
			throw new NotImplementedException();
		}

		private INode AndExpr()
		{
			throw new NotImplementedException();
		}

		private INode ShiftExpr()
		{
			throw new NotImplementedException();
		}

		private INode ArithExpr()
		{
			throw new NotImplementedException();
		}

		private INode Term()
		{
			throw new NotImplementedException();
		}

		private INode Factor()
		{
			throw new NotImplementedException();
		}

		private INode Power()
		{
			throw new NotImplementedException();
		}

		private INode AtomExpr()
		{
			throw new NotImplementedException();
		}

		private INode Atom()
		{
			throw new NotImplementedException();
		}

		private INode Trailer()
		{
			throw new NotImplementedException();
		}

		private INode TestList()
		{
			throw new NotImplementedException();
		}

		private INode FormalParams()
		{
			throw new NotImplementedException();
		}

		private INode Type()
		{
			throw new NotImplementedException();
		}

		private INode ArgList()
		{
			throw new NotImplementedException();
		}

		private INode Subscript()
		{
			throw new NotImplementedException();
		}

		private INode SliceOp()
		{
			throw new NotImplementedException();
		}

		private INode VarDecl()
		{
			throw new NotImplementedException();
		}

		private INode VarAssign()
		{
			throw new NotImplementedException();
		}


		private void Eat(TokenType tokenType)
		{
			if (_currentToken.Type == tokenType)
			{
				_currentToken = _lexer.GetNextToken();
			}
			else
			{
				// TODO: syntax error
			}
		}
	}
}