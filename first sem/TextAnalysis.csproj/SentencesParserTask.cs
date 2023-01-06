using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static List<List<string>> ParseSentences(string text)
        {
            var sentencesList = new List<List<string>>();
            var separator = new[] {'.', '!', '?', ';', ':', '(', ')'};
            var sentences = text.Split(separator, StringSplitOptions.RemoveEmptyEntries).ToList();

            foreach (var sentence in sentences){
                if (SeparateWords(sentence).Count > 0)
                    sentencesList.Add(SeparateWords(sentence));
            }
            return sentencesList;
        }

        private static List<string> SeparateWords(string sentence)
        {
            var newWord = new StringBuilder();
            var words = new List<string>();
            foreach (var symbol in sentence)
            {
                if (char.IsLetter(symbol) || symbol == '\'')
                    newWord.Append(symbol.ToString().ToLower());
                else if (newWord.Length > 0)
                {
                    words.Add(newWord.ToString());
                    newWord.Clear();
                }
            }
            if (newWord.Length > 0) words.Add(newWord.ToString());
            return words;
        }
    }
}   