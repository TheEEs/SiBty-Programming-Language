using System;
namespace Planguage.vm.Utilities.StringUtility
{
    public class StringUtils: BaseUtility
    {
        public StringUtils()
        {
            this.name_space = "str";
        }

        [External(function_name = "nl")]
        public static void new_line(ExternalFunction function)
        {
            function.set_return_value(new Planguage.String("\n"));
        }
    }
}
