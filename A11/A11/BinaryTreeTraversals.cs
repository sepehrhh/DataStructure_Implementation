using System;
using System.Collections.Generic;
using TestCommon;

namespace A11
{
    public class BinaryTreeTraversals : Processor
    {
        public BinaryTreeTraversals(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[][], long[][]>)Solve);

        private BinaryTree Tree;

        public long[][] Solve(long[][] nodes)
        {
            Tree = new BinaryTree(nodes);
            var preOrder = PreOrderTraversal();
            var inOrder = InOrderTraversal();
            var postOrder = PostOrderTraversal();

            return new long[][] { inOrder, preOrder, postOrder };
        }

        private long[] PreOrderTraversal()
        {
            var traversedList = new List<long>();
            Stack<Node> s = new Stack<Node>();
            s.Push(Tree.Root);

            while (s.Count > 0)
            {
                var currentNode = s.Peek();
                traversedList.Add(currentNode.Key);
                s.Pop();
                if (currentNode.Right != null)
                    s.Push(currentNode.Right);
                if (currentNode.Left != null)
                    s.Push(currentNode.Left);
            }

            return traversedList.ToArray();
        }

        private long[] InOrderTraversal()
        {
            var traversedList = new List<long>();
            Stack<Node> s = new Stack<Node>();
            var currentNode = Tree.Root;
            while (currentNode != null || s.Count > 0)
            {
                while (currentNode != null)
                {
                    s.Push(currentNode);
                    if (currentNode.Left != null)
                        currentNode = currentNode.Left;
                    else currentNode = null;
                }
                currentNode = s.Pop();
                traversedList.Add(currentNode.Key);
                if (currentNode.Right != null)
                    currentNode = currentNode.Right;
                else currentNode = null;
            }

            return traversedList.ToArray();
        }

        private long[] PostOrderTraversal()
        {
            var traversedList = new List<long>();
            Stack<Node> s = new Stack<Node>();
            var currentNode = Tree.Root;
            s.Push(currentNode);
            Node prevNode = null;
            while (s.Count > 0)
            {
                currentNode = s.Peek();
                if (prevNode == null || prevNode.Left == currentNode
                    || prevNode.Right == currentNode)
                {
                    if (currentNode.Left != null)
                        s.Push(currentNode.Left);
                    else if (currentNode.Right != null)
                        s.Push(currentNode.Right);
                    else
                    {
                        s.Pop();
                        traversedList.Add(currentNode.Key);
                    }
                }
                else if (currentNode.Left != null &&
                        currentNode.Left == prevNode)
                {
                    if (currentNode.Right != null)
                        s.Push(currentNode.Right);
                    else
                    {
                        s.Pop();
                        traversedList.Add(currentNode.Key);
                    }
                }
                else if (currentNode.Right == prevNode)
                {
                    s.Pop();
                    traversedList.Add(currentNode.Key);
                }
                prevNode = currentNode;
            }

            return traversedList.ToArray();
        }
    }
}
