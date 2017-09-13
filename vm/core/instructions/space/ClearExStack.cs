using System;
namespace Planguage
{
	public class PopStack:BaseInstructions
	{
		public PopStack(SiBtySpace space)
		{
			this._space = space;
		}
		public override void exec()
		{
			this._space.pop_value();
		}
	}
}
