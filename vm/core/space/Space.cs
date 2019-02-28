using System;
using System.Collections.Generic;
namespace Planguage
{
    public class Space : SiBtySpace
    {
        
        internal Space parent_space;
		internal Dictionary<string, SibtyObject> variables = new Dictionary<string, SibtyObject>();
		Stack<SibtyObject> expression_stack = new Stack<SibtyObject>();
		internal List<SiBtyInstruction> instructions = new List<SiBtyInstruction>();
        internal List<string> external_methods = new List<string>();
        int _instrc_pointer = 0;

		public void set_instruction_ptr(int value)
		{
			this._instrc_pointer = value - 1;
		}

		public SiBtyInstruction get_instruction(int index) {
			return this.instructions[index];
		}

		public SibtyObject seek()
		{
			return this.expression_stack.Peek();
		}

		public void modify_instruction(int index, SiBtyInstruction new_instruction) {
			this.instructions[index] = new_instruction;
		}

		public int number_of_instruction() {
			return this.instructions.Count;
		}
		public int Instruction_Pointer { 
			get { return this._instrc_pointer; }
		}
		public Space(Space parent = null)
		{
			this.parent_space = parent;
		}
		public void add_instruction(SiBtyInstruction instruction) {
			this.instructions.Add(instruction);
		}
		public void push_value(SibtyObject value) {
			this.expression_stack.Push(value);
		}
		public SibtyObject pop_value() {
			return this.expression_stack.Pop();
		}
		public void assign(string var_name, SibtyObject value)
		{
			if (this.variables.ContainsKey(var_name))
				this.variables[var_name] = value;
			else
				throw new Errors.VariableError(var_name);
		}
		public SibtyObject load_var(string var_name) {
			if (this.variables.ContainsKey(var_name))
				return this.variables[var_name];
			else
				throw new Errors.VariableError(var_name);
		}
		public void register_variable(string var_name) {
			if (!this.variables.ContainsKey(var_name))
				this.variables.Add(var_name, new NilClass());
			else
				throw new Errors.IdentifierError(var_name);
		}

		public void exec() {
			for (this._instrc_pointer = 0; this._instrc_pointer < this.instructions.Count; this._instrc_pointer++)
			{
				//Console.Write("{0}: {1}", this.Instruction_Pointer, this.instructions[this.Instruction_Pointer].GetType().Name);
				//Console.ReadLine();
				this.instructions[this.Instruction_Pointer].exec();
			}
		}

		public void clear_expression_stack() {
			this.expression_stack.Clear();
		}
	}  
}
