using System;
using System.Collections.Generic;
using PseudocodeInterpreter.AST;

namespace PseudocodeInterpreter
{
	public class Parser
	{
		private Lexer _lexer;
		private Token _currentToken;
		public LanguageManager LanguageManager { get; }
		
		public Parser(Lexer lexer)
		{
			_lexer = lexer;
			LanguageManager = lexer.LanguageManager;
			_currentToken = lexer.GetNextToken();
		}

		public ProgramNode Parse()
		{
			return Program();
		}

		private ProgramNode Program()
		{
			var statements = new List<INode>();

			while (_currentToken.Type != TokenType.EOF)
			{
				statements.Add(Stmt());
			}

			return new ProgramNode(statements);
		}

		private INode Stmt()
		{
			switch (_currentToken.Type)
			{
				case TokenType.IF:
				case TokenType.WHILE:
				case TokenType.UNTIL:
				case TokenType.TIMES:
				case TokenType.FUNCTION:
					return CompStmt();
				default:
					return SimpleStmt();
			}
		}

		private INode SimpleStmt()
		{
			var stat = SmallStmt();
			Eat(TokenType.NL);

			return stat;
		}
		
		private INode SmallStmt()
		{
			switch (_currentToken.Type)
			{
				case TokenType.BREAK:
				case TokenType.CONTINUE:
				case TokenType.RETURN:
					return FlowStmt();
				default:
					return ExprStmt();
			}
		}

		private INode ExprStmt()
		{
			throw new NotImplementedException();
		}

		private INode FlowStmt()
		{
			switch (_currentToken.Type)
			{
				case TokenType.BREAK:
					return BreakStmt();
				case TokenType.CONTINUE:
					return ContinueStmt();
				case TokenType.RETURN:
					return ReturnStmt();
				default:
					throw UnexpectedTokenError(_currentToken);
			}
		}

		private INode BreakStmt()
		{
			var node = new BreakNode(_currentToken);
			Eat(TokenType.BREAK);
			return node;
		}

		private ContinueNode ContinueStmt()
		{
			var node = new ContinueNode(_currentToken);
			Eat(TokenType.CONTINUE);
			return node;
		}

		private ReturnNode ReturnStmt()
		{
			var retToken = _currentToken;
			Eat(TokenType.RETURN);

			var testNode = Test();
			var node = new ReturnNode(retToken, testNode);

			return node;
		}

		private CompStmtNode CompStmt()
		{
			switch (_currentToken.Type)
			{
				case TokenType.IF:
					return new CompStmtNode(IfStmt());
				case TokenType.WHILE:
					return new CompStmtNode(WhileStmt());
				case TokenType.UNTIL:
					return new CompStmtNode(UntilStmt());
				case TokenType.TIMES:
					return new CompStmtNode(TimesStmt());
				case TokenType.FUNCTION:
					return new CompStmtNode(Funcdef());
				default:
					throw UnexpectedTokenError(_currentToken);
			}
		}

		private IfNode IfStmt()
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

		private TestNode Test()
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

		private Exception UnexpectedTokenError(Token token) =>
			new Exception(LanguageManager.Messages.UnexpectedToken(token));
	}
}