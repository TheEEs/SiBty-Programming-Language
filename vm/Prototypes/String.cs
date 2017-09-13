using System;
using Planguage.Errors;
namespace Planguage
{
	public struct String : SibtyObject
	{

		internal string _value;

		public String(string value = "")
		{
			this._value = value;
		}

public SibtyObject function_call()
{
			throw new OperatorError();
		}

		public SibtyObject positive()
		{
			throw new OperatorError();
		}

		public SibtyObject member_setting(SibtyObject key, SibtyObject value) {
			throw new OperatorError();
		}

		public SibtyObject negative()
		{
			throw new OperatorError();
		}
		public SibtyObject add(SibtyObject value)
		{
			return new String() { _value = this._value + ((String)value.type_cast(Types.String))._value };
		}

		public SibtyObject bigger(SibtyObject value)
		{
			return new Boolean() { _value = System.String.Compare(this._value, ((String)value.type_cast(Types.String))._value) > 0 };
		}

		public SibtyObject bigger_or_equal(SibtyObject value)
		{
			return new Boolean() { _value = System.String.Compare(this._value, ((String)value.type_cast(Types.String))._value) >= 0 };
		}

		public SibtyObject bitwise_and(SibtyObject value)
		{
			throw new OperatorError();
		}

		public SibtyObject bitwise_not()
		{
			throw new OperatorError();
		}

		public SibtyObject bitwise_or(SibtyObject value)
		{
			throw new OperatorError();
		}

		public SibtyObject bitwise_xor(SibtyObject value)
		{
			throw new OperatorError();
		}

		public SibtyObject bool_not()
		{
			return new Boolean() { _value = false };
		}

		public SibtyObject different(SibtyObject value)
		{
			return new Boolean() { _value = this._value != ((String)value.type_cast(Types.String))._value };
		}

		public SibtyObject div(SibtyObject value)
		{
			throw new OperatorError();
		}

		public SibtyObject equal(SibtyObject value)
		{
			return new Boolean() { _value = this._value == ((String)value.type_cast(Types.String))._value };
		}

		public SibtyObject exponent(SibtyObject value)
		{
			throw new OperatorError();
		}

		public Types get_types()
		{
			return Types.String;
		}

		public SibtyObject logic_and(SibtyObject value)
		{
			return new Boolean() { _value = ((Boolean)value.type_cast(Types.Boolean))._value };
		}

		public SibtyObject logic_or(SibtyObject value)
		{
			return new Boolean() { _value = true };
		}

		public SibtyObject lshift(SibtyObject value)
		{
			String x = ((String)value.type_cast(Types.String));
			this._value = this._value + x._value;
			return new String() { _value = this._value };
		}

		public SibtyObject member_access(SibtyObject value)
		{
			switch (value.get_types())
			{
				case (Types.Number):
					return new String() { _value = this._value[((Number)value.type_cast(Types.Number))._value].ToString() };
				case(Types.String):
					return this;
				default:
					throw new TypeCastingError();
			}
		}

		public SibtyObject mul(SibtyObject value)
		{
			throw new OperatorError();
		}

		public SibtyObject remainder(SibtyObject value)
		{
			throw new Errors.OperatorError();
		}

		public SibtyObject rshift(SibtyObject value)
		{
			throw new OperatorError();
		}

		public SibtyObject smaller(SibtyObject value)
		{
			return new Boolean() { _value = System.String.Compare(this._value, ((String)value.type_cast(Types.String))._value) < 0 };
		}

		public SibtyObject smaller_or_equal(SibtyObject value)
		{
			return new Boolean() { _value = System.String.Compare(this._value, ((String)value.type_cast(Types.String))._value) <= 0 };
		}

		public SibtyObject sub(SibtyObject value)
		{
			throw new OperatorError();
		}

		public SibtyObject type_cast(Types target_types)
		{
			switch (target_types)
			{
				case (Types.Boolean):
					return new Boolean() { _value = true };
				case (Types.String):
					return new String() { _value = this._value };
				default: throw new TypeCastingError();
			}
		}
	}
}
