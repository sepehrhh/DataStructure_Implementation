using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1
{
    public class FastLM
    {
        public readonly WordCount[] WordCounts;


        public FastLM(WordCount[] wordCounts)
        {
            this.WordCounts = wordCounts.OrderBy(wc => wc.Word).ToArray();
        }

        public bool GetCount(string word, out ulong count)
        {
            count = 0;
            BinarySearch(word, 0, WordCounts.Length - 1, out count);
            if (count != 0)
                return true;
            else
                return false;
        }

        private void BinarySearch(string word, int low, int high, out ulong count)
        {
            var middleElementIndex = (high + low) / 2;
            var middleElement = WordCounts[middleElementIndex];
            while (word != middleElement.Word)
            {
                if (high - low <= 1)
                {
                    count = WordCounts[middleElementIndex + 1].Count;
                    return;
                }

                if (String.Compare(word, middleElement.Word) < 0)
                {
                    high = middleElementIndex - 1;
                    middleElementIndex = (high + low) / 2;
                    middleElement = WordCounts[middleElementIndex];
                }

                else
                {
                    low = middleElementIndex;
                    middleElementIndex = (high + low) / 2;
                    middleElement = WordCounts[middleElementIndex];
                }
            }
            count = middleElement.Count;
            if (word != middleElement.Word)
                count = 0;
        }

    }
}
