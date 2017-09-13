using System;
namespace Planguage
{
	public class Load : BaseInstructions // load a R-value to expression_stack
	{
		internal SibtyObject _value; internal bool make_a_new_one = true;
		Load new_load= null;
		public Load(SiBtySpace space, SibtyObject value)
		{
			this._value = value;
			this._space = space;
		}

		public Load(Load old_load) {
			this._space = old_load._space;
			this._value = old_load._value;
			this.make_a_new_one = false;
			old_load.new_load = this;
		}
		public override void exec()
		{
			if (this.make_a_new_one && this._value.get_types() == Types.Array)
			{
				var array = new Array(null);
				if (this.new_load != null) this.new_load._value = array;
				this._space.push_value(array);
				return;
			}
			else if (this.make_a_new_one && this._value.get_types() == Types.Hash)
			{
				var hash = new Hash(0);
				if (this.new_load != null) this.new_load._value = hash;
				this._space.push_value(hash);
				return;
			}
			this._space.push_value(this._value);
		}
	}
}
