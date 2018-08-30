namespace PseudocodeInterpreter.AST
{
	public class AssignNode : INode
	{
		public Token OP { get; }
		public INode Left { get; }
		public INode Right { get; }
		
		public AssignNode(INode Left, Token OP, INode Right)
		{
			this.Left = Left;
			this.OP = OP;
			this.Right = Right;
		}
	}
}