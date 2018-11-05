using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1
{
    public class SpellChecker
    {
        public readonly FastLM LanguageModel;

        public SpellChecker(FastLM lm)
        {
            this.LanguageModel = lm;
        }

        public string[] Check(string misspelling)
        {
            List<WordCount> candidates = 
                new List<WordCount>();

            var generatedCandidates = CandidateGenerator.
                GetCandidates(misspelling).ToList();

            ulong count = 0;
            foreach (var i in generatedCandidates)
            {
                count = 0;
                if (LanguageModel.GetCount(i, out count))
                {
                    var newWord = new WordCount(i, count);
                    candidates.Add(newWord);
                }
            }

            return candidates
                    .OrderByDescending(x => x.Count)
                    .Select(x => x.Word)
                    .Distinct()
                    .ToArray();
        }

        public string[] SlowCheck(string misspelling)
        {
            List<WordCount> candidates =
                new List<WordCount>();

            // TODO

            return candidates
                    .OrderByDescending(x => x.Count)
                    .Select(x => x.Word)
                    .Distinct()
                    .ToArray();
        }

        public int EditDistance(string str1, string str2)
        {
            int n = str1.Length;
            int m = str2.Length;

            int[,] Distance = new int[n + 1, m + 1];
            for (int i = 0; i < n + 1; i++)
            {
                Distance[i, 0] = i;
            }

            for (int j = 0; j < m + 1; j++)
            {
                Distance[0, j] = j;
            }

            for (int j = 1; j <= m; j++)
            {
                for (int i = 1; i <= n; i++)
                {
                    if (str1[i] == str2[j])
                        Distance[i, j] = Distance[i - 1, j - 1];
                    else
                        Distance[i, j] = Math.Min(Distance[i - 1, j - 1] + 1,
                            Math.Min(Distance[i, j - 1], Distance[i - 1, j]));
                }
            }
            return Distance[n, m];
        }
    }
}
