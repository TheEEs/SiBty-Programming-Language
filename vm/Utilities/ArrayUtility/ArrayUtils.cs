using System;
namespace Planguage.vm.Utilities.ArrayUtility
{
    public class ArrayUtils:BaseUtility
    {
        public ArrayUtils()
        {
            this.name_space = "array";
        }
        [External(function_name = "len",parammeters = new string[] { "array" })]
        public static void length(ExternalFunction f)
        {
            Array array = (Array)f.load_var("array").type_cast(Types.Array);
            f.set_return_value(new Number(array._value.Count));
        }
    }
}
