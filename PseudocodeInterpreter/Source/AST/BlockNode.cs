using System.Collections.Generic;

namespace PseudocodeInterpreter.AST
{
	public class BlockNode : INode
	{
		public List<INode> Children { get; } = new List<INode>();
	}
}