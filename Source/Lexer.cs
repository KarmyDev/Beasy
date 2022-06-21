using System.Collections.Generic;
using System.IO;

namespace Beasy
{
	class Lexer 
	{
		public IEnumerable<Token> Tokenize(string path)
		{
			StreamReader sr = new (path: path);
			List<Token> tokens = new ();
			
			string data = "";
			Token previousCharacter = new ();
			uint index = 0;
			bool IsThisCharNew = true;
			
			bool IsInString = false;
			TokenType currentTokenType = TokenType.None;
			
			// Read until reaches end of file
			while (!sr.EndOfStream)
			{
				char currentCharacter = (char) sr.Read();
				Token token = new ();
				
				// Begin - Indexing and offseting
				if (IsThisCharNew)
				{
					IsThisCharNew = false;
					token.offset = index;
				}
				else token.size = index;
				// End - Indexing and offseting
				
				
				if (!" \t\r\n".Contains(currentCharacter) || IsInString)
				{
					if (currentCharacter == '\"') 
					{
						IsInString = !IsInString;
						currentTokenType = TokenType.String;
					}
					else
					{
						if (currentTokenType == TokenType.None) currentTokenType = TokenType.ID;
						token.offset = previousCharacter.offset;
						data += currentCharacter;
					}
				}
				else
				{
					if (!" \t\r\n".Contains((char) previousCharacter.value))
					{
						
						token.value = data;
						token.type = currentTokenType;
						data = "";
						tokens.Add(token);
						// Reset stuff
						currentTokenType = TokenType.None;
						IsThisCharNew = true;
						previousCharacter.offset = token.offset;
					}
				}
				
				index++;
				previousCharacter.value = currentCharacter;
			}
			
			return tokens;
		}
	}
	
	class Token 
	{
		public uint offset, size;
		public TokenType type;
		public object value;
	}
	
	enum TokenType
	{
		None,
		NewLine, /* \n */
		ID, /* [ a-z, A-Z ] + 0-9 */
		Symbol, /* * ! [a-z, A-Z, 0-9] */
		Separator, /* , */
		Parameters, /* takes, with */
		OpenScope, /* does */
		CloseScope, /* end */
		Int, /* 0-9 */
		Boolean, /* true, false*/
		Float, /* .0-9 */
		String /* "*" */
	}
}