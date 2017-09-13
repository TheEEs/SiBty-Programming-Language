using System;
namespace Planguage
{
	public class Return:BaseInstructions
	{
		public Return(SiBtySpace space)
		{
			this._space = space;
		}
		public override void exec()
		{
			this._space.set_instruction_ptr(-1);
		}
	}
}
