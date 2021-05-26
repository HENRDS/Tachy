using System;
using System.Linq;
using System.IO;

namespace Tachy.Lexing
{
    public class SourceReader: IDisposable
    {
        public const char Eof = '\xff';
        private readonly StreamReader reader;
        public int Absolute { get; set; }
        public string Buffer { get; set; }
        public int BufferPos { get; set; }
        public int LineStart { get; set; }
        public int Line { get; set; }
        public int LexemeStart { get; set; }
        public SourceReader(Stream stream)
        {
            reader = new StreamReader(stream);
            Buffer = "";
            BufferPos = 0;
            LineStart = 0;
            Line = 1;
            LexemeStart = 0;
            Absolute = 0;
        }
        public static SourceReader FromString(string code)
        {
            var stream = new MemoryStream();
            var sr = new StreamWriter(stream);
            sr.Write(code);
            return new SourceReader(stream);
        }
        protected void FillBuffer()
        {
            Buffer = Buffer[LexemeStart..] + reader.ReadLine();
            BufferPos -= LexemeStart;
            LexemeStart = 0;
        }

        public SourcePosition Position => new(Line, LexemeStart - LineStart, Absolute);

        public void Dispose()
        {
            reader.Dispose();
        }
        public void Advance(int count = 1)
        {
            BufferPos += count;
        }
        public char Peek(int offset = 1)
        {
            int index = BufferPos + offset;
            if (index >= Buffer.Length)
                return Eof;
            return Buffer[index];
        }
        public bool IsAtEnd => reader.EndOfStream;
        public void Sync()
        {
            Absolute += BufferPos - LexemeStart;
            LexemeStart = BufferPos;
        }
        public bool Match(params char[] options)  {
            if (options.Contains(Peek()))
                Advance();
        }
        public char Current => Peek(0);
        public string Lexeme => Buffer[LexemeStart..BufferPos];

    }

}
