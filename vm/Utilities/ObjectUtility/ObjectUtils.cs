using System;
using System.Dynamic;
using Planguage.vm.Prototypes;
namespace Planguage.vm.Utilities.ObjectUtility
{

    /*
var a = obj_create(do 
print "xaml"
end)

     */
    public class ObjectUtils : BaseUtility
    {
        public ObjectUtils(string name_space = "obj") : base(name_space)
        {

        }
        [External(parammeters = new string[] { "function" })]
        public static void create(ExternalFunction self)
        {
            Planguage.vm.Prototypes.Object @object = new Prototypes.Object();
            BaseFunction _func = self.load_var("function").type_cast(Types.Function) as BaseFunction;
            var param_numbers = _func.number_of_params;
            if (param_numbers < 1)
                throw new Planguage.Errors.ParameterError(true);
            System.Collections.Generic.List<SibtyObject> _params = new System.Collections.Generic.List<SibtyObject>() {
                @object
            };
            for(var i = 1;i < param_numbers; i++)
            {
                _params.Add(new NilClass());
            }
            _func.set_params(_params.ToArray());
            self.set_return_value(_func.function_call());
        }
    }
}
