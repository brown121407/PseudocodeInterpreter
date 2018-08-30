namespace PseudocodeInterpreter.AST
{
	public class UnaryOpNode : INode
	{
		public Token OP { get; }
		public INode Expr { get; }
		
		public UnaryOpNode(Token OP, INode Expr)
		{
			this.OP = OP;
			this.Expr = Expr;
		}
	}
}