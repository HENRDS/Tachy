namespace Tachy.Lexing
{
    public enum TokenType
    {
        LParen, RParen, LBrace, RBrace, LBracket, RBracket, Semicolon, Colon, Colon2, Comma,
        Plus, Minus, Slash, Percent, Bang, Tilde, Hash, Backslash, Caret, Dot, Dot2, Dot2Less, Ellipsis,
        Star, Star2, Ampersand, Ampersand2, Pipe, Pipe2, Equal, Equal2, Plus2, Minus2,
        BangEqual, PlusEqual, MinusEqual, StarEqual, SlashEqual, PercentEqual, Star2Equal,
        Less, LessEqual, Less2, Greater, GreaterEqual, Greater2, TildeEqual, CaretEqual,
        Less2Equal, Greater2Equal, AmpersandEqual, PipeEqual, PipeGreater, LessPipe,
        DashGreater, LessDash, EqualGreater, Question,
        As, And, Assert, Async, Await, Break, Case, Const, Continue, Del, Else, Except, False, For, Finally, From, Fun, If, Import,
        In, Is, Let, Loop, Mod, Meta, New, Of, Raise, Return, Trait, True, Try, Type, Use, Var, With, When, While, Where, Yield,

        Identifier, IntLit, FloatLit, StrLit, CharLit, Comment, EOL, EOF, Whitespace
    }
    public class SourcePosition
    {
        public readonly int Line;
        public readonly int Column;
        public readonly int Absolute;

        public SourcePosition(int line, int column, int absolute)
        {
            this.Line = line;
            this.Column = column;
            this.Absolute = absolute;
        }
    }

    public class Token
    {
        public readonly TokenType Type;
        public readonly SourcePosition Position;
        public readonly string Lexeme;
        public readonly object? Value;

        public Token(TokenType type, SourcePosition position, string lexeme, object? value)
        {
            Type = type;
            Position = position;
            Lexeme = lexeme;
            Value = value;
        }

        public override string ToString() => this.Type.ToString();


        public bool IsKeyword => this.Type switch {
            TokenType.As | TokenType.And | TokenType.Assert | TokenType.Async | TokenType.Await | TokenType.Break |
            TokenType.Case | TokenType.Const | TokenType.Continue | TokenType.Del | TokenType.Else |
            TokenType.Except | TokenType.False | TokenType.For | TokenType.Finally | TokenType.From | TokenType.Fun |
            TokenType.If | TokenType.Import | TokenType.In | TokenType.Is | TokenType.Let | TokenType.Loop |
            TokenType.Mod | TokenType.Meta |TokenType.New | TokenType.Of | TokenType.Raise | TokenType.Return |
            TokenType.Trait | TokenType.True | TokenType.Try | TokenType.Type | TokenType.Use |
            TokenType.Var | TokenType.With | TokenType.When | TokenType.While | TokenType.Where | TokenType.Yield
             => true,
            _=> false
        };
    }
}
