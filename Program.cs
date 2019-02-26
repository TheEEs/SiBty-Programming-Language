using System;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Planguage.vm.Utilities;
namespace Planguage
{

    class MainClass
    {
        public static SiBtyVirtualMachine vm = new SiBtyVirtualMachine();
        public static void Main(string[] args)
        {
            ExternalFunction.__function__ readnum = (ExternalFunction thefunction) =>
                 {
                     var str = Convert.ToInt32(Console.ReadLine());
                     thefunction.set_return_value(new Number(str));

                 };
            ExternalFunction.__function__ getch = (ExternalFunction thefunction) =>
            {
                var str = Console.ReadLine();
                thefunction.set_return_value(new String(str)); ;
            };
            ExternalFunction.__function__ echo = (ExternalFunction thefuntion) =>
            {
                String str = (String)thefuntion.load_var("a").type_cast(Types.String);
                //thefuntion.set_return_value(new NilClass());
                Console.WriteLine(str._value);
            };
            vm.set_variable("readnum", new ExternalFunction(vm.root_space, readnum));
            vm.set_variable("readln", new ExternalFunction(vm.root_space, getch));
            vm.set_variable("echo", new ExternalFunction(vm.root_space, echo, "a"));
            vm.load_external_methods(new vm.Utilities.ModuleUtility.ModuleUtils("module"));
            vm.load_from_input_stream();
            return;


        }
    }
}
