using System;
namespace Planguage
{
	public class Positive:BaseInstructions
	{
		public Positive(SiBtySpace space)
		{
			this._space = space;
		}
		public override void exec()
		{
			this._space.push_value(this._space.pop_value().positive());
		}
	}
}
