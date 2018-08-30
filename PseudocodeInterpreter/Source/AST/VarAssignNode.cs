namespace PseudocodeInterpreter.AST
{
	public class VarAssignNode : INode
	{
		public Token ID { get; }
		public Token ASSIGN { get; }
		public INode Expr { get; }


		public VarAssignNode(Token ID, Token ASSIGN, INode Expr)
		{
			this.ID = ID;
			this.ASSIGN = ASSIGN;
			this.Expr = Expr;
		}
	}
}