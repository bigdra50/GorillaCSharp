using System.Collections.Generic;
using NUnit.Framework;
using GLSL2Shaderlab.Lexing;

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
    }
}