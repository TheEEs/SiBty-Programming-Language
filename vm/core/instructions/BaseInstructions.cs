using System;
namespace Planguage
{
	public class BaseInstructions: SiBtyInstruction
	{
		protected SiBtySpace _space;
		public virtual void change_value() { }
		public virtual void exec()
		{
			throw new NotImplementedException();
		}
	}
}
