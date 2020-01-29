namespace GLSL2Shaderlab.Lexing
{
    public class Token
    {
        public Token(TokenType type, string literal)
        {
            this.Type = type;
            this.Literal = literal;
        }

        public TokenType Type { get; set; }
        public string Literal { get; set; }
    }

    public enum TokenType
    {
        // 不正なトークン, 終端
        ILLEGAL,
        EOF,
        
        TERM_OPERATOR,    // +, -
        FACTOR_OPERATOR,    // *, /, %
        COMPARE_OPERATOR,    // ==, !=, >, >=, <, <=
        LOGIC_OPERATOR,     // &&, ||
        EQUAL,    // =
        COMMA,     // ,
        SEMICOLON,    // ;
        LPAREN,    // (
        RPAREN,    // )
        LBRACKET,    // {
        RBRACKET,    // }
        RETURN_KEYWORD,    // return
        IF_KEYWORD,    // if
        ELSE_KEYWORD, 
        WHILE_KEYWORD,
        FOR_KEYWORD,
        OUT_KEYWORD,
        IN_KEYWORD,
        TYPE_KEYWORD,
        IDENTIFY,
        NUMBER,
        CHAR_ALPHABET,
        CHAR_NUMBER,
    }
}