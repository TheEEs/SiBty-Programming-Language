using System;
using System.Collections.Generic;
using Planguage.Errors;
namespace Planguage
{
	public struct Hash : SibtyObject
	{
		internal Dictionary<SibtyObject, SibtyObject> _value;
		public Hash(int you_dont_need_to_care_about_this_fucking_parameter = 0)
		{
			this._value = new Dictionary<SibtyObject, SibtyObject>();
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
		public SibtyObject add(SibtyObject value)
		{
			throw new OperatorError();
		}
		public SibtyObject member_setting(SibtyObject key, SibtyObject value) {
			if (this._value.ContainsKey(key))
				return this._value[key] = value;
			else
				throw new Errors.VariableError();
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
			return new Boolean(false);
		}

		public SibtyObject different(SibtyObject value)
		{
			throw new OperatorError();
		}

		public SibtyObject div(SibtyObject value)
		{
			throw new OperatorError();
		}

		public SibtyObject equal(SibtyObject value)
		{
			throw new OperatorError();
		}

		public SibtyObject exponent(SibtyObject value)
		{
			throw new OperatorError();
		}

		public Types get_types()
		{
			return Types.Hash;
		}

		public SibtyObject logic_and(SibtyObject value)
		{
			return new Boolean(((Boolean)value.type_cast(Types.Boolean))._value);
		}

		public SibtyObject logic_or(SibtyObject value)
		{
			return new Boolean(true);
		}

		public SibtyObject lshift(SibtyObject value)
		{
			throw new OperatorError();
		}

		public SibtyObject member_access(SibtyObject value)
		{
			if (this._value.ContainsKey(value))
				return this._value[value];
			else
				return new NilClass();
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
				case (Types.String):
					var temp = "{";
					foreach (var key in this._value.Keys)
						temp = temp + ((String)key.type_cast(Types.String))._value + "=>" + ((String)this._value[key].type_cast(Types.String))._value + ",";
					if (this._value.Keys.Count > 0) {
						temp = temp.Remove(temp.Length - 1, 1);
					}
					return new String(temp + "}");
				case (Types.Hash):
					return this;
				case (Types.Boolean):
					return new Boolean(true);
				default: throw new TypeCastingError();
			}
		}
	}
}
