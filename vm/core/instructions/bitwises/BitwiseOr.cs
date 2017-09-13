using System;
namespace Planguage
{
	public class BitwiseOr:BaseInstructions
	{
		public BitwiseOr(SiBtySpace space)
		{
			this._space = space;
		}
		public override void exec()
		{
			var v2 = this._space.pop_value();//base.exec();
			var v1 = this._space.pop_value();
			this._space.push_value(v1.bitwise_or(v2));
		}
	}
}
