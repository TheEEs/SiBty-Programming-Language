using System;
using System.IO;
using Antlr4.Runtime;

namespace Planguage
{
	public class ErrorHandler: Antlr4.Runtime.BaseErrorListener, Antlr4.Runtime.IAntlrErrorListener<int>
	{

		protected string[] lines;
		protected SiBtyVirtualMachine vm;
		public ErrorHandler(Antlr4.Runtime.Lexer lexer,SiBtyVirtualMachine vm) {
			this.vm = vm;
			this.lines = lexer.InputStream.ToString().Split('\n');
		}


		protected void under_line(int line_number,int charpos) {
			Console.WriteLine(this.lines[line_number-1]);
			int i;
			for (i = 1; i <= charpos; i++)
				Console.Write(" ");
			Console.WriteLine("^");

		}

		public void SyntaxError(TextWriter output, IRecognizer recognizer, int offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
		{
			this.vm.set_runable(false);
			Console.WriteLine("SiBty error ({0}:{1}) -> unexpected \"{2}\" token",
							  line, charPositionInLine, this.lines[line-1][charPositionInLine]);
			this.under_line(line, charPositionInLine);
			
		}

		public override void SyntaxError(System.IO.TextWriter output, Antlr4.Runtime.IRecognizer recognizer, Antlr4.Runtime.IToken offendingSymbol, int line, int charPositionInLine, string msg, Antlr4.Runtime.RecognitionException e)
		{
			this.vm.set_runable(false);
			//Console.WriteLine(e.GetType().Name);
			Console.WriteLine("SiBty error ({0}:{1}) -> {2}",line,charPositionInLine,msg);
            this.under_line(line, charPositionInLine);
		}
	}

}
