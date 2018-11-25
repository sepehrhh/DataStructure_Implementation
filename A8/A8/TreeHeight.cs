using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A8
{
    public class TreeHeight : Processor
    {
        public TreeHeight(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public long Solve(long nodeCount, long[] tree)
        {
            var nodesDic = new Dictionary<long, List<long>>();
            long treeRoot = 0;

            for (int i = 0; i < nodeCount; i++)
            {
                if (!nodesDic.ContainsKey(tree[i]))
                    nodesDic.Add(tree[i], new List<long>() { i });
                else
                    nodesDic[tree[i]].Add(i);
            }
            treeRoot = nodesDic[-1][0];
            Queue<long> queue = new Queue<long>();
            queue.Enqueue(treeRoot);

            long treeHeight = 0;
            while (queue.Count != 0)
            {
                var queueCount = queue.Count();
                for (int i = 0; i < queueCount; i++)
                {
                    long currentNode = queue.Dequeue();

                    if (nodesDic.ContainsKey(currentNode))
                        foreach (var node in nodesDic[currentNode])
                            queue.Enqueue(node);
                }
                treeHeight++;
            }

            return treeHeight;
        }

    }
}
