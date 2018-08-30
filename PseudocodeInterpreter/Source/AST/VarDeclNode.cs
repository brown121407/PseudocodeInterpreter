namespace PseudocodeInterpreter.AST
{
	public class VarDeclNode : INode
	{
		public INode Type { get; }
		public Token ID { get; }
		public Token ASSIGN { get; }
		public INode Expr { get; }
		
		public VarDeclNode(INode type, Token id, Token assign, INode expr)
		{
			Type = type;
			ID = id;
			ASSIGN = assign;
			Expr = expr;
		}
	}
}