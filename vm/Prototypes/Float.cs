using System;
using Planguage.Errors;
namespace Planguage
{
	public struct Float : SibtyObject
	{
		internal float _value;
		public Float(float value = 0f)
		{
			_value = value;
		}


		public SibtyObject positive()
		{
			return this;
		}
		public SibtyObject function_call()
{
			throw new OperatorError();
		}
		public SibtyObject negative()
		{
			return new Float(-this._value);
		}

		public SibtyObject member_access(SibtyObject value)
		{
			throw new Errors.OperatorError();
		}

		public SibtyObject member_setting(SibtyObject key,SibtyObject value) {
			throw new Errors.OperatorError();
		}

		public SibtyObject add(SibtyObject value)
		{
			return new Float() { _value = this._value + ((Float)value.type_cast(Types.Float))._value };
		}

		public SibtyObject bigger(SibtyObject value)
		{
			return new Boolean() { _value = this._value > ((Float)value.type_cast(Types.Float))._value };
		}

		public SibtyObject bigger_or_equal(SibtyObject value)
		{
			return new Boolean() { _value = this._value >= ((Float)value.type_cast(Types.Float))._value };
		}

		public SibtyObject bitwise_and(SibtyObject value)
		{
			throw new Errors.OperatorError();
		}

		public SibtyObject bitwise_not()
		{
			throw new Errors.OperatorError();
		}

		public SibtyObject bitwise_or(SibtyObject value)
		{
			throw new Errors.OperatorError();
		}

		public SibtyObject bitwise_xor(SibtyObject value)
		{
			throw new Errors.OperatorError();
		}

		public SibtyObject bool_not()
		{
			return new Boolean() { _value = Convert.ToBoolean(this._value) };
		}

		public SibtyObject different(SibtyObject value)
		{
			return new Boolean() { _value = this._value != ((Float)value.type_cast(Types.Float))._value };
		}

		public SibtyObject div(SibtyObject value)
		{
			return new Float() { _value = this._value / ((Float)value.type_cast(Types.Float))._value };
		}

		public SibtyObject equal(SibtyObject value)
		{
			return new Boolean() { _value = this._value == ((Float)value.type_cast(Types.Float))._value };
		}

		public SibtyObject exponent(SibtyObject value)
		{
			return new Float() { _value = (float)Math.Pow(this._value, ((Float)value.type_cast(Types.Float))._value) };
		}

		public Types get_types()
		{
			return Types.Float;
		}

		public SibtyObject logic_and(SibtyObject value)
		{
			return new Boolean() { _value = Convert.ToBoolean(this._value) && Convert.ToBoolean(((Float)value.type_cast(Types.Float))._value) };
		}

		public SibtyObject logic_or(SibtyObject value)
		{
			return new Boolean() { _value = Convert.ToBoolean(this._value) || Convert.ToBoolean(((Float)value.type_cast(Types.Float))._value) };
		}

		public SibtyObject lshift(SibtyObject value)
		{
			throw new Errors.TypeCastingError();
		}
		public SibtyObject mul(SibtyObject value)
		{
			return new Float() { _value = this._value * ((Float)value.type_cast(Types.Float))._value };
		}

		public SibtyObject remainder(SibtyObject value)
		{
			return new Float() { _value = this._value % ((Float)value.type_cast(Types.Float))._value };
		}

		public SibtyObject rshift(SibtyObject value)
		{
			throw new Errors.TypeCastingError();
		}

		public SibtyObject smaller(SibtyObject value)
		{
			return new Boolean() { _value = this._value < ((Float)value.type_cast(Types.Float))._value };
		}

		public SibtyObject smaller_or_equal(SibtyObject value)
		{
			return new Boolean() { _value = this._value <= ((Float)value.type_cast(Types.Float))._value };
		}

		public SibtyObject sub(SibtyObject value)
		{
			return new Float() { _value = this._value - ((Float)value.type_cast(Types.Float))._value };
		}

		public SibtyObject type_cast(Types target_types)
		{
			switch (target_types)
			{
				case (Types.Boolean):
					return new Boolean() { _value = Convert.ToBoolean(this._value) };
				case (Types.Float):
					return new Float() { _value = this._value };
				case (Types.Number):
					return new Number() { _value = Convert.ToInt32(this._value) };
				case (Types.String):
					return new String(this._value.ToString());
				default: throw new Errors.TypeCastingError();
			}
		}
	}
}
