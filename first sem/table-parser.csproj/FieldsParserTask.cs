using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace TableParser
{
    [TestFixture]
    public class FieldParserTaskTests
    {
        public static void Test(string input, string[] expectedResult)
        {
            var actualResult = FieldsParserTask.ParseLine(input);
            Assert.AreEqual(expectedResult.Length, actualResult.Count);
            for (var i = 0; i < expectedResult.Length; ++i)
            {
                Assert.AreEqual(expectedResult[i], actualResult[i].Value);
            }
        }
        
        [TestCase("'\\\'polina\\\''", new[] { "'polina'" })]
        [TestCase("a\"b\"", new[] { "a", "b" })]
        [TestCase("\"a\"b", new[] { "a", "b" })]
        [TestCase("a\"b\"", new[] { "a", "b" })]
        [TestCase("\"\\\\\"", new[] {"\\"})]
        [TestCase("\"\\\\'", new[] {"\\'"})]
        [TestCase("'\"lloppy\"", new[] { "\"lloppy\"" })]
        [TestCase("i am polina", new[] { "i", "am", "polina" })]
        [TestCase("' ", new[] { " " })]
        [TestCase("polina", new[] { "polina" })]
        [TestCase("", new string[0])]
        [TestCase("polina  ank", new[] { "polina", "ank" })]        
        [TestCase(" polina ank", new[] { "polina", "ank" })]
        [TestCase("\"'polina' ank\"", new[] { "'polina' ank" })]
        [TestCase("' ", new[] { " " })]
        [TestCase("\'\'", new[] { "" })]
        [TestCase("\"\\\"progacool\\\"\"", new[] { "\"progacool\"" })]
        [TestCase("'\\\'text\\\''", new[] { "'text'" })]
        [TestCase("'\"text\"", new[] { "\"text\"" })]
        [TestCase("im\"cool\"", new[] { "im", "cool" })]

        
        
        public static void RunTests(string input, string[] expectedOutput)
          {
            Test(input, expectedOutput);
          }
    }

    public class FieldsParserTask
    {
        public static List<Token> ParseLine(string line)
        {
            var tokenList = new List<Token>();
            var position = 0;
            while (position < line.Length)
            {
                if (line[position] == ' ')
                    position += CountSpace(line, position);
                else
                {
                    if (line[position] == '\'' || line[position] == '\"')
                        tokenList.Add(ReadQuotedField(line, position));
                    else
                        tokenList.Add(ReadField(line, position));
                    position += tokenList[tokenList.Count - 1].Length;
                }
            }   
            return tokenList;        
        }

        public static int CountSpace(string line, int startIndex)
        {
            var count = 0;
            var position = startIndex;
            while (true)
            {
                if (position >= line.Length) break;
                if (line[position] == ' ')
                {
                    count++;
                    position++;
                }
                break;
            }
            return count;        
        }

        private static Token ReadField(string line, int startIndex)
        {
            var stringBuilder = new StringBuilder();
            for (var i = startIndex; i < line.Length; i++)
            {
                if (line[i] == '\'' || line[i] == ' ' || line[i] == '\"' )
                    break;
                stringBuilder.Append(line[i]);
            }
            return new Token(stringBuilder.ToString(), startIndex, stringBuilder.Length);        
        }

        public static Token ReadQuotedField(string line, int startIndex)
        {
            return QuotedFieldTask.ReadQuotedField(line, startIndex);
        }
    }
}