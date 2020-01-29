namespace GLSL2Shaderlab.Lexing
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
            var token = (Token) null;
            switch (this.CurrentChar)
            {
                case '=':
                    token = new Token(TokenType.EQUAL, this.CurrentChar.ToString());
                    break;
                case '+':
                case '-':
                    token = new Token(TokenType.TERM_OPERATOR, this.CurrentChar.ToString());
                    break;
                case '*':
                case '/':
                case '%':
                    token = new Token(TokenType.FACTOR_OPERATOR, this.CurrentChar.ToString());
                    break;
                case ',':
                    token = new Token(TokenType.COMMA, this.CurrentChar.ToString());
                    break;
                case ';':
                    token = new Token(TokenType.SEMICOLON, this.CurrentChar.ToString());
                    break;
                case ':':
                    token = new Token(TokenType.COLON, this.CurrentChar.ToString());
                    break;
                case '(':
                    token = new Token(TokenType.LPAREN, this.CurrentChar.ToString());
                    break;
                case ')':
                    token = new Token(TokenType.RPAREN, this.CurrentChar.ToString());
                    break;
                case '{':
                    token = new Token(TokenType.LBRACKET, this.CurrentChar.ToString());
                    break;
                case '}':
                    token = new Token(TokenType.RBRACKET, this.CurrentChar.ToString());
                    break;
                case (char)0:
                    token = new Token(TokenType.EOF, "");
                    break;
            }
            this.ReadChar();
            return token;
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
    }
}