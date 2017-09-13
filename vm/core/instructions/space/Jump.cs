using System;
namespace Planguage
{
	public class Jump:BaseInstructions
	{
		int goto_addr;
		public Jump(SiBtySpace space, int value)
		{
			this._space = space;
			this.goto_addr = value;
		}
		public override void exec()
		{
			this._space.set_instruction_ptr(this.goto_addr);
		}
	}
}
