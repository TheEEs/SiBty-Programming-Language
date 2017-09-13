using System;
namespace Planguage
{
	public interface SibtyObject
	{
		Types get_types();
		SibtyObject function_call();
		SibtyObject positive();
		SibtyObject negative();
		SibtyObject member_access(SibtyObject value);
		SibtyObject bool_not();
		SibtyObject bitwise_not();
		SibtyObject exponent(SibtyObject value);
		SibtyObject mul(SibtyObject value);
		SibtyObject div(SibtyObject value);
		SibtyObject remainder(SibtyObject value);
		SibtyObject add(SibtyObject value);
		SibtyObject sub(SibtyObject value);
		SibtyObject lshift(SibtyObject value);
		SibtyObject rshift(SibtyObject value);
		SibtyObject smaller(SibtyObject value);
		SibtyObject smaller_or_equal(SibtyObject value);
		SibtyObject bigger(SibtyObject value);
		SibtyObject bigger_or_equal(SibtyObject value);
		SibtyObject equal(SibtyObject value);
		SibtyObject different(SibtyObject value);
		SibtyObject bitwise_and(SibtyObject value);
		SibtyObject bitwise_or(SibtyObject value);
		SibtyObject bitwise_xor(SibtyObject value);
		SibtyObject logic_and(SibtyObject value);
		SibtyObject logic_or(SibtyObject value);
		SibtyObject type_cast(Types target_types);
		SibtyObject member_setting(SibtyObject key, SibtyObject value);
	}
}
