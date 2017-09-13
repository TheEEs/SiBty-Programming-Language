using System;
using Planguage.Errors;
namespace Planguage
{
	public struct Boolean : SibtyObject
	{
		internal bool _value;
		public Boolean(bool value = false)
		{
			this._value = value;
		}

		public SibtyObject positive() {
			throw new OperatorError();
		}
		public SibtyObject function_call() {
			throw new OperatorError();
		}
		public SibtyObject negative() {
			throw new OperatorError();
		}

		public SibtyObject member_setting(SibtyObject key,SibtyObject value) {
			throw new Planguage.Errors.OperatorError();
		}

		public SibtyObject member_access(SibtyObject value)
		{
			throw new Errors.OperatorError();
		}
		public SibtyObject add(SibtyObject value)
		{
			throw new OperatorError();
		}

		public SibtyObject bigger(SibtyObject value)
		{
			throw new OperatorError();
		}

		public SibtyObject bigger_or_equal(SibtyObject value)
		{
			throw new OperatorError();
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
			return new Boolean() { _value = !this._value };
		}

		public SibtyObject different(SibtyObject value)
		{
			return new Boolean() { _value = this._value != ((Boolean)value.type_cast(Types.Boolean))._value };
		}

		public SibtyObject div(SibtyObject value)
		{
			throw new OperatorError();
		}

		public SibtyObject equal(SibtyObject value)
		{
			return new Boolean() { _value = this._value == ((Boolean)value.type_cast(Types.Boolean))._value };
		}

		public SibtyObject exponent(SibtyObject value)
		{
			throw new OperatorError();
		}

		public Types get_types()
		{
			return Types.Boolean;
		}

		public SibtyObject logic_and(SibtyObject value)
		{
			return new Boolean() { _value = this._value && ((Boolean)value.type_cast(Types.Boolean))._value };
		}

		public SibtyObject logic_or(SibtyObject value)
		{
			return new Boolean() { _value = this._value || ((Boolean)value.type_cast(Types.Boolean))._value };
		}

		public SibtyObject lshift(SibtyObject value)
		{
			throw new OperatorError();
		}

		public SibtyObject mul(SibtyObject value)
		{
			throw new OperatorError();
		}

		public SibtyObject remainder(SibtyObject value)
		{
			throw new OperatorError();
		}

		public SibtyObject rshift(SibtyObject value)
		{
			throw new OperatorError();
		}

		public SibtyObject smaller(SibtyObject value)
		{
			throw new OperatorError();
		}

		public SibtyObject smaller_or_equal(SibtyObject value)
		{
			throw new OperatorError();
		}

		public SibtyObject sub(SibtyObject value)
		{
			throw new OperatorError();
		}

		public SibtyObject type_cast(Types target_types)
		{
			switch (target_types)
			{
				case (Types.Array): throw new TypeCastingError();
				case (Types.Boolean): return new Boolean() { _value = this._value };
				case (Types.Float): throw new TypeCastingError();
				case (Types.Hash): throw new TypeCastingError();
				case (Types.Nil): throw new TypeCastingError();
				case (Types.Number): return new Number() { _value = Convert.ToInt32(this._value) };
				case (Types.String):
					return new String(this._value ? "true" : "false");
				default:throw new Errors.TypeCastingError();
			}
		}
	}
}
