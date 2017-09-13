using System;
using Planguage.Errors;
namespace Planguage
{
	public class Load_Var:BaseInstructions //Load variables from identifier pool to expression_stack
	{
		string var_name;

		public Load_Var(SiBtySpace space, string var_name)
		{
			this._space = space;
			this.var_name = var_name;
		}

		public override void exec()
		{
			this._space.push_value(this._space.load_var(this.var_name));
		}
	}
}
