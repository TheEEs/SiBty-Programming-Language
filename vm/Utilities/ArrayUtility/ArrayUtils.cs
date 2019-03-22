using System;
using System.Linq;
namespace Planguage.vm.Utilities.ArrayUtility
{
    public class ArrayUtils : BaseUtility
    {
        public ArrayUtils()
        {
            this.name_space = "array";
        }
        [External(function_name = "len", parammeters = new string[] { "array" })]
        public static void length(ExternalFunction f)
        {
            Array array = (Array)f.load_var("array").type_cast(Types.Array);
            f.set_return_value(new Number(array._value.Count));
        }
        [External(parammeters = new string[] { "array", "comparisor" })]
        public static void sort(ExternalFunction f)
        {
            /*
             var array = [5,3,3,6,3,56]
             array = array_sort(array , do x,y 
                return y-x                       
             end)            
             print array
             */
            Array array = (Array)f.load_var("array").type_cast(Types.Array);
            BaseFunction comparisor = (BaseFunction)f.load_var("comparisor").type_cast(Types.Function);
            array._value.Sort((x, y) =>
            {
                comparisor.set_params(new SibtyObject[] { y, x });
                Number result = (Number)comparisor.function_call().type_cast(Types.Number);
                return result._value;
            });
            f.set_return_value(array);
        }
        [External(parammeters = new string[] { "array", "index" })]
        public static void remove(ExternalFunction f)
        {
            Array array = (Array)f.load_var("array").type_cast(Types.Array);
            Number index = (Number)f.load_var("index").type_cast(Types.Number);
            if (index._value < array._value.Count && index._value >= 0)
                array._value.RemoveAt(index._value);
            else
                throw new Planguage.Errors.VariableError("index");
        }
    }
}
