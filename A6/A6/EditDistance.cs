using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class EditDistance: Processor
    {
        public EditDistance(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, string, long>)Solve);

        public long Solve(string str1, string str2)
        {
            int n = str1.Length;
            int m = str2.Length;
            var costTable = new long[m + 1, n + 1];

            for (int i = 0; i < m + 1; i++)
                for (int j = 0; j < n + 1; j++)
                {
                    if (i == 0)
                        costTable[i, j] = j;

                    else if (j == 0)
                        costTable[i, j] = i;

                    else if (str1[j - 1] == str2[i - 1])
                        costTable[i, j] = costTable[i - 1, j - 1];

                    else
                        costTable[i, j] = Math.Min(costTable[i, j - 1] + 1,
                            Math.Min(costTable[i - 1, j] + 1,
                            costTable[i - 1, j - 1] + 1));
                }

            return costTable[m, n];
        }

    }
}
