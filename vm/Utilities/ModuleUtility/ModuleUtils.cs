using System;
namespace Planguage.vm.Utilities.ModuleUtility
{
    public class ModuleUtils : BaseUtility
    {
        public ModuleUtils(string name_space) : base(name_space)
        {
        }
        [External(parammeters = new string[] { "path" })]
        public static void require(ExternalFunction function)
        {
            try
            {
                String path = (String)function.load_var("path").type_cast(Types.String);
                SiBtyVirtualMachine _vitural_machine = new SiBtyVirtualMachine();
                Space current_space = function.parent_space as Space;
                foreach (string external_function in current_space.external_methods)
                {
                    var ex_func = current_space.variables[external_function] as ExternalFunction;
                    ex_func.parent_space = _vitural_machine.root_space;
                    _vitural_machine.set_extension_inheritance(external_function, ex_func);
                }
                _vitural_machine.load_from_file(path._value);
                foreach (var variable in _vitural_machine.root_space.variables)
                {
                    if (!current_space.variables.ContainsKey(variable.Key))
                        current_space.variables[variable.Key] = variable.Value;
                }
                foreach (string external_function in current_space.external_methods)
                {
                    var ex_func = current_space.variables[external_function] as ExternalFunction;
                    ex_func.parent_space = current_space;
                }
                function.set_return_value(new Planguage.Boolean(true));
            }
            catch
            {
                Console.Error.WriteLine("Error occurred when loading modules");
                function.set_return_value(new Planguage.Boolean(false));
            }
        }
    }
}
