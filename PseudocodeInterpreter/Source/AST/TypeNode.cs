namespace PseudocodeInterpreter.AST
{
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