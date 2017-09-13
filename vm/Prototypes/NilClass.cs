using System;
using Planguage.Errors;
namespace Planguage
{
	public struct NilClass : SibtyObject
	{
		public SibtyObject member_access(SibtyObject value)
		{
			throw new Errors.OperatorError();
		}
		public SibtyObject add(SibtyObject value)
		{
			throw new Errors.NilClassException();
		}
		public SibtyObject positive()
		{
			throw new OperatorError();
		}
		public SibtyObject function_call()
		{
			throw new OperatorError();
		}
		public SibtyObject negative()
		{
			throw new OperatorError();
		}
		public SibtyObject bigger(SibtyObject value)
		{
			throw new Errors.NilClassException();
		}

		public SibtyObject member_setting(SibtyObject key, SibtyObject value) {
			throw new Errors.OperatorError();
		}

		public SibtyObject bigger_or_equal(SibtyObject value)
		{
			throw new Errors.NilClassException();
		}

		public SibtyObject bitwise_and(SibtyObject value)
		{
			throw new Errors.NilClassException();
		}

		public SibtyObject bitwise_not()
		{
			throw new Errors.NilClassException();
		}

		public SibtyObject bitwise_or(SibtyObject value)
		{
			throw new Errors.NilClassException();
		}

		public SibtyObject bitwise_xor(SibtyObject value)
		{
			throw new Errors.NilClassException();
		}

		public SibtyObject bool_not()
		{
			return new Boolean() { _value = true };
		}

		public SibtyObject different(SibtyObject value)
		{
			return new Boolean() { _value = value.get_types() != Types.Nil };
		}

		public SibtyObject div(SibtyObject value)
		{
			throw new Errors.NilClassException();
		}

		public SibtyObject equal(SibtyObject value)
		{
			return new Boolean() { _value = value.get_types() == Types.Nil };
		}

		public SibtyObject exponent(SibtyObject value)
		{
			throw new Errors.NilClassException();
		}

		public Types get_types()
		{
			return Types.Nil;
		}

		public SibtyObject logic_and(SibtyObject value)
		{
			return new Boolean() { _value = false };
		}

		public SibtyObject logic_or(SibtyObject value)
		{
			return new Boolean() { _value = ((Boolean)value.type_cast(Types.Boolean))._value };
		}

		public SibtyObject lshift(SibtyObject value)
		{
			throw new Errors.NilClassException();
		}

		public SibtyObject mul(SibtyObject value)
		{
			throw new Errors.NilClassException();
		}

		public SibtyObject remainder(SibtyObject value)
		{
			throw new Errors.NilClassException();
		}

		public SibtyObject rshift(SibtyObject value)
		{
			throw new Errors.NilClassException();
		}


		public SibtyObject smaller(SibtyObject value)
		{
			throw new Errors.NilClassException();
		}

		public SibtyObject smaller_or_equal(SibtyObject value)
		{
			throw new Errors.NilClassException();
		}

		public SibtyObject sub(SibtyObject value)
		{
			throw new Errors.NilClassException();
		}

		public SibtyObject type_cast(Types target_types)
		{
			switch (target_types)
			{
				case (Types.Boolean):
					return new Boolean() { _value = false };
				case (Types.Nil):
					return new NilClass();
				case (Types.String):
					return new String("nil");
				default:
					throw new Errors.TypeCastingError();
			}
		}
	}
}
