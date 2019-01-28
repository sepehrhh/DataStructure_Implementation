﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TestCommon;

namespace A12
{
    public class Q4OrderOfCourse: Processor
    {
        public Q4OrderOfCourse(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[][], long[]>)Solve);

        private List<long> Answer;

        public long[] Solve(long nodeCount, long[][] edges)
        {
            Answer = new List<long>((int)nodeCount);
            var adjacencyList = new List<List<long>>((int)nodeCount);
            for (int i = 0; i < nodeCount; i++)
                adjacencyList.Add(new List<long>());
            var visited = new bool[nodeCount];
           
            foreach (var edge in edges)
                adjacencyList[(int)edge[0] - 1].Add(edge[1] - 1);
            for (int i = 0; i < adjacencyList.Count; i++)
                if (!visited[i])
                    DFS(adjacencyList, visited, i);
            Answer.Reverse();
            return Answer.ToArray();
        }

        private void DFS(List<List<long>> adjacencyList, bool[] visited, int i)
        {
            visited[i] = true;
            var children = adjacencyList[i];
            for (int j = 0; j < children.Count; j++)
                if (!visited[children[j]])
                    DFS(adjacencyList, visited, (int)children[j]);
            Answer.Add(i + 1);
        }

        public override Action<string, string> Verifier { get; set; } = TopSortVerifier;

        /// <summary>
        /// کد شما با متد زیر راست آزمایی میشود
        /// این کد نباید تغییر کند
        /// داده آزمایشی فقط یک جواب درست است
        /// تنها جواب درست نیست
        /// </summary>
        public static void TopSortVerifier(string inFileName, string strResult)
        {
            long[] topOrder = strResult.Split(TestTools.IgnoreChars)
                .Select(x => long.Parse(x)).ToArray();

            long count;
            long[][] edges;
            TestTools.ParseGraph(File.ReadAllText(inFileName), out count, out edges);

            // Build an array for looking up the position of each node in topological order
            // for example if topological order is 2 3 4 1, topOrderPositions[2] = 0, 
            // because 2 is first in topological order.
            long[] topOrderPositions = new long[count];
            for (int i = 0; i < topOrder.Length; i++)
                topOrderPositions[topOrder[i] - 1] = i;
            // Top Order nodes is 1 based (not zero based).

            // Make sure all direct depedencies (edges) of the graph are met:
            //   For all directed edges u -> v, u appears before v in the list
            foreach (var edge in edges)
                if (topOrderPositions[edge[0] - 1] >= topOrderPositions[edge[1] - 1])
                    throw new InvalidDataException(
                        $"{Path.GetFileName(inFileName)}: " +
                        $"Edge dependency violoation: {edge[0]}->{edge[1]}");

        }
    }
}
