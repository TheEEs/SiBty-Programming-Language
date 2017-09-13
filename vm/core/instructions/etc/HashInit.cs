using System;
namespace Planguage
{
	public class HashInit:BaseInstructions
	{
		public HashInit(SiBtySpace space)
		{
			this._space = space;
		}
		public override void exec()
		{
			var value = this._space.pop_value();
			var key = this._space.pop_value();
			var hash = (Hash)this._space.seek().type_cast(Types.Hash);
			hash._value[key] = value;
		}
	}
}
