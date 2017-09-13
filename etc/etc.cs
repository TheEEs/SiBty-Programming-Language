using System;
using System.Collections.Generic;
namespace Planguage
{
	public static class etc
	{
		public static void pop(this List<Antlr4.Runtime.ParserRuleContext> stack_list) {
			stack_list.RemoveAt(stack_list.Count - 1);
		}

	}
}
