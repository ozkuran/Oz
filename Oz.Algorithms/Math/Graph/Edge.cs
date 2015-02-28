using System;

namespace Oz.Algorithms.Math.Graph
{
    public class Edge
    {
        public int Id { get; set; }
        public Node Node1 { get; set; }
        public Node Node2 { get; set; }
        public int Weight { get; set; }
        public double NormalizedWeight { get; set; }

        public Edge()
        {
            Id = 0;
            Weight = 0;
        }

        public Edge(Node node1, Node node2)
        {
            Id = 0;
            Node1 = node1;
            Node2 = node2;
            Weight = 1;
            NormalizedWeight = 0;
        }

        public Edge(int id, Node node1, Node node2)
        {
            Id = id;
            Node1 = node1;
            Node2 = node2;
            Weight = 1;
            NormalizedWeight = 0;
        }

        /// <summary>
        /// Returns true if given Node present in Edge
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool IsNodePresent(Node node)
        {
            var result = Node1.Id == node.Id || Node2.Id == node.Id;
            return result;
        }


        /// <summary>
        /// Returns the node of edge other node than given node
        /// If given node not in edge returns -1
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public int GetOtherNode(Node node)
        {
            var result = -1;
            if (Node1.Id == node.Id)
            {
                result = Node2.Id;
            }
            else if (Node2.Id == node.Id)
            {
                result = Node2.Id;
            }
            return result;
        }
    }
}
