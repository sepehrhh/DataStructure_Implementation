using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class MoneyChange: Processor
    {
        private static readonly int[] COINS = new int[] {1, 3, 4};

        public MoneyChange(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>) Solve);

        public long Solve(long n)
        {
            var memory = new List<long>() { 1, 2, 1, 1};

            for (int i = 4; i < n; i++)
                memory.Add(Math.Min(memory[i - COINS[0]], 
                    Math.Min(memory[i - COINS[1]], memory[i - COINS[2]])) + 1);

            return memory[(int)n - 1];
        }
    }
}
