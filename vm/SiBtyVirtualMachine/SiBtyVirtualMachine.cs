using System;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using System.Collections.Generic;
namespace Planguage
{
    /*
     module_require("source.txt")
for(1,10000,1,do index
if index % 6 ==0
echo(index)
end
return true
end)    

    */
    public class SiBtyVirtualMachine
    {
        bool can_run;

        internal Space original_space { get; set; }
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
                    //foreach (var ins in root_space.instructions)
                    //	Console.WriteLine(ins.GetType().Name);
                    ParseTreeWalker walker = new ParseTreeWalker();
                    walker.Walk(new SiBtyInterpreter(this.root_space), root);
                    this.root_space.exec();
                }
            }

                        catch (Errors.IdentifierError e)
            {
            	Console.Write("An IdentifierError has been raised :{0}", e.message());
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
            catch (Errors.VariableError e)
            {

                if (e.message() == "each")
                {

                }
                Console.Write("An VariableError has been raise :{0}",e.message());

            }
            catch (Errors.TypeCastingError)
            {
                Console.Write("An TypeCastingError has been raised");

            }
        }

        public Space root_space;
        public SiBtyVirtualMachine(Space original_space = null)
        {
            this.root_space = new Space();
            this.original_space = original_space;
        }
        public void set_variable(string name, SibtyObject value)
        {
            this.root_space.register_variable(name);
            this.root_space.assign(name, value);
        }
        public void set_extension_inheritance(string name,SibtyObject value)
        {
            this.root_space.register_variable(name);
            this.root_space.assign(name, value);
            this.root_space.external_methods.Add(name);
        }
        public void load_from_file(string file_name)
        {
            this.can_run = true;
            AntlrFileStream fileStream = new AntlrFileStream(file_name);
            this.run(fileStream);
        }

        public void load_from_input_stream()
        {
            this.can_run = true;
            AntlrInputStream inputStream=  new AntlrInputStream(Console.OpenStandardInput());
            this.run(inputStream);
        }
    }
}
