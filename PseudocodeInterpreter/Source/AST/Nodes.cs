using System.Collections.Generic;

namespace PseudocodeInterpreter.AST
{
	public interface INode
	{
	}

	public class ProgramNode : INode
	{
		public List<INode> Statements { get; }

		public ProgramNode(List<INode> statements)
		{
			Statements = statements;
		}
	}

	public class BreakNode : INode
	{
		public Token BREAK { get; }
		public BreakNode(Token BREAK)
		{
			this.BREAK = BREAK;
		}
	}

	public class ContinueNode : INode
	{
		public Token CONTINUE { get; }
		public ContinueNode(Token CONTINUE)
		{
			this.CONTINUE = CONTINUE;
		}
	}

	public class ReturnNode : INode
	{
		public Token RETURN { get; }
		public TestNode Test { get; }

		public ReturnNode(Token RETURN, TestNode test)
		{
			this.RETURN = RETURN;
			Test = test;
		}
	}

	public class CompStmtNode : INode
	{
		public IfNode If { get; }
		public WhileNode While { get; }
		public UntilNode Until { get; }
		public TimesNode Times { get; }
		public FuncdefNode Funcdef { get; }

		public CompStmtNode(INode node)
		{
			switch (node)
			{
				case IfNode ifNode:
					If = ifNode;
					break;
				case WhileNode whileNode:
					While = whileNode;
					break;
				case UntilNode untilNode:
					Until = untilNode;
					break;
				case TimesNode timesNode:
					Times = timesNode;
					break;
				case FuncdefNode funcdef:
					Funcdef = funcdef;
					break;
			}
		}
	}

	public class IfNode : INode
	{
		public TestNode[] Tests { get; }
		public SuiteNode[] Suites { get; }

		public bool HasElse { get; }

		public IfNode(TestNode[] tests, SuiteNode[] suites, bool hasElse)
		{
			HasElse = hasElse;
			Tests = tests;
			Suites = suites;
		}
	}

	public class WhileNode : INode
	{
		public TestNode Test { get; }
		public SuiteNode Suite { get; }

		public WhileNode(TestNode test, SuiteNode suite)
		{
			Test = test;
			Suite = suite;
		}
	}

	public class UntilNode : INode
	{
		public TestNode Test { get; }
		public SuiteNode Suite { get; }

		public UntilNode(TestNode test, SuiteNode suite)
		{
			Test = test;
			Suite = suite;
		}
	}

	public class TimesNode : INode
	{
		
	}

	public class FuncdefNode : INode
	{

	}

	public class SuiteNode : INode
	{

	}

	public class TestNode : INode
	{

	}

	public class TypeNode : INode
	{
		public Token TYPE { get; }
		public string Value { get; }

		public TypeNode(Token TYPE)
		{
			this.TYPE = TYPE;
			Value = TYPE.Value;
		}
	}
}
