using System;
namespace Planguage
{
	public class JumpIfNot:BaseInstructions
	{
		int jump_addr;
		public JumpIfNot(SiBtySpace space, int value)
		{
			this._space = space;
			this.jump_addr = value;
		}
		public override void exec()
		{
			if (!((Boolean)this._space.seek().type_cast(Types.Boolean))._value)
				this._space.set_instruction_ptr(this.jump_addr);
		}
	}
}
