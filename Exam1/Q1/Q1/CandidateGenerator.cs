using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1
{
    public static class CandidateGenerator
    {
        public static readonly char[] Alphabet =
            Enumerable.Range('a', 'z' - 'a' + 1)
                      .Select(c => (char)c)
                      .ToArray();

        public static string[] GetCandidates(string word)
        {
            List<string> candidates = new List<string>();

            for (int i = 0; i < word.Length; i++)
            {
                candidates.Add(Delete(word, i));
                foreach (var j in Alphabet)
                {
                    candidates.Add(Insert(word, i, j));
                    if (i == word.Length - 1)
                        candidates.Add(Insert(word, i + 1, j));
                    candidates.Add(Substitute(word, i, j));
                }
            }

            return candidates.ToArray();
        }

        private static string Insert(string word, int pos, char c)
        {
            char[] wordChars = word.ToCharArray();
            var newWord = word.Insert(pos, c.ToString());
            return newWord;
        }

        private static string Delete(string word, int pos)
        {
            char[] wordChars = word.ToCharArray();
            var newWord = word.Remove(pos, 1);
            return newWord;
        }

        private static string Substitute(string word, int pos, char c)
        {
            char[] wordChars = word.ToCharArray();
            var newWord = word.Remove(pos, 1);
            newWord = newWord.Insert(pos, c.ToString());
            return newWord;
        }

    }
}
