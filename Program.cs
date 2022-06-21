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
				Console.WriteLine("\u001b[32m    ____\u001b[0m                       \n"
				+ "\u001b[32m   / __ )___  ____ ________  __\u001b[0m\n"
				+ "\u001b[32m  / __  / _ \\/ __ `/ ___/ / / /\u001b[0m   \u001b[32mBeasy\u001b[0m - Interpreted programming language\n"
				+ "\u001b[32m / /_/ /  __/ /_/ (__  ) /_/ /\u001b[0m            made by Karmy (2022)\n"
				+ "\u001b[32m/_____/\\___/\\__,_/____/\\__, /\u001b[0m\n"
				+ "\u001b[32m                      /____/\u001b[0m      For more help type \u001b[32mbeasy \u001b[36m--help\u001b[0m\n");
			}
			else if (args.Length >= 1)
			{
				if (args[0] != "--help")
				{
					Lexer lexer = new ();
					
					List<Token> tokens = (List<Token>) lexer.Tokenize(args[0]);
					
					Console.WriteLine("tokens.Count = " + tokens.Count);
					
					foreach (Token token in tokens)
					{
						string prefix = tokens.Count - 1 == token.offset ? "L- " : "|- ";
						
						string firstRow = "\u001b[31m(" + token.offset + "/" + token.size + ")\u001b[0m\t";
						string secondRow = $"[\u001b[32m{token.type.ToString()}\u001b[0m]";
						string thirdRow = "\u001b[36m" + prefix + "\u001b[0m\u001b[42m" + token.value + "\u001b[0m";
						
						Console.WriteLine($"{firstRow,10} {secondRow,20} {thirdRow,15}");
					}
				}
				else
				{
					// Display help
					Console.WriteLine("\u001b[32m    ____\u001b[0m                       \n"
					+ "\u001b[32m   / __ )___  ____ ________  __\u001b[0m   \u001b[42mBeasy\u001b[0m - Interpreted programming language\n"
					+ "\u001b[32m  / __  / _ \\/ __ `/ ___/ / / /\u001b[0m           made by Karmy (2022)\n"
					+ "\u001b[32m / /_/ /  __/ /_/ (__  ) /_/ /\u001b[0m \n"
					+ "\u001b[32m/_____/\\___/\\__,_/____/\\__, /\u001b[0m     For more help type \u001b[32mbeasy \u001b[36m--help\u001b[0m\n"
					+ "\u001b[32m                      /____/\u001b[0m   \n\n");
				}
			}
		}
	}
}
