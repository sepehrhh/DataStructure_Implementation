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
            return LCS(seq1, seq2, seq1.Length, seq2.Length); ;
        }

        private static long LCS(long[] seq1, long[] seq2, int length1, int length2)
        {
            var LCSTable = new long[length1 + 1, length2 + 1];

            for (int i = 0; i < length1 + 1; i++)
                for (int j = 0; j < length2 + 1; j++)
                {
                    if (i == 0 || j == 0)
                        LCSTable[i, j] = 0;

                    else if (seq1[i - 1] == seq2[j - 1])
                        LCSTable[i, j] = LCSTable[i - 1, j - 1] + 1;

                    else
                        LCSTable[i, j] = Math.Max(LCSTable[i, j - 1],
                            LCSTable[i - 1, j]);
                }

            return LCSTable[length1, length2];
        }
    }
}
