using System.Collections.Generic;
using System.Linq;

namespace TextAnalysis
{
    static class TextGeneratorTask
    {
        public static string ContinuePhrase(Dictionary<string, string> nextWords, string phraseBeginning, int wordsCount)
        {
            var words = phraseBeginning.Split(' ').ToList();

            for (var i = 0; i < wordsCount; i++)
            {
                var oneLastWord = words[words.Count - 1];
                if (words.Count >= 2)
                {
                    var twoLastWord = words[words.Count - 2];
                    if (nextWords.ContainsKey(twoLastWord + " " + oneLastWord))
                        words.Add(nextWords[twoLastWord + " " + oneLastWord]);
                    else if (nextWords.ContainsKey(oneLastWord))
                        words.Add(nextWords[oneLastWord]);
                    else return string.Join(" ", words);
                }
                
                if (words.Count == 1 && (nextWords.ContainsKey(words[words.Count - 1])))
                {
                    if (nextWords.ContainsKey(oneLastWord))
                        words.Add(nextWords[oneLastWord]);
                    else return string.Join(" ", words);
                }
            }
            return string.Join(" ", words);
        }
    }
}