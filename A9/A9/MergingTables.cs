using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A9
{
    public class MergingTables : Processor
    {
        public MergingTables(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[], long[]>)Solve);

        public long[] Solve(long[] tableSizes, long[] sourceTables, long[] targetTables)
        {
            var disjointSet = new DisjointSet(tableSizes);
            var result = new List<long>();
            for (int i = 0; i < sourceTables.Length; i++)
            {
                disjointSet.Union((int)sourceTables[i] - 1, (int)targetTables[i] - 1);
                result.Add(disjointSet.MaxSizeOfSet);
            }
            return result.ToArray();
        }
    }

    public class DisjointSet
    {

        private int Count { get; set; }
        private readonly int[] Parent;
        public int[] SizeOfSet;
        public long MaxSizeOfSet;

        public DisjointSet(long[] setsSizes)
        {
            this.Count = setsSizes.Length;
            this.Parent = new int[this.Count];
            this.SizeOfSet = new int[this.Count];
            this.MaxSizeOfSet = setsSizes.Max();

            for (int i = 0; i < this.Count; i++)
            {
                this.Parent[i] = i;
                this.SizeOfSet[i] = (int)setsSizes[i];
            }
        }

        private int Find(int i)
        {
            if (this.Parent[i] == i)
                return i;
            else
                return this.Find(this.Parent[i]);
        }

        public void Union(int source, int target)
        {
            int sourceParent = this.Find(source);
            int targetParent = this.Find(target);

            if (sourceParent == targetParent)
                return;

            this.Parent[sourceParent] = targetParent;
            this.SizeOfSet[targetParent] += this.SizeOfSet[sourceParent];
            if (this.SizeOfSet[targetParent] > this.MaxSizeOfSet)
                this.MaxSizeOfSet = this.SizeOfSet[targetParent];
            this.SizeOfSet[source] = 0;
        }

    }
}
