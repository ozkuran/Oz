namespace Oz.Algorithms.Math.Graph
{
    public class Node
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }

        public Node(int NodeId, string NodeName)
        {
            Id = NodeId;
            Name = NodeName;
            Weight = 0;
        }
    }
}
