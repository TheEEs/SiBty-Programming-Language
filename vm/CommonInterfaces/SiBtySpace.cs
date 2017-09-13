using System;
namespace Planguage
{
	public interface SiBtySpace
	{
		void modify_instruction(int index, SiBtyInstruction new_instruction);
		void set_instruction_ptr(int value);
		int number_of_instruction();
		int Instruction_Pointer { get; }
		void add_instruction(SiBtyInstruction instruction);
		void push_value(SibtyObject value);
		SibtyObject pop_value();
		void assign(string var_name, SibtyObject value);
		SibtyObject load_var(string var_name);
		SibtyObject seek();
		void register_variable(string var_name);
		void exec();
		SiBtyInstruction get_instruction(int index);
		void clear_expression_stack();
	}
}
