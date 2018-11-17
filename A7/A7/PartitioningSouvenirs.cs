using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A7
{
    public class PartitioningSouvenirs : Processor
    {
        public PartitioningSouvenirs(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public long Solve(long souvenirsCount, long[] souvenirs)
        {
            if (souvenirsCount < 3 || souvenirs.Sum() % 3 != 0)
                return 0;

            long partialSum = souvenirs.Sum() / 3;
            long[,] DPTable = new long[partialSum + 1, souvenirsCount + 1];

            for (int i = 0; i <= partialSum; i++)
                DPTable[i, 0] = 0;
            for (int i = 0; i <= souvenirsCount; i++)
                DPTable[0, i] = 0;

            for (int i = 1; i <= partialSum; i++)
                for (int j = 1; j <= souvenirsCount; j++)
                {
                    var previouslyAddedElement = i - souvenirs[j - 1];
                    if (souvenirs[j - 1] == i || (previouslyAddedElement > 0 && DPTable[previouslyAddedElement, j - 1] > 0))
                    {
                        if (DPTable[i, j - 1] == 0)
                            DPTable[i, j] = 1;
                        else
                            DPTable[i, j] = 2;
                    }
                    else
                        DPTable[i, j] = DPTable[i, j - 1];
                }

            if (DPTable[partialSum, souvenirsCount] == 2)
                return 1;
            else
                return 0;
        }
    }
}
