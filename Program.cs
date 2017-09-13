using System;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
namespace Planguage
{
	class MainClass
	{
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
			var vm = new SiBtyVirtualMachine();
			vm.set_variable("readnum", new ExternalFunction(vm.root_space, readnum));
			vm.set_variable("readln", new ExternalFunction(vm.root_space, getch));
			if (args.Length ==0)
			{
				vm.load_from_input_stream();
				return;
			}
			else if (args.Length > 0)
				vm.load_from_file(args[0]);
		}
	}
}
