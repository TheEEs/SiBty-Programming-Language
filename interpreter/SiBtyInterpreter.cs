using System;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using System.Collections.Generic;
namespace Planguage
{
	public class SiBtyInterpreter : langParserBaseListener
	{
		Stack<SiBtySpace> level_of_space = new Stack<SiBtySpace>();

		public SiBtyInterpreter(Space root_space)
		{

			this.level_of_space.Push(root_space);
		}

		public SiBtySpace current_space
		{
			get { return this.level_of_space.Peek(); }
		}

		#region Atom

		public override void EnterHash(langParser.HashContext context)
		{
			this.current_space.add_instruction(new Load(this.current_space, new Hash(0)));
		}

		public override void EnterHash_key_value(langParser.Hash_key_valueContext context)
		{
			this.current_space.add_instruction(new Load(this.current_space, new String(context.Id().GetText())));
		}
		public override void ExitHash_key_value(langParser.Hash_key_valueContext context)
		{
			this.current_space.add_instruction(new HashInit(this.current_space));
		}

		public override void EnterArray(langParser.ArrayContext context)
		{
			this.current_space.add_instruction(new Load(this.current_space, new Planguage.Array(null)));
		}
		public override void ExitArray_element(langParser.Array_elementContext context)
		{
			this.current_space.add_instruction(new BitwiseLShift(this.current_space));
		}


		public override void ExitNumber(langParser.NumberContext context)
		{
			this.current_space.add_instruction(new Load(this.current_space, new Number(context.value)));
		}
		public override void ExitFloat(langParser.FloatContext context)
		{
			this.current_space.add_instruction(new Load(this.current_space, new Float(float.Parse(context.GetText()))));
		}
		public override void ExitIdentifiers(langParser.IdentifiersContext context)
		{
			this.current_space.add_instruction(new Load_Var(this.current_space, context.GetText()));
		}
		public override void ExitNil(langParser.NilContext context)
		{
			this.current_space.add_instruction(new Load(this.current_space, new NilClass()));
		}
		public override void ExitTruefalse(langParser.TruefalseContext context)
		{
			this.current_space.add_instruction(new Load(this.current_space, new Boolean(bool.Parse(context.GetText()))));
		}
		public override void ExitLine(langParser.LineContext context)
		{
			//Console.WriteLine(((String)this.current_space.seek().type_cast(Types.String))._value);
			if (context.expression().Length == 1)
				this.current_space.add_instruction(new PopStack(this.current_space));
		}
		public override void ExitString(langParser.StringContext context)
		{
			string value = "";
			foreach (var str in context.String())
				value += str.GetText().Substring(1, str.GetText().Length - 2);
			this.current_space.add_instruction(new Load(this.current_space, new String(value)));
		}

		public override void ExitMember_accesses(langParser.Member_accessesContext context)
		{
			this.current_space.add_instruction(new MemberAccess(this.current_space));
		}
		#endregion

		#region Operators
		public override void ExitPos_neg(langParser.Pos_negContext context)
		{
			if (context.GetToken(langLexer.Additive, 0).GetText() == "+")
				this.current_space.add_instruction(new Positive(this.current_space));
			else
				this.current_space.add_instruction(new Negative(this.current_space));
		}
		public override void ExitBoolean_not(langParser.Boolean_notContext context)
		{
			this.current_space.add_instruction(new BooleanNot(this.current_space));
		}
		public override void ExitBitwise_not(langParser.Bitwise_notContext context)
		{
			this.current_space.add_instruction(new BitwiseNot(this.current_space));
		}
		public override void ExitExponents(langParser.ExponentsContext context)
		{
			this.current_space.add_instruction(new Exponent(this.current_space));
		}
		public override void ExitMultiplications(langParser.MultiplicationsContext context)
		{
			switch (context.GetToken(langLexer.Multiplicative, 0).GetText())
			{
				case "*":
					this.current_space.add_instruction(new Mul(this.current_space)); break;
				case "/": this.current_space.add_instruction(new Div(this.current_space)); break;
				case "%":
					this.current_space.add_instruction(new Mod(this.current_space)); break;
			}
		}
		public override void ExitAdditives(langParser.AdditivesContext context)
		{
			switch (context.GetToken(langLexer.Additive, 0).GetText())
			{
				case "+":
					this.current_space.add_instruction(new Add(this.current_space)); break;
				case "-":
					this.current_space.add_instruction(new Sub(this.current_space)); break;
			}
		}
		public override void ExitBitwise_shift(langParser.Bitwise_shiftContext context)
		{
			switch (context.GetToken(langLexer.Bitwise_shift, 0).GetText())
			{
				case "<<":
					this.current_space.add_instruction(new BitwiseLShift(this.current_space)); break;
				case ">>":
					this.current_space.add_instruction(new BitwiseRShift(this.current_space)); break;

			}
		}
		public override void ExitRelationals(langParser.RelationalsContext context)
		{
			switch (context.GetToken(langLexer.Relational, 0).GetText())
			{
				case ">=":
					this.current_space.add_instruction(new BiggerOrEqual(this.current_space));
					break;
				case "<=":
					this.current_space.add_instruction(new SmallerOrEqual(this.current_space));
					break;
				case ">":
					this.current_space.add_instruction(new Bigger(this.current_space));
					break;
				case "<":
					this.current_space.add_instruction(new Smaller(this.current_space));
					break;
			}
		}

		public override void ExitEqualties(langParser.EqualtiesContext context)
		{
			switch (context.GetToken(langLexer.Equalty, 0).GetText())
			{
				case "<>":
					this.current_space.add_instruction(new Different(this.current_space));
					break;
				case "==":
					this.current_space.add_instruction(new Equal(this.current_space));
					break;
			}
		}

		public override void ExitBitwise_operators(langParser.Bitwise_operatorsContext context)
		{
			if (context.op.Type == langLexer.Bitwise_operators)
				switch (context.GetToken(langLexer.Bitwise_operators, 0).GetText())
				{
					case "&":
						this.current_space.add_instruction(new BitwiseAnd(this.current_space));
						break;
					case "^":
					case "xor":
						this.current_space.add_instruction(new BitwiseXor(this.current_space));
						break;
				}
			else
				this.current_space.add_instruction(new BitwiseOr(this.current_space));

		}
		public override void ExitBoolean_operators(langParser.Boolean_operatorsContext context)
		{
			switch (context.GetToken(langLexer.Boolean_operator, 0).GetText())
			{
				case "&&":
				case "and":
					this.current_space.add_instruction(new BooleanAnd(this.current_space));
					break;
				case "||":
				case "or":
					this.current_space.add_instruction(new BooleanOr(this.current_space));
					break;
			}
		}

		public override void ExitAssignments(langParser.AssignmentsContext context)
		{
			this.current_space.add_instruction(new Assign(this.current_space, context.Id().GetText()));
		}

		public override void ExitFunction_in_pathens(langParser.Function_in_pathensContext context)
		{

		}
		#endregion


		#region Space

		public override void ExitVariable_decleration(langParser.Variable_declerationContext context)
		{
			this.current_space.register_variable(context.Id().GetText());
			if (context.expression() == null)
				this.current_space.add_instruction(new Load(this.current_space, new NilClass()));
			if (context.GetToken(langLexer.Assignment, 0) != null)
				this.current_space.add_instruction(new Assign(this.current_space, context.Id().GetText()));
		}
		public override void EnterWhile_stat(langParser.While_statContext context)
		{

			context.begin = this.current_space.number_of_instruction();
		}

		public override void ExitExps(langParser.ExpsContext context)
		{
			this.current_space.add_instruction(new JumpIfNot(this.current_space, 0));
			context.position = this.current_space.number_of_instruction();
		}

		public override void ExitWhile_stat(langParser.While_statContext context)
		{
			this.current_space.add_instruction(new PopStack(this.current_space));
			context.end = this.current_space.number_of_instruction();
			this.current_space.add_instruction(new Jump(this.current_space, context.begin));
			this.current_space.modify_instruction(context.exps().position - 1, new JumpIfNot(this.current_space, context.end + 1));
			foreach (int index in context.breaks)
			{
				this.current_space.modify_instruction(index, new Jump(this.current_space, context.end + 1));
			}
		}

		public override void ExitLast_expression_in_if(langParser.Last_expression_in_ifContext context)
		{
			if (context.expression() != null)
				this.current_space.add_instruction(new PopStack(this.current_space));
		}
		public override void ExitLast_expression_in_while(langParser.Last_expression_in_whileContext context)
		{
			if (context.expression() != null)
				this.current_space.add_instruction(new PopStack(this.current_space));
		}


		public override void ExitIif(langParser.IifContext context)
		{
			this.current_space.add_instruction(new PopStack(this.current_space));// this instruction will be executed once the conditional value was true
			this.current_space.add_instruction(null /*Run to the end of the if*/);// this instruction too
			context.run_inst_position = this.current_space.number_of_instruction() - 1;
			this.current_space.add_instruction(new PopStack(this.current_space));
			this.current_space.modify_instruction(context.exps().position - 1,
												  new JumpIfNot(this.current_space, this.current_space.number_of_instruction() - 1));
		}
		public override void ExitElse_if(langParser.Else_ifContext context)
		{
			this.current_space.add_instruction(new PopStack(this.current_space));//this two instruction will be run when the conditional value was true
			this.current_space.add_instruction(null);
			context.run_inst_position = this.current_space.number_of_instruction() - 1;
			this.current_space.add_instruction(new PopStack(this.current_space));
			this.current_space.modify_instruction(context.exps().position - 1,
												  new JumpIfNot(this.current_space, this.current_space.number_of_instruction() - 1));
		}

		public override void ExitIf_stat(langParser.If_statContext context)
		{
			this.current_space.add_instruction(new Load(this.current_space, new NilClass()));
			this.current_space.modify_instruction(context.iif().run_inst_position,
												  new Jump(this.current_space, this.current_space.number_of_instruction() - 1));
			foreach (langParser.Else_ifContext ef in context.else_if())
			{
				this.current_space.modify_instruction(ef.run_inst_position, new Jump(this.current_space,
																						 this.current_space.number_of_instruction() - 1));
			}
			foreach (int index in context.jumps)
				this.current_space.modify_instruction(index, new Jump(this.current_space,
																	  this.current_space.number_of_instruction()));
		}


		public override void EnterBreak_stat(langParser.Break_statContext context)
		{
			RuleContext rule = context.Parent;
			while (rule != context.my_if)
			{
				if (rule.GetType().Name == "While_statContext")
					this.current_space.add_instruction(new PopStack(this.current_space));
				rule = rule.Parent;
				//remove all of the while conditional values from expression stack
			}
			if (!(context.Parent is langParser.ElsexContext))
				this.current_space.add_instruction(new PopStack(this.current_space));// remomve the value of the if conditional expression from expression_stack
		}

		public override void ExitBreak_stat(langParser.Break_statContext context)
		{
			this.current_space.add_instruction(null);
			context.my_if.jumps.Add(this.current_space.number_of_instruction() - 1);
		}

		public override void EnterStop_stat(langParser.Stop_statContext context)
		{

			RuleContext rule = context.Parent;
			while (rule != context.my_while)
			{
				if (rule.GetType().Name == "IifContext" || rule.GetType().Name == "Else_ifContext")
					this.current_space.add_instruction(new PopStack(this.current_space));
				rule = rule.Parent;
				//remove all of the if conditional values from expression stack
			}

			this.current_space.add_instruction(new PopStack(this.current_space));// remomve the value of the if conditional expression from expression_stack

		}
		public override void ExitStop_stat(langParser.Stop_statContext context)
		{
			this.current_space.add_instruction(null);
			context.my_while.breaks.Add(this.current_space.number_of_instruction() - 1);
		}

		public override void ExitMember_settings(langParser.Member_settingsContext context)
		{
			this.current_space.add_instruction(new MemberSetting(this.current_space));
		}

		public override void ExitPrint(langParser.PrintContext context)
		{
			this.current_space.add_instruction(new ConsoleOut(this.current_space, context.expression().Length));
		}


		#endregion

		#region function_methods
		public override void EnterFunction_dec(langParser.Function_decContext context)
		{
			List<string> c = new List<string>();
			foreach (var id in context.Id())
				c.Add(id.GetText());
			var func = new BaseFunction(this.current_space, c.ToArray());
			this.level_of_space.Push(func);
		}

		public override void ExitFunction_dec(langParser.Function_decContext context)
		{
			var function = (BaseFunction)this.level_of_space.Pop();
			if (context.Parent is langParser.Function_callContext)
			{
				((langParser.Function_callContext)context.Parent).fn = function;
			}
			else
				this.current_space.add_instruction(new Load(this.current_space, function));
		}
		public override void ExitReturn_stat(langParser.Return_statContext context)
		{
			this.current_space.add_instruction(new Return(this.current_space));
		}

		public override void EnterFunction_call(langParser.Function_callContext context)
		{

		}

		public override void ExitFunction_call(langParser.Function_callContext context)
		{
			if (context.Id() != null)
			{
				this.current_space.add_instruction(new Load_Var(this.current_space, context.Id().GetText()));
			}
			else if (context.function_dec() != null)
				this.current_space.add_instruction(new Load(this.current_space, context.fn));
			else if (context.member_function() != null)
			{
				if (context.member_function().idx != null)
				{
					this.current_space.add_instruction(new Load_Var(this.current_space, context.member_function().idx.Text));
					this.current_space.add_instruction(new Load(this.current_space, new String(context.member_function().member_name.Text)));
					this.current_space.add_instruction(new MemberAccess(this.current_space));
				}
				else if (context.member_function().hash() != null)
				{
					this.current_space.add_instruction(new Load(
						(Load)this.current_space.get_instruction(context.member_function().begin)
					));
					this.current_space.add_instruction(new Load(this.current_space, new String(context.member_function().member_name.Text)));
					this.current_space.add_instruction(new MemberAccess(this.current_space));
				}
			}
			this.current_space.add_instruction(new FunctionCall(this.current_space, context.expression().Length + (context.member_function() != null ? 1 : 0)));
		}
		public override void EnterMember_function(langParser.Member_functionContext context)
		{
			if (context.idx != null)
			{
				this.current_space.add_instruction(new Load_Var(this.current_space, context.idx.Text));
				context.begin = this.current_space.number_of_instruction() - 1;
			}
			else if (context.hash() != null) {
				context.begin = this.current_space.number_of_instruction();
			}
		}
		#endregion
	}
}