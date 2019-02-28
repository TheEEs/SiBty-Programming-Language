using System;
using Planguage;
using System.Collections.Generic;
namespace Planguage.vm.Utilities
{
    public class ExternalAttribute : Attribute
    {
        public string function_name { get; set; }
        public string[] parammeters { get; set; }
        public ExternalAttribute()
        {
            this.parammeters = new string[] { };
        }
    }
    public class BaseUtility
    {
        public string name_space { get; set; }
        public BaseUtility(string name_space = "")
        {
            if (name_space.Contains(" "))
                throw new Planguage.Errors.IdentifierError(name_space);
            this.name_space = name_space;
        }
    }
    public static class VM_Extensions
    {
        public static void load_extension_methods(this Planguage.SiBtyVirtualMachine vm, BaseUtility utility)
        {
            var type_of_utility = utility.GetType();
            var methods_info = type_of_utility.GetMethods();
            foreach (System.Reflection.MethodInfo info in methods_info)
            {
                if (info.ReturnType.Name.ToLower() == "void" && info.IsStatic)
                {
                    if (info.GetParameters().Length == 1 && info.GetParameters()[0].ParameterType.FullName == typeof(ExternalFunction).FullName)
                    {
                        var attrs = info.GetCustomAttributes(typeof(ExternalAttribute), true);
                        ExternalAttribute attr;
                        if (attrs.Length > 0)
                            attr = attrs[0] as ExternalAttribute;
                        else
                            attr = new ExternalAttribute() { function_name = "" };
                        if (attr != null)
                        {
                            string method_name = (attr.function_name != null && attr.function_name != "") ? attr.function_name : info.Name;
                            if (method_name.Contains(" "))
                            {
                                throw new Planguage.Errors.IdentifierError(method_name);
                            }
                            method_name = (utility.name_space.Length > 0 ? utility.name_space + '_' : "" )+ method_name;
                            string[] method_parameters = attr.parammeters;
                            ExternalFunction.__function__ _func_ = (ExternalFunction.__function__)info.CreateDelegate(typeof(ExternalFunction.__function__));
                            var ex_func = new ExternalFunction(vm.root_space, _func_, method_parameters);
                            vm.set_variable(method_name, ex_func);
                            vm.root_space.external_methods.Add(method_name); 
                        }
                    }
                }
            }
        }
    }
}
