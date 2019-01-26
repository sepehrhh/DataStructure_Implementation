using System;
using TestCommon;

namespace A11
{
    public class IsItBSTHard : Processor
    {
        public IsItBSTHard(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[][], bool>)Solve);


        public bool Solve(long[][] nodes)
        {
            var Tree = new BinaryTree(nodes);
            return IsBST(Tree.Root, int.MinValue, int.MaxValue);
        }

        public bool IsBST(Node node, int min, int max)
        {
            if (node == null)
                return true;

            if (node.Key < min || node.Key > max)
                return false;

            return (IsBST(node.Left, min, (int)node.Key - 1) && IsBST(node.Right, (int)node.Key, max));
        }
    }
}
