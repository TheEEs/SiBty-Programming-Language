using System;
namespace Planguage
{
	public class Different:BaseInstructions
	{
		public Different(SiBtySpace space)
		{
			this._space = space;
		}
		public override void exec()
		{
			var v2 = this._space.pop_value();
			var v1 = this._space.pop_value();
			this._space.push_value(v1.different(v2));
		}
	}
}
