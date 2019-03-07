using System;
using System.Collections.Generic;
using Planguage.Errors;
namespace Planguage
{

    /*
      module_require("sibty/utils/utils.plang")
var new_person = do name,age,gender
    return obj_create(do person
        person["name"] = name
        person["age"] = age
        person["gender"] = gender
        person["greet"] = do self
            print "Hello , my name is ", self["name"], str_nl()
        end
        person["sex"] = do self
            return if self["gender"]
                break "male"
            else
                break "female"
            end
        end
        return person   
    end)
end
#true is male
#false is female
var dat = new_person("Dat", 20, true)
dat.greet()
console_write_line(dat.sex())   
     */
    public class BaseFunction : SiBtySpace, SibtyObject
	{
		internal SiBtySpace parent_space;
		internal List<string> param_names = new List<string>();
		List<string> var_names = new List<string>();
		Stack<Dictionary<string, SibtyObject>> stack_of_stage_variable = new Stack<Dictionary<string, SibtyObject>>();
		Dictionary<string, SibtyObject> current_stage_variables;//= new Dictionary<string, SibtyObject>();
		Stack<Stack<SibtyObject>> stack_of_ex_stage = new Stack<Stack<SibtyObject>>();
		Stack<SibtyObject> current_expression_stack;//= new Stack<SibtyObject>();
		List<SiBtyInstruction> instructions = new List<SiBtyInstruction>();
		Stack<int> stack_of_instr_ptr = new Stack<int>();
		protected SibtyObject _return_value;
		int current_instr_ptr = -1;
		public int Instruction_Pointer
		{
			get
			{
				return this.current_instr_ptr;
			}
		}

		public SiBtyInstruction get_instruction(int index){
			return this.instructions[index];
		}

		public int number_of_params
		{
			get
			{
				return this.param_names.Count;
			}
		}


		public SibtyObject member_setting(SibtyObject key,SibtyObject value) {
			throw new OperatorError();
		}

		public void modify_instruction(int index, SiBtyInstruction new_instruction)
		{
			this.instructions[index] = new_instruction;
		}
		public int number_of_instruction()
		{
			return this.instructions.Count;
		}

		public BaseFunction(SiBtySpace parent_space, string[] param_names)
		{
			this.parent_space = parent_space;
			foreach (var param in param_names)
				this.param_names.Add(param);
		}

		public SibtyObject seek()
		{
			return this.current_expression_stack.Peek();
		}

		#region SiBtyObject
		public SibtyObject positive()
		{
			throw new Errors.OperatorError();
		}

		public SibtyObject negative()
		{
			throw new Errors.OperatorError();
		}

		public virtual SibtyObject function_call()
		{
			//if (this.current_stage_variables != null)
			//	this.stack_of_stage_variable.Push(this.current_stage_variables);
			if (this.current_expression_stack != null)
				this.stack_of_ex_stage.Push(this.current_expression_stack);
			if (this.current_instr_ptr >= 0)
				this.stack_of_instr_ptr.Push(this.current_instr_ptr);
			//this.current_stage_variables = new Dictionary<string, SibtyObject>();
			this.current_expression_stack = new Stack<SibtyObject>();
			this.current_instr_ptr = 0;
			this.exec();
			this._return_value = this.current_expression_stack.Count > 0 ? this.current_expression_stack.Peek() : new NilClass();

			if (stack_of_stage_variable.Count > 0)
				this.current_stage_variables = this.stack_of_stage_variable.Pop();
			else this.current_stage_variables = null;

			if (this.stack_of_ex_stage.Count > 0)
				this.current_expression_stack = this.stack_of_ex_stage.Pop();
			else this.current_expression_stack = null;

			if (this.stack_of_instr_ptr.Count > 0)
				this.current_instr_ptr = this.stack_of_instr_ptr.Pop();
			else
				this.current_instr_ptr = 0;

			return this._return_value;
		}

		public SibtyObject add(SibtyObject value)
		{
			throw new Errors.OperatorError();
		}

		public SibtyObject bigger(SibtyObject value)
		{
			throw new Errors.OperatorError();
		}

		public SibtyObject bigger_or_equal(SibtyObject value)
		{
			throw new Errors.OperatorError();
		}

		public SibtyObject bitwise_and(SibtyObject value)
		{
			throw new Errors.OperatorError();
		}

		public SibtyObject bitwise_not()
		{
			throw new Errors.OperatorError();
		}

		public SibtyObject bitwise_or(SibtyObject value)
		{
			throw new Errors.OperatorError();
		}

		public SibtyObject bitwise_xor(SibtyObject value)
		{
			throw new Errors.OperatorError();
		}

		public SibtyObject bool_not()
		{
			return new Boolean(true);
		}

		public void set_params(SibtyObject[] param_list)
		{
			if (this.current_stage_variables != null)
				this.stack_of_stage_variable.Push(this.current_stage_variables);
			this.current_stage_variables = new Dictionary<string, SibtyObject>();
			for (int i = 0; i < this.param_names.Count; i++)
			{
				this.current_stage_variables[this.param_names[i]] = param_list[i];
			}
			foreach (var name in this.var_names)
				this.current_stage_variables[name] = new NilClass();
		}

		public SibtyObject different(SibtyObject value)
		{
			throw new Errors.OperatorError();
		}

		public SibtyObject div(SibtyObject value)
		{
			throw new Errors.OperatorError();
		}

		public SibtyObject equal(SibtyObject value)
		{
			throw new Errors.OperatorError();
		}

		public SibtyObject exponent(SibtyObject value)
		{
			throw new Errors.OperatorError();
		}

		public Types get_types()
		{
			return Types.Function;
		}

		public SibtyObject logic_and(SibtyObject value)
		{
			return new Boolean(((Boolean)value.type_cast(Types.Boolean))._value);
		}

		public SibtyObject logic_or(SibtyObject value)
		{
			return new Boolean(true);
		}

		public SibtyObject lshift(SibtyObject value)
		{
			throw new Errors.OperatorError();
		}

		public SibtyObject member_access(SibtyObject value)
		{
			throw new Errors.OperatorError();
		}

		public SibtyObject mul(SibtyObject value)
		{
			throw new Errors.OperatorError();
		}

		public SibtyObject remainder(SibtyObject value)
		{
			throw new Errors.OperatorError();
		}

		public SibtyObject rshift(SibtyObject value)
		{
			throw new Errors.OperatorError();
		}

		public SibtyObject smaller(SibtyObject value)
		{
			throw new Errors.OperatorError();
		}

		public SibtyObject smaller_or_equal(SibtyObject value)
		{
			throw new Errors.OperatorError();
		}

		public SibtyObject sub(SibtyObject value)
		{
			throw new Errors.OperatorError();
		}

		public SibtyObject type_cast(Types target_types)
		{
			switch (target_types)
			{
				case (Types.Boolean):
					return new Boolean(true);
				case (Types.Function):
					return this;
				case (Types.String):
					return new String(this.GetType().GUID.ToString());
				default: throw new Errors.TypeCastingError();
			}
		}

		public void set_instruction_ptr(int value)
		{
			this.current_instr_ptr = value - 1;
		}

		public void add_instruction(SiBtyInstruction instruction)
		{
			this.current_instr_ptr = 0;
			this.instructions.Add(instruction);
		}

		public void push_value(SibtyObject value)
		{
			this.current_expression_stack.Push(value);
		}

		public SibtyObject pop_value()
		{
			return this.current_expression_stack.Pop();
		}

		public void assign(string var_name, SibtyObject value)
		{
			if (this.current_stage_variables.ContainsKey(var_name))
				this.current_stage_variables[var_name] = value;
			else if (this.parent_space != null)
				this.parent_space.assign(var_name, value);
			else
				throw new Errors.VariableError();
		}

		public SibtyObject load_var(string var_name)
		{
            if (this.current_stage_variables != null && this.current_stage_variables.ContainsKey(var_name))
				return this.current_stage_variables[var_name];
			else if (this.parent_space != null)
				return this.parent_space.load_var(var_name);
			else
				throw new Errors.VariableError();
		}

		public void register_variable(string var_name)
		{
			if ((!this.var_names.Contains(var_name)) && (!this.param_names.Contains(var_name)))
				this.var_names.Add(var_name);
			else throw new Errors.IdentifierError(var_name);
		}

		public virtual void exec()
		{
			for (this.current_instr_ptr = 0; this.current_instr_ptr > -1 && this.current_instr_ptr < this.instructions.Count; this.current_instr_ptr++)
			{
				//Console.Write("{0}: {1}", this.current_instr_ptr, this.instructions[this.current_instr_ptr].GetType().Name);
				//Console.ReadLine();
				this.instructions[this.Instruction_Pointer].exec();
			}
		}
        public void clear_expression_stack()
		{
			this.current_expression_stack.Clear();
		}

		public void set_return_value(SibtyObject ret) {
			this._return_value = ret;
		}
		#endregion
	}
}
