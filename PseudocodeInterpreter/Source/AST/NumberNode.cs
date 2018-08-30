namespace PseudocodeInterpreter.AST
{
	public class NumberNode : INode
	{
		public Token NUMBER { get; }
		public double Value { get; }

		public NumberNode(Token NUMBER)
		{
			this.NUMBER = NUMBER;
			Value = double.Parse(NUMBER.Value);
		}
	}
}