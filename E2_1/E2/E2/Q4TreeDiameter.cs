using System;
using System.Collections.Generic;
using System.Linq;

namespace E2
{
    public class Q4TreeDiameter
    {
        /// <summary>
        /// ریشه همیشه نود صفر است.
        ///توی این آرایه در مکان صفر لیستی از بچه های ریشه موجودند.
        ///و در مکانه آی از این آرایه لیست بچه های نود آیم هستند
        ///اگر لیست خالی بود، بچه ندارد
        /// </summary>
        public List<int>[] Nodes;

        public Q4TreeDiameter(int nodeCount, int seed = 0)
        {
            Nodes = GenerateRandomTree(size: nodeCount, seed: seed);
        }

        public int TreeHeight(int root)
        {
            var childsList = Nodes[root];
            if (Nodes[root] == null)
                return 1;
            var heights = new int[Nodes[root].Count];
            for (int i = 0; i < heights.Length; i++)
                heights[i] += 2;
            foreach (var node in childsList)
            {
                if (Nodes[node].Count != 0)
                    heights[childsList.IndexOf(node)] += GetHeight(Nodes[node]);
            }

            return heights.Max();
        }

        public int GetHeight(List<int> list)
        {
            var heights = new int[list.Count];
            for (int i = 0; i < list.Count; i++)
                heights[i] += 1;
            foreach (var node in list)
            {
                if (Nodes[node].Count != 0)
                    heights[list.IndexOf(node)] += GetHeight(Nodes[node]);
            }
            return heights.Max();
        }

        public int TreeHeightFromNode(int node)
        {
            if (Nodes.Count(x => x.Contains(node)) > 0)
                RotateTree(Array.IndexOf(Nodes, Nodes.Where(x => x.Contains(node)).First()), node);
            return TreeHeight(node);
        }

        private void RotateTree(int parent, int child)
        {
            Nodes[parent].Remove(child);
            Nodes[child].Add(parent);
            for (int i = 0; i < Nodes.Length; i++)
                if (Nodes[i].Contains(parent) && i != child)
                {
                    RotateTree(i, parent);
                    break;
                }
        }

        public int TreeDiameterN2()
        {
            var diameters = new List<int>();
            for (int i = 0; i < Nodes.Length; i++)
                diameters.Add(TreeHeightFromNode(i));
            return diameters.Max();
        }

        public int TreeDiameterN()
        {
            var diameters = new List<int>();
            for (int i = 0; i < Nodes.Length; i++)
                diameters.Add(TreeHeightFromNodeDP(i));

            return diameters.Max();
        }

        private int TreeHeightFromNodeDP(int node)
        {
            var height = 1;
            if (Nodes.Count(x => x.Contains(node)) > 0)
                RotateTreeDP(Array.IndexOf(Nodes, Nodes.Where(x => x.Contains(node)).First()), node, ref height);
            return height;
        }

        private void RotateTreeDP(int parent, int child, ref int height)
        {
            Nodes[parent].Remove(child);
            Nodes[child].Add(parent);
            for (int i = 0; i < Nodes.Length; i++)
                if (Nodes[i].Contains(parent) && i != child)
                {
                    height++;
                    RotateTreeDP(i, parent, ref height);
                    break;
                }
        }

        private static List<int>[] GenerateRandomTree(int size, int seed)
        {
            Random rnd = new Random(seed);
            List<int>[] nodes = Enumerable.Range(0, size)
                .Select(n => new List<int>())
                .ToArray();
            
            List<int> orphans = 
                new List<int>(Enumerable.Range(1, size-1)); // 0 is root it will remain orphan
            Queue<int> parentsQ = new Queue<int>();
            parentsQ.Enqueue(0);
            while (orphans.Count > 0)
            {
                int parent = parentsQ.Dequeue();
                int childCount = rnd.Next(1, 4);
                for (int i=0; i< Math.Min(childCount, orphans.Count); i++)
                {
                    int orphanIdx = rnd.Next(0, orphans.Count-1);
                    int orphan = orphans[orphanIdx];
                    orphans.RemoveAt(orphanIdx);
                    nodes[parent].Add(orphan);
                    parentsQ.Enqueue(orphan);
                }
            }
            return nodes;
        }
    }
}