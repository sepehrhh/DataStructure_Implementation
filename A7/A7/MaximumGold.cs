using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A7
{
    public class MaximumGold : Processor
    {
        public MaximumGold(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public long Solve(long W, long[] goldBars)
        {
            var goldBarsCount = goldBars.Length;
            var knapSackTable = new long[goldBarsCount + 1, W + 1];

            for (int i = 0; i <= goldBarsCount; i++)
                knapSackTable[i, 0] = 0;
            for (int i = 0; i <= W; i++)
                knapSackTable[0, i] = 0;

            for (int goldBarIndex = 1; goldBarIndex <= goldBarsCount;
                goldBarIndex++)
            {
                for (int capacity = 1; capacity <= W; capacity++)
                {
                    knapSackTable[goldBarIndex, capacity] = 
                        knapSackTable[goldBarIndex - 1, capacity];

                    if (goldBars[goldBarIndex - 1] <= capacity)
                    {
                        var maxValue = knapSackTable[goldBarIndex - 1,
                            capacity - goldBars[goldBarIndex - 1]] +
                            goldBars[goldBarIndex - 1];
                        if (maxValue > knapSackTable[goldBarIndex, capacity])
                            knapSackTable[goldBarIndex, capacity] = maxValue;
                    }
                }
            }
            return knapSackTable[goldBarsCount, W];
        }
    }
}
