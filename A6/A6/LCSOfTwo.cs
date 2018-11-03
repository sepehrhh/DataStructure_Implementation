using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class LCSOfTwo: Processor
    {
        public LCSOfTwo(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long>)Solve);

        public long Solve(long[] seq1, long[] seq2)
        {
            int n = seq1.Length;
            int m = seq2.Length;
            var lengthTable = new long[m + 1, n + 1];

            for (int i = 0; i < m + 1; i++)
                for (int j = 0; j < n + 1; j++)
                {
                    if (i == 0)
                        lengthTable[i, j] = 0;

                    else if (j == 0)
                        lengthTable[i, j] = 0;

                    else if (seq1[j - 1] == seq2[i - 1])
                        lengthTable[i, j] = lengthTable[i - 1, j - 1];

                    else
                        lengthTable[i, j] = Math.Min(lengthTable[i, j - 1] + 1,
                            Math.Min(lengthTable[i - 1, j] + 1,
                            lengthTable[i - 1, j - 1] + 1));
                }
            return 0;
        }
    }
}
