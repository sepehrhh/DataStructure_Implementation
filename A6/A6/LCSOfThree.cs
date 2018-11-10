using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class LCSOfThree: Processor
    {
        public LCSOfThree(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[], long>)Solve);

        public long Solve(long[] seq1, long[] seq2, long[] seq3)
        {
            return LCS(seq1, seq2, seq3, seq1.Length, seq2.Length, seq3.Length);
        }

        private static long LCS(long[] seq1, long[] seq2, long[] seq3,
            int length1, int length2, int length3)
        {
            int[,,] LCSTable = new int[length1 + 1, length2 + 1, length3 + 1];

            for (int i = 0; i <= length1; i++)
            {
                for (int j = 0; j <= length2; j++)
                {
                    for (int k = 0; k <= length3; k++)
                    {
                        if (i == 0 || j == 0 || k == 0)
                            LCSTable[i, j, k] = 0;

                        else if (seq1[i - 1] == seq2[j - 1] &&
                            seq1[i - 1] == seq3[k - 1])
                            LCSTable[i, j, k] = LCSTable[i - 1, j - 1, k - 1] + 1;

                        else
                            LCSTable[i, j, k] = Math.Max(Math.Max(LCSTable[i - 1, j, k],
                                                           LCSTable[i, j - 1, k]),
                                                           LCSTable[i, j, k - 1]);
                    }
                }
            }
            return LCSTable[length1, length2, length3];
        }
    }
}
