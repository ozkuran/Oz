using System.Collections.Generic;
using System.Linq;

namespace Oz.Algorithms.Math.Graph
{
    public class Graph
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Node> Nodes { get; set; }
        public List<Edge> Edges { get; set; }
        private int TotalEdgeWeight { get; set; }
        public int MaximumEdgeCount { get; set; }
        public double Density { get; set; }
        public int BiggestEdgeWeight { get; set; }


        public Graph()
        {
            Nodes = new List<Node>();
            Edges = new List<Edge>();
            TotalEdgeWeight = 0;
            MaximumEdgeCount = 0;
            Density = 0;
            BiggestEdgeWeight = 0;
        }


        /// <summary>
        /// Finds biggest Edge value in Graph
        /// </summary>
        private void FindBiggestEdgeValue()
        {
            var max = Edges.Select(edge => edge.Weight).Concat(new[] {0}).Max();
            BiggestEdgeWeight = max;
        }


        /// <summary>
        /// Calculates Density of The Graph
        /// </summary>
        public void CalculateDensity()
        {
            if (MaximumEdgeCount == 0)    
	        {
		        CalculateMaximumEdgeCount();
	        }
            Density = (double)MaximumEdgeCount / (double)Nodes.Count();
        }

        /// <summary>
        /// Calculates Maximum Edge Count to use with Graph Metrics
        /// </summary>
        public void CalculateMaximumEdgeCount()
        {
            var nodeCount = Nodes.Count;
            MaximumEdgeCount = nodeCount * (nodeCount - 1) / 2;
        }

        public int AddNode(string nodeName)
        {
            if (!IsNodeAdded(nodeName))
            {
                var node = new Node(Nodes.Count() + 1, nodeName);
                Nodes.Add(node);
                return Nodes.Count();
            }
            else
            {
                var node = Nodes.FirstOrDefault(x => x.Name == nodeName);
                if (node != null)
                {
                    node.Weight++;
                    return node.Id;
                }
                else
                {
                    return 0;
                }
            }
        }

        private bool IsNodeAdded(string nodeName)
        {
            return Nodes.Count(x => x.Name == nodeName) > 0;
        }

        private int GetNodeId(string nodeName)
        {
            var node = Nodes.FirstOrDefault(x => x.Name == nodeName);
            return node != null ? node.Id : 0;
        }
        /// <summary>
        /// Adds Edge to Graph
        /// </summary>
        /// <param name="edge">Enge to be added to graph</param>
        public void AddEdge(Edge edge)
        {
            var edgeId = GetEdgeId(edge.Node1.Name, edge.Node2.Name);
            if (edgeId > 0)
            {
                var edg = Edges.FirstOrDefault(x => x.Id == edgeId);
                if (edg != null) edg.Weight++;
            }
            else
            {
                var intNode1 = AddNode(edge.Node1.Name);
                var intNode2 = AddNode(edge.Node2.Name);
                edge.Node1.Id = intNode1;
                edge.Node2.Id = intNode2;
                edge.Weight = 1;
                edge.Id = Edges.Count() + 1;
                Edges.Add(edge);
            }
            TotalEdgeWeight++;
        }

        // Mahmut Ali ÖZKURAN 
        // 01/02/2015
        // Checks if Edge already defined
        // If not defined returns 0
        private bool IsEdgeAdded(Edge edge)
        {
            var edg = Edges.FirstOrDefault(x => ((x.Node1.Name == edge.Node1.Name) && (x.Node2.Name == edge.Node2.Name)));
            return edg != null;
        }

        // Mahmut Ali ÖZKURAN 
        // 01/02/2015
        // Returns id of Egde if already defined
        // If not defined returns 0
        private int GetEdgeId(string node1, string node2)
        {
            var edge = Edges.FirstOrDefault(x => ((x.Node1.Name == node1) && (x.Node2.Name == node2)));
            return edge != null ? edge.Id : 0;
        }


        /// <summary>
        /// Normalizing Weights of the Edges and sets those weights to Edges NormalizedWeight property
        /// </summary>
        public void NormalizeEdgeWeigths()
        {
            if (BiggestEdgeWeight == 0)
            {
                FindBiggestEdgeValue();
            }
            foreach (var edge in Edges)
            {
                edge.NormalizedWeight = ((double) edge.Weight / (double)BiggestEdgeWeight);
            }
        }


        // Mahmut Ali ÖZKURAN
        // 01/02/2015
        // Saves graph as GDF File
        public void SaveAsGdf(string filename)
        {
            var file = new System.IO.StreamWriter(@"Data\\" + filename + ".gdf");
            file.WriteLine("nodedef>name VARCHAR,weight DOUBLE");
            foreach (var node in Nodes)
            {
                file.WriteLine(node.Name + ", " + node.Weight);
            }
            file.WriteLine("edgedef>node1 VARCHAR,node2 VARCHAR,weight DOUBLE");
            foreach (var edge in Edges)
            {
                file.WriteLine(edge.Node1.Name + ", " + edge.Node2.Name + ", " + edge.Weight);
            }
            file.Close();
        }
    }
}
