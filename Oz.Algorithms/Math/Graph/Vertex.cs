namespace Oz.Algorithms.Math.Graph
{
    public class Vertex
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }

        public Vertex(int NodeId, string NodeName)
        {
            Id = NodeId;
            Name = NodeName;
            Weight = 0;
        }
    }
}
