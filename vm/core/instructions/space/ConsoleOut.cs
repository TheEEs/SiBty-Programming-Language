using System;
namespace Planguage
{
	public class ConsoleOut:BaseInstructions
	{
		int number_of_print = 1;
		public ConsoleOut(SiBtySpace space, int number_of_expression)
		{
			this._space = space;
			this.number_of_print = number_of_expression;
		}
		public override void exec()
		{
			System.Collections.Generic.Stack<SibtyObject> print_stack = new System.Collections.Generic.Stack<SibtyObject>();
			for (int i = 0; i < this.number_of_print; i++)
				print_stack.Push(this._space.pop_value());
			while (print_stack.Count != 1)
				Console.Write(((String)print_stack.Pop().type_cast(Types.String))._value);
			Console.Write(((String)print_stack.Peek().type_cast(Types.String))._value);
			this._space.push_value(print_stack.Peek());
		}
	}
}
