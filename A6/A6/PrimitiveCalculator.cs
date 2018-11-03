using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class PrimitiveCalculator: Processor
    {
        public PrimitiveCalculator(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[]>)Solve);

        public long[] Solve(long n)
        {
            var memory = new Dictionary<long, List<long>>() { { 1, new List<long>() { 1 } } };
            for (int i = 2; i <= n; i++)
            {
                var elementKey = FindElementKey(i, memory);
                var element = memory[elementKey.Key].ToList();
                element.Add(i);
                memory.Add(i, element);
            }

            return memory[n].ToArray();
        }

        private KeyValuePair<long, long> FindElementKey(int n, Dictionary<long, List<long>> memory)
        {
            var searchingIndexesList = new List<double>() { n - 1, (double)n / 2,
                (double)n / 3 }.Where(x => x == (int)x).OrderBy(x => x);
            var memoryElements = new Dictionary<long, long>();
            foreach (var i in searchingIndexesList)
                if (!memoryElements.ContainsKey((long)i))
                    memoryElements.Add((long)i, memory[(long)i].Count);
            return memoryElements.OrderBy(x => x.Value).First();
        }
    }
}
