using System;
namespace Planguage
{
	public class MemberSetting:BaseInstructions
	{
		public MemberSetting(SiBtySpace space)
		{
			this._space = space;
		}
		public override void exec()
		{
			var v3 = this._space.pop_value();
			var v2 = this._space.pop_value();
			var v1 = this._space.pop_value();
			this._space.push_value(v1.member_setting(v2, v3));
		}
	}
}
