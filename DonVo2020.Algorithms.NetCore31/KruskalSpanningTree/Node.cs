using System.Collections.Generic;

namespace DonVo2020.Algorithms.NetCore31.KruskalSpanningTree
{
    public class Node
    {
        public string name;
        public int treeGroup;
        public List<Edge> edges = new List<Edge>();

        public Node() { }

        public Node(string pName)
        {
            name = pName;
            treeGroup = -1;
        }

        public override string ToString()
        { return this.name; }

    }
}
