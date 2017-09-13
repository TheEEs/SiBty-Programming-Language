using System;
using System.Collections.Generic;
namespace Planguage
{
	public class FunctionCall:BaseInstructions
	{
		int number_of_arg;
		public FunctionCall(SiBtySpace space, int number_of_arg)
		{
			this._space = space;
			this.number_of_arg = number_of_arg;
		}
		public override void exec()
		{
			//Stack - vao truoc dung dau
			//Queue - vao sau dung dau
			var function = (BaseFunction)this._space.pop_value().type_cast(Types.Function);
			if (this.number_of_arg != function.number_of_params) {
				throw new Errors.ParameterError(this.number_of_arg < function.number_of_params ? true : false);
			}
			Stack<SibtyObject> q_of_sib = new Stack<SibtyObject>();
			for (int i = 0; i < this.number_of_arg; i++)
				q_of_sib.Push(this._space.pop_value());
			function.set_params(q_of_sib.ToArray());
			this._space.push_value(function.function_call());
		}
	}
}
