using System;
using Planguage.Errors;
using System.Collections.Generic;
namespace Planguage
{
	public struct Array : SibtyObject
	{



		internal List<SibtyObject> _value;

		public Array(byte? c=null/*you do not need to care about this fucking parameter*/)
		{
			this._value = new List<SibtyObject>();
		}

		public SibtyObject positive() {
			throw new OperatorError();
		}

		public SibtyObject negative() {
			throw new OperatorError();
		}

		public SibtyObject add(SibtyObject value)
		{
			Array temp = ((Array)value.type_cast(Types.Array));
			var return_Array = new Array() { _value = new List<SibtyObject>() };
			return_Array._value.AddRange(this._value);
			return_Array._value.AddRange(temp._value);
			return return_Array;
		}

		public SibtyObject function_call() {
			throw new OperatorError();
		}

		public SibtyObject bigger(SibtyObject value)
		{
			return new Boolean() { _value = this._value.Count > ((Array)value.type_cast(Types.Array))._value.Count };
		}

		public SibtyObject bigger_or_equal(SibtyObject value)
		{
			return new Boolean() { _value = this._value.Count >= ((Array)value.type_cast(Types.Array))._value.Count };
		}

		public SibtyObject bitwise_and(SibtyObject value)
		{
			throw new OperatorError();
			//return new Boolean() { _value = ((Boolean)value.type_cast(Types.Boolean))._value };
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
			return new Boolean() { _value = this._value.Count != ((Array)value.type_cast(Types.Array))._value.Count };
		}

		public SibtyObject div(SibtyObject value)
		{
			throw new OperatorError();
		}

		public SibtyObject equal(SibtyObject value)
		{
			List<SibtyObject> temp = ((Array)value.type_cast(Types.Array))._value;
			if (temp.Count != this._value.Count) return new Boolean() { _value = false };
			for (int i = 0; i < temp.Count; i++)
			{
				if (((Boolean)temp[i].different(this._value[i]))._value)
					return new Boolean() { _value = false };
			}
			return new Boolean() { _value = true };
		}

		public SibtyObject exponent(SibtyObject value)
		{
			throw new OperatorError();
		}

		public Types get_types()
		{
			return Types.Array;
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
			this._value.Add(value);
			return this;
		}

		public SibtyObject member_access(SibtyObject value)
		{
			return this._value[((Number)value.type_cast(Types.Number))._value];
		}


		public SibtyObject member_setting(SibtyObject key, SibtyObject value) {
			var index = (Number)key.type_cast(Types.Number);
			this._value[index._value] = value;
			return value;
		}

		public SibtyObject mul(SibtyObject value)
		{
			var ret = new Array();
			for (int i = 1; i < 4; i++)
			{
				ret._value.AddRange(this._value);
			}
			return ret;
		}

		public SibtyObject remainder(SibtyObject value)
		{
			throw new Errors.OperatorError();
		}

		public SibtyObject rshift(SibtyObject value)
		{
			if (value.get_types() == Types.Nil)
			{
				this._value.RemoveAt(this._value.Count - 1);
			}
			else
			{
				this._value.RemoveAt(((Number)value.type_cast(Types.Number))._value);
			}
			return this;
		}

		public SibtyObject smaller(SibtyObject value)
		{
			return new Boolean() { _value = this._value.Count < ((Array)value.type_cast(Types.Array))._value.Count };
		}

		public SibtyObject smaller_or_equal(SibtyObject value)
		{
			return new Boolean() { _value = this._value.Count <= ((Array)value.type_cast(Types.Array))._value.Count };
		}

		public SibtyObject sub(SibtyObject value)
		{
			throw new OperatorError();
		}

		public SibtyObject type_cast(Types target_types)
		{
			switch (target_types)
			{
				case (Types.Array):
					return new Array() { _value = this._value };
				case (Types.Boolean):
					return new Boolean() { _value = true };
				case (Types.Float):
				//throw new TypeCastingError();
				case (Types.Hash):
				//throw new TypeCastingError();
				case (Types.Nil):
				//throw new TypeCastingError();
				case (Types.Number):
					throw new TypeCastingError();
				case (Types.String):
					string a = "[";
					foreach (SibtyObject item in this._value)
					{
						a += ((String)item.type_cast(Types.String))._value+",";
					}
					return (this._value.Count > 0 ? new String(a.Substring(0, a.Length - 1) + ']'):  new String("[ ]"));
				default:
					throw new TypeCastingError();
			}
		}
	}
}
