using System;
using System.Diagnostics;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Planguage.vm.Utilities;
namespace Planguage
{
    /*
     var a;var b
var ucln = do a,b
while a<>b 
if a>b a=a-b
else b=b-a end
next
return a
end

while true
print "enter a: "; a = readnum()
print "enter b: "; b = readnum()

print "uoc chung lon nhat cua ", a, " va ", b, " la "; echo(ucln(a,b))
next


module_require("sibty/utils/utils.plang")
var a =0
loop(do
    if a < 100
        a= a+1
        console_write_line(a)       
        return true
    else
        return false
    end
end)

module_require("sibty/utils/utils.plang")
var a =["vai lon", "fuck",1,3,5.7,0x23]    
each(a,do item
console_write_line(item)
end)

     */
    class MainClass
    {
        public static SiBtyVirtualMachine vm = new SiBtyVirtualMachine();
        public static void Main(string[] args)
        {
            vm.load_extension_methods(new vm.Utilities.ModuleUtility.ModuleUtils("module"));
            vm.load_extension_methods(new vm.Utilities.StringUtility.StringUtils());
            vm.load_extension_methods(new vm.Utilities.ConsoleUtility.ConsoleUtils());
            vm.load_extension_methods(new vm.Utilities.ArrayUtility.ArrayUtils());
            vm.load_extension_methods(new vm.Utilities.ObjectUtility.ObjectUtils());
            vm.load_from_input_stream();
            return;

        }
    }
}
