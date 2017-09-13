using System;
namespace Planguage
{
	public class Assign:BaseInstructions
	{
		string id;
		public Assign(SiBtySpace space,string id)
		{
			this.id = id;
			this._space = space;
		}
		public override void exec()
		{
			this._space.assign(this.id, this._space.seek());
		}
	}
}
