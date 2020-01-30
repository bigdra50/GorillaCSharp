using System.Collections.Generic;

namespace Gorilla.Lexing
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

        /// <summary>
        /// 引数が識別子か予約語か判定
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public static TokenType LookupIdentifier(string identifier)
        {
            if (Token.Keywords.ContainsKey(identifier))
            {
                return Keywords[identifier];
            }

            return TokenType.IDENTIFY;
        }
        
        public static Dictionary<string, TokenType> Keywords = new Dictionary<string, TokenType>()
        {
            {"return", TokenType.RETURN_KEYWORD},
            {"int", TokenType.TYPE_KEYWORD},
            {"float", TokenType.TYPE_KEYWORD}
        };
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
        COLON,    //:
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