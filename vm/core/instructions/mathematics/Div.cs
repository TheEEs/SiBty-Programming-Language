﻿using System;
namespace Planguage
{
	public class Div:BaseInstructions
	{
		public Div(SiBtySpace space)
		{
			this._space = space;
		}
		public override void exec()
		{
			var v2 = this._space.pop_value();
			var v1 = this._space.pop_value();
			this._space.push_value(v1.div(v2));
		}
	}
}
