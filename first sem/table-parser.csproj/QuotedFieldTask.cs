using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TableParser
{
    [TestFixture]
    public class QuotedFieldTaskTests
    {
        [TestCase("''", 0, "", 2)]
        [TestCase("'a'", 0, "a", 3)]
        [TestCase("'\' ' ", 0, "", 2)]
        [TestCase("\"abcd\"", 0, "abcd", 6)]
        [TestCase(@"""p 'o' 'l' ly""", 0, "p 'o' 'l' ly", 14)]
        [TestCase("'polly cool", 0, "polly cool", 11)]

        public void Test(string line, int startIndex, string expectedValue, int expectedLength)
        {
            var actualToken = QuotedFieldTask.ReadQuotedField(line, startIndex);
            Assert.AreEqual(new Token(expectedValue, startIndex, expectedLength), actualToken);
        }
    }

    class QuotedFieldTask
    {
        public static Token ReadQuotedField(string line, int startIndex)
        {
            var currLength = 1;
            var stringBuilder = new StringBuilder();
            for (var i = startIndex + 1; i < line.Length; i++)
            {
                currLength++;
                if (line[i - 1] != '\\' && line[startIndex] == line[i])
                    break;
                if (line[i] != '\\')
                    stringBuilder.Append(line[i]);
            }
            return new Token(stringBuilder.ToString(), startIndex, currLength);
        }
    }
}
