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
                _vitural_machine.load_from_file(path._value);
                Space upper_space = function.parent_space as Space;
                foreach (var _variable in _vitural_machine.root_space.variables)
                {
                    upper_space.variables[_variable.Key] = _variable.Value;
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
