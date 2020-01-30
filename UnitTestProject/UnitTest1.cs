using System.Collections.Generic;
using System.Data;
using Gorilla.Lexing;
using NUnit.Framework;

namespace UnitTestProject
{
    [TestFixture]
    public class LexerTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestNextToken1()
        {
            var input = "=+(){},;";
            var testTokens = new List<Token>
            {
                new Token(TokenType.ASSIGN, "="),
                new Token(TokenType.PLUS, "+"),
                new Token(TokenType.LPAREN, "("),
                new Token(TokenType.RPAREN, ")"),
                new Token(TokenType.LBRACE, "{"),
                new Token(TokenType.RBRACE, "}"),
                new Token(TokenType.COMMA, ","),
                new Token(TokenType.SEMICOLON, ";"),
                new Token(TokenType.EOF, "")
            };
            var lexer = new Lexer(input);
            Assert.AreEqual(input, input, "eeeee");

            foreach (var testToken in testTokens)
            {
                var token = lexer.NextToken();
                Assert.AreEqual(testToken.Type, token.Type, "トークンの種類が間違えています.");
                Assert.AreEqual(testToken.Literal, token.Literal, "トークンのリテラルが間違えています");
            }
        }

        [Test]
        public void TestNextToken2()
        {
            var input =
                @"int five = 5;
int ten = 10;
int add(int x, int y) {
    return x + y;                    
}
 int result = add(five, ten);
";

            var testTokens = new List<Token>()
            {
                new Token(TokenType.INT, "int"),
                new Token(TokenType.IDENTIFY, "five"),
                new Token(TokenType.ASSIGN, "="),
                new Token(TokenType.INT, "5"),
                new Token(TokenType.SEMICOLON, ";"),
                // int ten = 10;
                new Token(TokenType.INT, "int"),
                new Token(TokenType.IDENTIFY, "ten"),
                new Token(TokenType.ASSIGN, "="),
                new Token(TokenType.INT, "10"),
                new Token(TokenType.SEMICOLON, ";"),
                // int add(int x, int y) { return x + y; }
                new Token(TokenType.INT, "int"),
                new Token(TokenType.IDENTIFY, "add"),
                new Token(TokenType.LPAREN, "("),
                new Token(TokenType.INT, "int"),
                new Token(TokenType.IDENTIFY, "x"),
                new Token(TokenType.COMMA, ","),
                new Token(TokenType.INT, "int"),
                new Token(TokenType.IDENTIFY, "y"),
                new Token(TokenType.RPAREN, ")"),
                new Token(TokenType.LBRACE, "{"),
                new Token(TokenType.RETURN_KEYWORD, "return"),
                new Token(TokenType.IDENTIFY, "x"),
                new Token(TokenType.PLUS, "+"),
                new Token(TokenType.IDENTIFY, "y"),
                new Token(TokenType.SEMICOLON, ";"),
                new Token(TokenType.RBRACE, "}"),
                // int result = add(five, ten);
                new Token(TokenType.INT, "int"),
                new Token(TokenType.IDENTIFY, "result"),
                new Token(TokenType.ASSIGN, "="),
                new Token(TokenType.IDENTIFY, "add"),
                new Token(TokenType.LPAREN, "("),
                new Token(TokenType.IDENTIFY, "five"),
                new Token(TokenType.COMMA, ","),
                new Token(TokenType.IDENTIFY, "ten"),
                new Token(TokenType.RPAREN, ")"),
                new Token(TokenType.SEMICOLON, ";"),
                new Token(TokenType.EOF, ""),
            };
            var lexer = new Lexer(input);

            foreach (var testToken in testTokens)
            {
                var token = lexer.NextToken();
                Assert.AreEqual(testToken.Type, token.Type, "トークンの種類が間違えています.");
                Assert.AreEqual(testToken.Literal, token.Literal, "トークンのリテラルが間違えています");
            }
        }

        [Test]
        public void TestNextToken3()
        {
            var input = "1 == 1; 1 != 0; ><*/-=";

            var testTokens = new List<Token>()
            {
                // 1 == 1;
                new Token(TokenType.INT, "1"),
                new Token(TokenType.EQ, "=="),
                new Token(TokenType.INT, "1"),
                new Token(TokenType.SEMICOLON, ";"),
                // 1 != 0;
                new Token(TokenType.INT, "1"),
                new Token(TokenType.NOT_EQ, "!="),
                new Token(TokenType.INT, "0"),
                new Token(TokenType.SEMICOLON, ";"),
                // ><*/-=
                new Token(TokenType.GT, ">"),
                new Token(TokenType.LT, "<"),
                new Token(TokenType.ASTERISK, "*"),
                new Token(TokenType.SLASH, "/"),
                new Token(TokenType.MINUS, "-"),
                new Token(TokenType.ASSIGN, "="),
                new Token(TokenType.EOF, ""),
            };

            var lexer = new Lexer(input);

            foreach (var testToken in testTokens)
            {
                var token = lexer.NextToken();
                Assert.AreEqual(testToken.Type, token.Type, "トークンの種類が間違っています.");
                Assert.AreEqual(testToken.Literal, token.Literal, "トークンのリテラルが間違っています.");
            }
        }

        [Test]
        public void TestNextToken4()
        {
            var input = @"if (5 < 10) {
    return true;
} else {
    return false;
}";
            var testTokens = new List<Token>()
            {
                new Token(TokenType.IF_STATEMENT, "if"),
                new Token(TokenType.LPAREN, "("),
                new Token(TokenType.INT, "5"),
                new Token(TokenType.LT, "<"),
                new Token(TokenType.INT, "10"),
                new Token(TokenType.RPAREN, ")"),
                new Token(TokenType.LBRACE, "{"),
                new Token(TokenType.RETURN_KEYWORD, "return"),
                new Token(TokenType.TRUE, "true"),
                new Token(TokenType.SEMICOLON, ";"),
                new Token(TokenType.RBRACE, "}"),
                new Token(TokenType.ELSE, "else"),
                new Token(TokenType.LBRACE, "{"),
                new Token(TokenType.RETURN_KEYWORD, "return"),
                new Token(TokenType.FALSE, "false"),
                new Token(TokenType.SEMICOLON, ";"),
                new Token(TokenType.RBRACE, "}"),
                new Token(TokenType.EOF, ""),
            };

            var lexer = new Lexer(input);
            foreach (var testToken in testTokens)
            {
                var token = lexer.NextToken();
                Assert.AreEqual(testToken.Type, token.Type, "トークンの種類が間違えています.");
                Assert.AreEqual(testToken.Literal, token.Literal, "トークンのリテラルが間違えています.");
            }
        }
    }
}