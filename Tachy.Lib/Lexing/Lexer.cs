using System;
using System.IO;

namespace Tachy.Lexing
{
    public class Lexer
    {
        private readonly SourceReader reader;
        public Lexer(SourceReader reader)
        {
            this.reader = reader;
        }
        public Token EmitToken(TokenType type, object? value = null) =>
            new Token(type, reader.Position, reader.Lexeme, value);

        public Token? NextToken()
        {
            char c = reader.Peek();
            reader.Advance();
            switch (c)
            {
                case '(': return EmitToken(TokenType.LParen);
                case ')': return EmitToken(TokenType.RParen);
                case '[': return EmitToken(TokenType.LBracket);
                case ']': return EmitToken(TokenType.RBracket);
                case '{': return EmitToken(TokenType.LBrace);
                case '}': return EmitToken(TokenType.RBrace);
                case ':': return EmitToken(TokenType.Colon);
                case '+': return EmitToken(reader.Match('+') ? TokenType.Plus2 : TokenType.Plus);
                case '-': return EmitToken(TokenType.Minus);
                case '*': return EmitToken(reader.Match('*') ? TokenType.Star2? TokenType.Star);
                case '/': return EmitToken(TokenType.Slash);
                case '%': return EmitToken(TokenType.Percent);
                case ';': return EmitToken(TokenType.Semicolon);
                case '.': return EmitToken(TokenType.Dot);
                case ',': return EmitToken(TokenType.Comma);
                case '=': return EmitToken(TokenType.Equal);
                case '~': return EmitToken(TokenType.Tilde);
                case '?': return EmitToken(TokenType.Question);
                case '!': return EmitToken(TokenType.Question);
            }
        }
        public IEnumerable<Token> Tokenize()
        {
            while (!reader.IsAtEnd)
            {
                Token? current = NextToken();
                if (current is null)
                    continue;
                yield return current;
            }

        }
    }

}
