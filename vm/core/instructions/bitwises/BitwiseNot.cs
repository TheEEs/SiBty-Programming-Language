using System;
namespace Planguage
{
	public class BitwiseNot:BaseInstructions
	{
		public BitwiseNot(SiBtySpace space)
		{
			this._space = space;
		}
		public override void exec()
		{
			this._space.push_value(this._space.pop_value().bitwise_not());
		}
	}
}
