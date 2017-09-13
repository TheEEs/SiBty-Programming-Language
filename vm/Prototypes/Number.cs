using System;
namespace Planguage
{
	public struct Number : SibtyObject
	{
		internal int _value;

		public Number(int value = 0)
		{
			_value = value;
		}
		public SibtyObject positive()
		{
			return this;
		}

		public SibtyObject member_setting(SibtyObject key,SibtyObject value) {
			throw new Errors.OperatorError();
		}

		public SibtyObject negative()
		{
			return new Number(-this._value);
		}
		public SibtyObject member_access(SibtyObject value)
		{
			throw new Errors.OperatorError();
		}

		public SibtyObject add(SibtyObject value)
		{
			return new Number() { _value = this._value + ((Number)value.type_cast(Types.Number))._value };
		}

		public SibtyObject bigger(SibtyObject value)
		{
			return new Boolean() { _value = this._value > ((Number)value.type_cast(Types.Number))._value };
		}

		public SibtyObject bigger_or_equal(SibtyObject value)
		{
			return new Boolean() { _value = this._value >= ((Number)value.type_cast(Types.Number))._value };
		}

		public SibtyObject bitwise_and(SibtyObject value)
		{
			return new Number() { _value = this._value & ((Number)value.type_cast(Types.Number))._value };
		}

		public SibtyObject bitwise_not()
		{
			return new Number() { _value = ~this._value };
		}

		public SibtyObject bitwise_or(SibtyObject value)
		{
			return new Number() { _value = this._value | ((Number)value.type_cast(Types.Number))._value };
		}

		public SibtyObject bitwise_xor(SibtyObject value)
		{
			return new Number() { _value = this._value ^ ((Number)value.type_cast(Types.Number))._value };
		}

		public SibtyObject bool_not()
		{
			return new Boolean() { _value = !Convert.ToBoolean(this._value) };
		}

		public SibtyObject different(SibtyObject value)
		{
			return new Boolean() { _value = this._value != ((Number)value.type_cast(Types.Number))._value };
		}

		public SibtyObject div(SibtyObject value)
		{
			return new Number() { _value = this._value / ((Number)value.type_cast(Types.Number))._value };
		}

		public SibtyObject equal(SibtyObject value)
		{
			return new Boolean() { _value = this._value == ((Number)value.type_cast(Types.Number))._value };
		}

		public SibtyObject exponent(SibtyObject value)
		{
			return new Number() { _value = (int)Math.Pow(this._value, ((Number)value.type_cast(Types.Number))._value) };
		}

		public Types get_types()
		{
			return Types.Number;
		}
public SibtyObject function_call()
{
			throw new Errors.OperatorError();
		}
		public SibtyObject logic_and(SibtyObject value)
		{
			return new Boolean() { _value = Convert.ToBoolean(this._value) && Convert.ToBoolean(((Number)value.type_cast(Types.Number))._value) };
		}

		public SibtyObject logic_or(SibtyObject value)
		{
			return new Boolean() { _value = Convert.ToBoolean(this._value) || Convert.ToBoolean(((Number)value.type_cast(Types.Number))._value) };
		}

		public SibtyObject lshift(SibtyObject value)
		{
			return new Number() { _value = this._value << ((Number)value.type_cast(Types.Number))._value };
		}
		public SibtyObject mul(SibtyObject value)
		{
			return new Number() { _value = this._value * ((Number)value.type_cast(Types.Number))._value };
		}

		public SibtyObject remainder(SibtyObject value)
		{
			return new Number() { _value = this._value % ((Number)value.type_cast(Types.Number))._value };
		}

		public SibtyObject rshift(SibtyObject value)
		{
			return new Number() { _value = this._value >> ((Number)value.type_cast(Types.Number))._value };
		}


		public SibtyObject smaller(SibtyObject value)
		{
			return new Boolean() { _value = this._value < ((Number)value.type_cast(Types.Number))._value };
		}

		public SibtyObject smaller_or_equal(SibtyObject value)
		{
			return new Boolean() { _value = this._value <= ((Number)value.type_cast(Types.Number))._value };
		}

		public SibtyObject sub(SibtyObject value)
		{
			return new Number() { _value = this._value - ((Number)value.type_cast(Types.Number))._value };
		}

		public SibtyObject type_cast(Types target_types)
		{
			switch (target_types)
			{
				case (Types.Boolean):
					return new Boolean() { _value = Convert.ToBoolean(this._value) };
				case (Types.Float):
					return new Float() { _value = (float)this._value };
				case (Types.Number):
					return new Number() { _value = this._value };
				case (Types.String):
					return new String(this._value.ToString());
				default: throw new Errors.TypeCastingError();
			}
		}
	}
}
