using System;
namespace Planguage
{
	public class ExternalFunction : BaseFunction
	{
		public delegate void __function__(ExternalFunction func);
		__function__ __fnc__;
		public SibtyObject this[string name]{
			get{
				return this.load_var(name);
			}
		}
		public ExternalFunction(SiBtySpace parent_space,  __function__ func_, params string[] param_names):base(parent_space,param_names)
		{
			this.__fnc__ = func_;
            this._return_value = new NilClass();
		}
		public override void exec()
		{
			this.__fnc__(this);
		}

		public override SibtyObject function_call()
		{
			this.exec();
			return this._return_value;
		}
	}
}
