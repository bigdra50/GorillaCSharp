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
            {"let", TokenType.LET},
            {"int", TokenType.INT},
            {"return", TokenType.RETURN_KEYWORD},
        };
    }

    public enum TokenType
    {
        // 不正なトークン, 終端
        ILLEGAL,
        EOF,
        IDENTIFY,
        INT,
        ASSIGN,
        PLUS,
        COMMA,
        SEMICOLON,
        LPAREN,
        RPAREN,
        LBRACE,
        RBRACE,
        FUNCTION,
        LET,
        RETURN_KEYWORD,

    }
}