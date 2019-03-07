using System;
using System.Dynamic;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
namespace Planguage.vm.Prototypes
{
    /*
    obj_create(do object
object["x"] =5
print object["x"] + 6
return object;end) 
     */
    public class Object : SibtyObject
    {
#pragma warning disable 0649
        dynamic obj = new ExpandoObject();

        #region Member_GetSet
        static ExternalFunction.__function__ _member_setting_ = (ExternalFunction func) =>
        {
            Object @object = func.load_var("self").type_cast(Types.Object) as Object;
            String name = (String)func.load_var("key").type_cast(Types.String);
            SibtyObject value = func.load_var("value");
            var regex = new Regex(@"^[a-zA-Z0-9_]+$");
            if (!regex.IsMatch(name._value))
                throw new Planguage.Errors.IdentifierError(name._value);
            if (value is BaseFunction)
            {
                if (((BaseFunction)value).number_of_params < 1)
                    throw new Planguage.Errors.ParameterError(true);
                ((IDictionary<string, object>)@object.obj)[name._value] = value;
            }
            else if (value is SibtyObject)
            {
                ((IDictionary<string, object>)@object.obj)[name._value] = value;
            }
            ((IDictionary<string, object>)@object.obj)[name._value] = value;
            func.set_return_value(@object);
        };
        static ExternalFunction.__function__ _member_access = (ExternalFunction func) =>
        {
            String name = (String)func.load_var("key").type_cast(Types.String);
            Object @object = func.load_var("self").type_cast(Types.Object) as Object;
            func.set_return_value(((IDictionary<string, object>)@object.obj)[name._value] as SibtyObject);
        };

        static ExternalFunction mem_set = new ExternalFunction(MainClass.vm.root_space, Object._member_setting_, new string[] { "self", "key", "value" });
        static ExternalFunction mem_get = new ExternalFunction(MainClass.vm.root_space, Object._member_access, new string[] { "self", "key" });
        #endregion
        public Object()
        {
            this.obj.member_setting = Object.mem_set;
            this.obj.member_access = Object.mem_get;
        }

        public SibtyObject add(SibtyObject value)
        {
            StackTrace stackTrace = new StackTrace();
            var method_name = stackTrace.GetFrame(1).GetMethod().Name;
            String name = (String)value.type_cast(Types.String);
            BaseFunction _func = ((IDictionary<string, object>)this.obj)["add"] as BaseFunction;
            _func.set_params(new SibtyObject[] { this, value });
            return _func.function_call();
        }

        public SibtyObject bigger(SibtyObject value)
        {
            StackTrace stackTrace = new StackTrace();
            var method_name = stackTrace.GetFrame(1).GetMethod().Name;
            String name = (String)value.type_cast(Types.String);
            BaseFunction _func = ((IDictionary<string, object>)this.obj)["bigger"] as BaseFunction;
            _func.set_params(new SibtyObject[] { this, value });
            return _func.function_call();
        }

        public SibtyObject bigger_or_equal(SibtyObject value)
        {
            StackTrace stackTrace = new StackTrace();
            var method_name = stackTrace.GetFrame(1).GetMethod().Name;
            String name = (String)value.type_cast(Types.String);
            BaseFunction _func = ((IDictionary<string, object>)this.obj)["bigger_or_equal"] as BaseFunction;
            _func.set_params(new SibtyObject[] { this, value });
            return _func.function_call();
        }

        public SibtyObject bitwise_and(SibtyObject value)
        {
            StackTrace stackTrace = new StackTrace();
            var method_name = stackTrace.GetFrame(1).GetMethod().Name;
            String name = (String)value.type_cast(Types.String);
            BaseFunction _func = ((IDictionary<string, object>)this.obj)["bitwise_and"] as BaseFunction;
            _func.set_params(new SibtyObject[] { this, value });
            return _func.function_call();
        }

        public SibtyObject bitwise_not()
        {
            StackTrace stackTrace = new StackTrace();
            var method_name = stackTrace.GetFrame(1).GetMethod().Name;
            BaseFunction _func = ((IDictionary<string, object>)this.obj)["bitwise_not"] as BaseFunction;
            _func.set_params(new SibtyObject[] { this });
            return _func.function_call();
        }

        public SibtyObject bitwise_or(SibtyObject value)
        {
            StackTrace stackTrace = new StackTrace();
            var method_name = stackTrace.GetFrame(1).GetMethod().Name;
            String name = (String)value.type_cast(Types.String);
            BaseFunction _func = ((IDictionary<string, object>)this.obj)["bitwise_or"] as BaseFunction;
            _func.set_params(new SibtyObject[] { this, value });
            return _func.function_call();

        }

        public SibtyObject bitwise_xor(SibtyObject value)
        {
            StackTrace stackTrace = new StackTrace();
            var method_name = stackTrace.GetFrame(1).GetMethod().Name;
            String name = (String)value.type_cast(Types.String);
            BaseFunction _func = ((IDictionary<string, object>)this.obj)["bitwise_xor"] as BaseFunction;
            _func.set_params(new SibtyObject[] { this, value });
            return _func.function_call();
        }

        public SibtyObject bool_not()
        {
            StackTrace stackTrace = new StackTrace();
            var method_name = stackTrace.GetFrame(1).GetMethod().Name;
            BaseFunction _func = ((IDictionary<string, object>)this.obj)["bool_not"] as BaseFunction;
            _func.set_params(new SibtyObject[] { this });
            return _func.function_call();
        }

        public SibtyObject different(SibtyObject value)
        {
            StackTrace stackTrace = new StackTrace();
            var method_name = stackTrace.GetFrame(1).GetMethod().Name;
            String name = (String)value.type_cast(Types.String);
            BaseFunction _func = ((IDictionary<string, object>)this.obj)["different"] as BaseFunction;
            _func.set_params(new SibtyObject[] { this, value });
            return _func.function_call();
        }

        public SibtyObject div(SibtyObject value)
        {
            StackTrace stackTrace = new StackTrace();
            var method_name = stackTrace.GetFrame(1).GetMethod().Name;
            String name = (String)value.type_cast(Types.String);
            BaseFunction _func = ((IDictionary<string, object>)this.obj)["div"] as BaseFunction;
            _func.set_params(new SibtyObject[] { this, value });
            return _func.function_call();
        }

        public SibtyObject equal(SibtyObject value)
        {
            StackTrace stackTrace = new StackTrace();
            var method_name = stackTrace.GetFrame(1).GetMethod().Name;
            String name = (String)value.type_cast(Types.String);
            BaseFunction _func = ((IDictionary<string, object>)this.obj)["equal"] as BaseFunction;
            _func.set_params(new SibtyObject[] { this, value });
            return _func.function_call();
        }

        public SibtyObject exponent(SibtyObject value)
        {
            StackTrace stackTrace = new StackTrace();
            var method_name = stackTrace.GetFrame(1).GetMethod().Name;
            String name = (String)value.type_cast(Types.String);
            BaseFunction _func = ((IDictionary<string, object>)this.obj)["exponent"] as BaseFunction;
            _func.set_params(new SibtyObject[] { this, value });
            return _func.function_call();
        }

        public SibtyObject function_call()
        {
            throw new NotImplementedException();
        }

        public Types get_types()
        {
            return Types.Object;
        }

        public SibtyObject logic_and(SibtyObject value)
        {
            StackTrace stackTrace = new StackTrace();
            var method_name = stackTrace.GetFrame(1).GetMethod().Name;
            String name = (String)value.type_cast(Types.String);
            BaseFunction _func = ((IDictionary<string, object>)this.obj)["logic_and"] as BaseFunction;
            _func.set_params(new SibtyObject[] { this, value });
            return _func.function_call();
        }

        public SibtyObject logic_or(SibtyObject value)
        {
            StackTrace stackTrace = new StackTrace();
            var method_name = stackTrace.GetFrame(1).GetMethod().Name;
            String name = (String)value.type_cast(Types.String);
            BaseFunction _func = ((IDictionary<string, object>)this.obj)["logic_or"] as BaseFunction;
            _func.set_params(new SibtyObject[] { this, value });
            return _func.function_call();
        }

        public SibtyObject lshift(SibtyObject value)
        {
            StackTrace stackTrace = new StackTrace();
            var method_name = stackTrace.GetFrame(1).GetMethod().Name;
            String name = (String)value.type_cast(Types.String);
            BaseFunction _func = ((IDictionary<string, object>)this.obj)["lshift"] as BaseFunction;
            _func.set_params(new SibtyObject[] { this, value });
            return _func.function_call();
        }

        public SibtyObject member_access(SibtyObject value)
        {
            StackTrace stackTrace = new StackTrace();
            var method_name = stackTrace.GetFrame(1).GetMethod().Name;
            String name = (String)value.type_cast(Types.String);
            BaseFunction _func = ((IDictionary<string, object>)this.obj)["member_access"] as BaseFunction;
            _func.set_params(new SibtyObject[] { this, value });
            return _func.function_call();
        }

        public SibtyObject member_setting(SibtyObject key, SibtyObject value)
        {
            StackTrace stackTrace = new StackTrace();
            var method_name = stackTrace.GetFrame(1).GetMethod().Name;
            String name = (String)value.type_cast(Types.String);
            BaseFunction _func = ((IDictionary<string, object>)this.obj)["member_setting"] as BaseFunction;
            _func.set_params(new SibtyObject[] { this, key, value });
            return _func.function_call();
        }

        public SibtyObject mul(SibtyObject value)
        {
            StackTrace stackTrace = new StackTrace();
            var method_name = stackTrace.GetFrame(1).GetMethod().Name;
            String name = (String)value.type_cast(Types.String);
            BaseFunction _func = ((IDictionary<string, object>)this.obj)["mul"] as BaseFunction;
            _func.set_params(new SibtyObject[] { this, value });
            return _func.function_call();
        }

        public SibtyObject negative()
        {
            StackTrace stackTrace = new StackTrace();
            var method_name = stackTrace.GetFrame(1).GetMethod().Name;
            BaseFunction _func = ((IDictionary<string, object>)this.obj)["negative"] as BaseFunction;
            _func.set_params(new SibtyObject[] { this });
            return _func.function_call();
        }

        public SibtyObject positive()
        {
            StackTrace stackTrace = new StackTrace();
            var method_name = stackTrace.GetFrame(1).GetMethod().Name;
            BaseFunction _func = ((IDictionary<string, object>)this.obj)["positive"] as BaseFunction;
            _func.set_params(new SibtyObject[] { this });
            return _func.function_call();
        }

        public SibtyObject remainder(SibtyObject value)
        {
            StackTrace stackTrace = new StackTrace();
            var method_name = stackTrace.GetFrame(1).GetMethod().Name;
            String name = (String)value.type_cast(Types.String);
            BaseFunction _func = ((IDictionary<string, object>)this.obj)["remainder"] as BaseFunction;
            _func.set_params(new SibtyObject[] { this, value });
            return _func.function_call();
        }

        public SibtyObject rshift(SibtyObject value)
        {
            StackTrace stackTrace = new StackTrace();
            var method_name = stackTrace.GetFrame(1).GetMethod().Name;
            String name = (String)value.type_cast(Types.String);
            BaseFunction _func = ((IDictionary<string, object>)this.obj)["rshift"] as BaseFunction;
            _func.set_params(new SibtyObject[] { this, value });
            return _func.function_call();
        }

        public SibtyObject smaller(SibtyObject value)
        {
            StackTrace stackTrace = new StackTrace();
            var method_name = stackTrace.GetFrame(1).GetMethod().Name;
            String name = (String)value.type_cast(Types.String);
            BaseFunction _func = ((IDictionary<string, object>)this.obj)["smaller"] as BaseFunction;
            _func.set_params(new SibtyObject[] { this, value });
            return _func.function_call();
        }

        public SibtyObject smaller_or_equal(SibtyObject value)
        {
            StackTrace stackTrace = new StackTrace();
            var method_name = stackTrace.GetFrame(1).GetMethod().Name;
            String name = (String)value.type_cast(Types.String);
            BaseFunction _func = ((IDictionary<string, object>)this.obj)["smaller_or_equal"] as BaseFunction;
            _func.set_params(new SibtyObject[] { this, value });
            return _func.function_call(); throw new NotImplementedException();
        }

        public SibtyObject sub(SibtyObject value)
        {
            StackTrace stackTrace = new StackTrace();
            var method_name = stackTrace.GetFrame(1).GetMethod().Name;
            String name = (String)value.type_cast(Types.String);
            BaseFunction _func = ((IDictionary<string, object>)this.obj)["sub"] as BaseFunction;
            _func.set_params(new SibtyObject[] { this, value });
            return _func.function_call();
        }

        public SibtyObject type_cast(Types target_types)
        {
            switch (target_types)
            {
                case Types.Boolean:
                    return new Boolean(true);
                case Types.Object:
                    return this;
                default:
                    throw new Planguage.Errors.TypeCastingError();
            }
        }
    }
}
