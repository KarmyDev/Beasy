using System;
using System.Collections.Generic;

namespace Beasy
{
	class Program
	{
		static void Main(string[] args)
		{
			// Lexer lexer = new ();
			if (args.Length == 0) 
			{
				Console.WriteLine("    ____                       \n"
				+ "   / __ )___  ____ ________  __   Beasy - Interpreted programming language\n"
				+ "  / __  / _ \\/ __ `/ ___/ / / /           made by Karmy (2022)\n"
				+ " / /_/ /  __/ /_/ (__  ) /_/ / \n"
				+ "/_____/\\___/\\__,_/____/\\__, /     For more help type beasy --help\n"
				+ "                      /____/   \n\n");
			}
			else if (args.Length >= 1)
			{
				Lexer lexer = new ();
				
				List<Token> tokens = (List<Token>) lexer.Tokenize(args[0]);
				
				Console.WriteLine("tokens.Count = " + tokens.Count);
				
				foreach (Token token in tokens)
				{
					string prefix = tokens.Count - 1 == token.offset ? "L- " : "|- ";
					
					string firstRow = "\u001b[31m(" + token.offset + "/" + token.size + ")\u001b[0m\t";
					string secondRow = $"[\u001b[32m{token.type.ToString()}\u001b[0m]";
					string thirdRow = "\u001b[36m" + prefix + "\u001b[0m\u001b[41m" + token.value + "\u001b[0m";
					
					Console.WriteLine($"{firstRow:15} {secondRow:15} {thirdRow:15}");
				}
			}
		}
	}
}
