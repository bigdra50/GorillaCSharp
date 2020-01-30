namespace Gorilla.Lexing
{
    public class Lexer
    {
        public string Input { get; private set; }
        public char CurrentChar { get; private set; }
        public char NextChar { get; private set; } // == などのために次の文字も読み込む
        public int Position { get; private set; } = 0;

        public Lexer(string input)
        {
            this.Input = input;
            this.ReadChar();
        }

        public Token NextToken()
        {
            this.SkipWhiteSpace();
            var token = (Token) null;
            switch (this.CurrentChar)
            {
                case '=':
                    token = new Token(TokenType.ASSIGN, this.CurrentChar.ToString());
                    break;
                case '+':
                    token = new Token(TokenType.PLUS, this.CurrentChar.ToString());
                    break;
                case ',':
                    token = new Token(TokenType.COMMA, this.CurrentChar.ToString());
                    break;
                case ';':
                    token = new Token(TokenType.SEMICOLON, this.CurrentChar.ToString());
                    break;
                case '(':
                    token = new Token(TokenType.LPAREN, this.CurrentChar.ToString());
                    break;
                case ')':
                    token = new Token(TokenType.RPAREN, this.CurrentChar.ToString());
                    break;
                case '{':
                    token = new Token(TokenType.LBRACE, this.CurrentChar.ToString());
                    break;
                case '}':
                    token = new Token(TokenType.RBRACE, this.CurrentChar.ToString());
                    break;
                case (char) 0:
                    token = new Token(TokenType.EOF, "");
                    break;
                default:
                    if (this.IsLetter(this.CurrentChar))
                    {
                        var identifier = this.ReadIdentifier();
                        var type = Token.LookupIdentifier(identifier);

                        token = new Token(type, identifier);
                    }
                    else if (this.IsDigit(this.CurrentChar))
                    {
                        var number = this.ReadNumber();
                        token = new Token(TokenType.INT, number);
                    }
                    else
                    {
                        token = new Token(TokenType.ILLEGAL, this.CurrentChar.ToString());
                    }

                    break;
            }

            this.ReadChar();
            return token;
        }

        private void SkipWhiteSpace()
        {
            while (this.CurrentChar == ' '
                   || this.CurrentChar == '\t'
                   || this.CurrentChar == '\r'
                   || this.CurrentChar == '\n')
            {
                this.ReadChar();
            }
        }

        private string ReadNumber()
        {
            var number = this.CurrentChar.ToString();
            while (this.IsDigit(this.NextChar))
            {
                number += this.NextChar;
                this.ReadChar();
            }

            return number;
        }

        private bool IsDigit(char c)
        {
            return '0' <= c && c <= '9';
        }

        /// <summary>
        /// 文字を１文字読み進めて状態を更新
        /// </summary>
        void ReadChar()
        {
            // 終端文字か確認して現在の文字と次の文字を更新
            this.CurrentChar = this.Position >= this.Input.Length ? (char) 0 : this.Input[this.Position];
            this.NextChar = this.Position + 1 >= this.Input.Length ? (char) 0 : this.Input[this.Position + 1];
            this.Position++;
        }

        /// <summary>
        /// 現在の文字から識別子に対応している限り読み進めて, 識別子に対応した文字列を返す
        /// </summary>
        /// <returns></returns>
        string ReadIdentifier()
        {
            var identifier = this.CurrentChar.ToString();
            while (this.IsLetter(this.NextChar))
            {
                identifier += this.NextChar;
                this.ReadChar();
            }

            return identifier;
        }

        /// <summary>
        /// [a-zA-Z_]かどうか
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        bool IsLetter(char c)
        {
            return ('a' <= c && c <= 'z') || ('A' <= c && c <= 'Z') || (c == '_');
        }
    }
}
