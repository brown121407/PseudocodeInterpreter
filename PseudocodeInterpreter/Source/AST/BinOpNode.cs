namespace PseudocodeInterpreter.AST
{
	public class BinOpNode : INode
	{
		public Token OP { get; }
		public INode Left { get; }
		public INode Right { get; }
		
		public BinOpNode(INode Left, Token OP, INode Right)
		{
			this.Left = Left;
			this.OP = OP;
			this.Right = Right;
		}
	}
}