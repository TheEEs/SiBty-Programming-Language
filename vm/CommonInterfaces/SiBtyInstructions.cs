using System;
namespace Planguage
{
	public interface SiBtyInstructions
	{
		
		void get_value_from_identifier(string name);
		void go_to(params SibtyObject[] p);
		void go_if_not(params SibtyObject[] p);
		void function_call(params SibtyObject[] p);
		void member_access(params SibtyObject[] p);
		void bool_not(params SibtyObject[] p);
		void bitwise_not(params SibtyObject[] p);
		void exponent(params SibtyObject[] p);
		void mul(params SibtyObject[] p);
		void div(params SibtyObject[] p);
		void remainder(params SibtyObject[] p);
		void add(params SibtyObject[] p);
		void sub(params SibtyObject[] p);
		void lshift(params SibtyObject[] p);
		void rshift(params SibtyObject[] p);
		void smaller(params SibtyObject[] p);
		void smailler_or_equal(params SibtyObject[] p);
		void bigger(params SibtyObject[] p);
		void bigger_or_equal(params SibtyObject[] p);
		void equal(params SibtyObject[] p);
		void different(params SibtyObject[] p);
		void bitwise_and(params SibtyObject[] p);
		void bitwise_or(params SibtyObject[] p);
		void bitwise_xor(params SibtyObject[] p);
		void logic_and(params SibtyObject[] p);
		void logic_or(params SibtyObject[] p);
	}
}
