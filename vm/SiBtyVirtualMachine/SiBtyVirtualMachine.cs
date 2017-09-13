using System;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
namespace Planguage
{
	public class SiBtyVirtualMachine
	{
		bool can_run;

		public void set_runable(bool value)
		{
			this.can_run = value;
		}

		protected void run(Antlr4.Runtime.ICharStream stream)
		{
			try
			{

				langLexer lexer = new langLexer(stream);
				ErrorHandler dream_catcher = new ErrorHandler(lexer, this);
				lexer.RemoveErrorListeners();
				lexer.AddErrorListener(dream_catcher);
				CommonTokenStream tokens = new CommonTokenStream(lexer);
				langParser parser = new langParser(tokens);
				parser.RemoveErrorListeners();
				parser.AddErrorListener(dream_catcher);
				Antlr4.Runtime.Tree.IParseTree root = parser.prog();
				if (this.can_run)
				{
					ParseTreeWalker walker = new ParseTreeWalker();
					walker.Walk(new SiBtyInterpreter(this.root_space), root);
					//foreach (var ins in root_space.instructions)
					//	Console.WriteLine(ins.GetType().Name);
					this.root_space.exec();
				}
			}
			catch (Errors.IdentifierError)
			{
				Console.Write("An IdentifierError has been raised");
			}
			catch (Errors.NilClassException)
			{
				Console.Write("A NilClassError has been raised");
			}
			catch (Errors.OperatorError)
			{
				Console.Write("An OperatorError has been raised");
			}
			catch (Errors.ParameterError)
			{
				Console.Write("An ParameterError has been raised");
			}
			catch (Errors.VariableError)
			{
				Console.Write("An VariableError has been raised");

			}
			catch (Errors.TypeCastingError)
			{
				Console.Write("An TypeCastingError has been raised");

			}
		}

		public Space root_space;
		public SiBtyVirtualMachine()
		{
			this.root_space = new Space();
		}
		public void set_variable(string name, SibtyObject value)
		{
			this.root_space.register_variable(name);
			this.root_space.assign(name, value);
		}

		public void load_from_file(string file_name)
		{
			this.can_run = true;
			AntlrFileStream stream = new AntlrFileStream(file_name);
			this.run(stream);
		}

		public void load_from_input_stream()
		{
			this.can_run = true;
			AntlrInputStream input = new AntlrInputStream(Console.OpenStandardInput());
			this.run(input);
		}
	}
}
