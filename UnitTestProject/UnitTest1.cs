using System.Collections.Generic;
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
            var input = "=+*(){},;";
            var testTokens = new List<Token>
            {
                new Token(TokenType.EQUAL, "="),
                new Token(TokenType.TERM_OPERATOR, "+"),
                new Token(TokenType.FACTOR_OPERATOR, "*"),
                new Token(TokenType.LPAREN, "("),
                new Token(TokenType.RPAREN, ")"),
                new Token(TokenType.LBRACKET, "{"),
                new Token(TokenType.RBRACKET, "}"),
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
                @"float fragColor = 1;
int five = 5;
int ten = 10;
int add(int x, int y) {
    return x + y;                    
}
 int result = add(five, ten);
";

            var testTokens = new List<Token>()
            {
                // float fragColor = 1;
                new Token(TokenType.TYPE_KEYWORD, "float"),
                new Token(TokenType.IDENTIFY, "fragColor"),
                new Token(TokenType.EQUAL, "="),
                new Token(TokenType.NUMBER, "1"),
                new Token(TokenType.SEMICOLON, ";"),
                // int five = 5;
                new Token(TokenType.TYPE_KEYWORD, "int"),
                new Token(TokenType.IDENTIFY, "five"),
                new Token(TokenType.EQUAL, "="),
                new Token(TokenType.NUMBER, "5"),
                new Token(TokenType.SEMICOLON, ";"),
                // int ten = 10;
                new Token(TokenType.TYPE_KEYWORD, "int"),
                new Token(TokenType.IDENTIFY, "ten"),
                new Token(TokenType.EQUAL, "="),
                new Token(TokenType.NUMBER, "10"),
                new Token(TokenType.SEMICOLON, ";"),
                // int add(int x, int y) { return x + y; }
                new Token(TokenType.TYPE_KEYWORD, "int"),
                new Token(TokenType.IDENTIFY, "add"),
                new Token(TokenType.LPAREN, "("),
                new Token(TokenType.TYPE_KEYWORD, "int"),
                new Token(TokenType.IDENTIFY, "x"),
                new Token(TokenType.COMMA, ","),
                new Token(TokenType.TYPE_KEYWORD, "int"),
                new Token(TokenType.IDENTIFY, "y"),
                new Token(TokenType.RPAREN, ")"),
                new Token(TokenType.LBRACKET, "{"),
                new Token(TokenType.RETURN_KEYWORD, "return"),
                new Token(TokenType.IDENTIFY, "x"),
                new Token(TokenType.TERM_OPERATOR, "+"),
                new Token(TokenType.IDENTIFY, "y"),
                new Token(TokenType.SEMICOLON, ";"),
                new Token(TokenType.RBRACKET, "}"),
                // int result = add(five, ten);
                new Token(TokenType.TYPE_KEYWORD, "int"),
                new Token(TokenType.IDENTIFY, "result"),
                new Token(TokenType.EQUAL, "="),
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
    }
}