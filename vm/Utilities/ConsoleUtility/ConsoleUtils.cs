using System;
namespace Planguage.vm.Utilities.ConsoleUtility
{
    public class ConsoleUtils:BaseUtility 
    {
        public ConsoleUtils()
        {
            this.name_space = "console";
        }
        public static void clear(ExternalFunction func) {
            func.set_return_value(new NilClass());
            System.Console.Clear();
        }
        [External(function_name ="readln")]
        public static void readline(ExternalFunction func)
        {
            string _input = Console.ReadLine();
            func.set_return_value(new String(_input));
        }
        [External(parammeters = new string[] { "title" })]
        public static void set_title(ExternalFunction function)
        {
            String title = (String)function.load_var("title").type_cast(Types.String);
            Console.Title = title._value;
            function.set_return_value(new Boolean(true));
        }
        [External(parammeters = new string[] { "text" })]
        public static void write_line(ExternalFunction function)
        {
            String text = (String)function.load_var("text").type_cast(Types.String);
            Console.WriteLine(text._value);
            function.set_return_value(text);
        }
        [External(parammeters = new string[] { "text" })]
        public static void write(ExternalFunction function)
        {
            String text = (String)function.load_var("text").type_cast(Types.String);
            Console.Write(text._value);
            function.set_return_value(text);
        }
        public static void read_number(ExternalFunction f)
        {
            var number = Convert.ToInt32(Console.ReadLine());
            f.set_return_value(new Number(number));
        }
    }
}
