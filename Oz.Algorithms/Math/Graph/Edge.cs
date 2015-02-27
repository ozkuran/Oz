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

    }
}
