namespace PseudocodeInterpreter.AST
{
	public class ProgramNode : INode
	{
		public INode Block { get; }
		
		public ProgramNode(INode Block)
		{
			this.Block = Block;
		}
	}
}