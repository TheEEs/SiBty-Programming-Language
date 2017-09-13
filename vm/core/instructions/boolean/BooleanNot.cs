using System;
namespace Planguage
{
	public class BooleanNot:BaseInstructions
	{
		public BooleanNot(SiBtySpace space)
		{
			this._space = space;
		}
		public override void exec()
		{
			this._space.push_value(this._space.pop_value().bool_not());
		}
	}
}
