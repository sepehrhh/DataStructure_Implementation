using System;
using System.Collections.Generic;

namespace A11
{
    public class Node
    {
        public long Key;
        public Node Left, Right;

        public Node(long key)
        {
            Key = key;
        }
    }

    public class BinaryTree
    {
        public Node Root;
        public List<Node> Nodes = new List<Node>();

        public BinaryTree(long[][] nodes)
        {
            foreach (var node in nodes)
                Nodes.Add(new Node(node[0]));

            for (int i = 0; i < nodes.Length; i++)
            {
                if (nodes[i][1] != -1)
                    Nodes[i].Left = Nodes[(int)nodes[i][1]];
                if (nodes[i][2] != -1)
                    Nodes[i].Right = Nodes[(int)nodes[i][2]];
            }

            Root = Nodes[0];
        }

    }

}
