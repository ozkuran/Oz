using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using JetBrains.Annotations;

namespace Oz.Algorithms.Math.Graph
{
    /// <summary>
    /// Graph Class
    /// </summary>
    public class Graph
    {
        /// <summary>
        /// Id of the Graph
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Name of the Graph
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Vertexes of the Graph
        /// </summary>
        public List<Vertex> Vertexes { get; set; }
        /// <summary>
        /// Edges of the Graph
        /// </summary>
        public List<Edge> Edges { get; set; }
        /// <summary>
        /// Total Edge Weight of the Graph
        /// </summary>
        public int TotalEdgeWeight { get; set; }
        /// <summary>
        /// Maximum Edge Count of a Vertex
        /// Useful Metric in calculating Density of Graph
        /// </summary>
        public int MaximumEdgeCount { get; set; }
        /// <summary>
        /// Density of the Graph
        /// </summary>
        public double Density { get; set; }
        /// <summary>
        /// Weight of the Biggest Edge in the Graph
        /// </summary>
        public int BiggestEdgeWeight { get; set; }
        /// <summary>
        /// Distance Matrix of the Graphs shortest paths
        /// Calculations made with normalized weights of edges
        /// </summary>
        public List<List<double>> DistanceMatrix { get; set; } 
        private const double Infinity = int.MaxValue;


        /// <summary>
        /// Constructor of Graph Class
        /// </summary>
        public Graph()
        {
            Vertexes = new List<Vertex>();
            Edges = new List<Edge>();
            DistanceMatrix = new List<List<double>>();
            TotalEdgeWeight = 0;
            MaximumEdgeCount = 0;
            Density = 0;
            BiggestEdgeWeight = 0;
        }

        private List<int> NeighbourVertexes(Vertex Vertex)
        {
            var result = new List<int>();
            foreach (var edge in Edges)
            {
                if (edge.Vertex1.Id == Vertex.Id)
                {
                    result.Add(edge.Vertex2.Id);
                }
                else if (edge.Vertex2.Id == Vertex.Id)
                {
                    result.Add(edge.Vertex1.Id);
                }
            }
            return result;
        } 

        private int GetClosestVertexesEdge(Vertex inputVertex, List<int> visitedVertexes)
        {
            var edgeNumber = -1;
            foreach (var edge in Edges.Where(edge => edge.IsVertexPresent(inputVertex)))
            {
                if (!visitedVertexes.Contains(edge.GetOtherVertex(inputVertex)))
                {
                    if (edgeNumber == -1)
                    {
                        edgeNumber = edge.Id;
                    }
                    else if (Edges[edgeNumber].NormalizedWeight < edge.NormalizedWeight)
                    {
                        edgeNumber = edge.Id;
                    }
                }
            }
            return edgeNumber;
        }

        /// <summary>
        /// Calculates Shortest Path Between Given Vertexes 
        /// </summary>
        /// <param name="Vertex">Given Vertex</param>
        /// <returns>Returns a list of doubles includes shortest paths to every Vertex from given Vertex</returns>
        private double CalculateShortestPathBetweenTwoVertexes(Vertex Vertex1, Vertex Vertex2)
        {
            if (Vertex1.Id == Vertex2.Id)
            {
                return 0.0;
            }
            var shortestDistances = new List<double>();
            var currentVertex = Vertex1.Id;
            var visitedVertexes = new List<int>();
            visitedVertexes.Add(currentVertex);
            for (var i = 0; i < Vertexes.Count(); i++)
            {
                shortestDistances.Add(Infinity);
            }
            shortestDistances[Vertex1.Id] = 0;
            while (!visitedVertexes.Contains(Vertex2.Id))
            {
                foreach (var neighbourVertex in NeighbourVertexes(Vertexes[currentVertex]))
                {
                    if (!visitedVertexes.Contains(neighbourVertex))
                    {
                        if (System.Math.Abs(shortestDistances[neighbourVertex] - Infinity) < 10)
                        {
                            shortestDistances[neighbourVertex] =
                                1 - Edges[GetEdgeId(Vertexes[neighbourVertex].Name, Vertexes[currentVertex].Name)]
                                    .NormalizedWeight;
                        }
                        else
                        {
                            shortestDistances[neighbourVertex] +=
                                1 - Edges[GetEdgeId(Vertexes[neighbourVertex].Name, Vertexes[currentVertex].Name)]
                                    .NormalizedWeight; 
                        }
                    }
                }
                var closestVertex = Edges[GetClosestVertexesEdge(Vertexes[currentVertex], visitedVertexes)].GetOtherVertex(Vertexes[currentVertex]);
                currentVertex = closestVertex;
                visitedVertexes.Add(currentVertex);
                List<int> availableVertexes =
                    NeighbourVertexes(Vertexes[currentVertex]).Except(visitedVertexes).ToList();
                if (availableVertexes.Count == 0)
                {
                    visitedVertexes.Add(Vertex2.Id); // P.S. : I dont like breaks;  Mahmut
                }
            }
            return shortestDistances[Vertex2.Id];
        }

        private void InitializeShortestPathMatrix()
        {
            for (var i = 0; i < Vertexes.Count(); i++)
            {
                var temporaryList = new List<double>();
                for (var j = 0; j < Vertexes.Count(); j++)
                {
                    temporaryList.Add(Infinity);
                }
                DistanceMatrix.Add(temporaryList);
            }
        }

        /// <summary>
        /// Calculates Shortest Path Matrix using Dijkstra's Algorithm
        /// </summary>
        public void CalculateShortestPathsMatrix()
        {
            InitializeShortestPathMatrix();
            for (var i = 0; i < Vertexes.Count(); i++)
            {
                for (var j = 0; j < Vertexes.Count(); j++)
                {
                    DistanceMatrix[i][j] = CalculateShortestPathBetweenTwoVertexes(Vertexes[i], Vertexes[j]);
                }
            }
        }

        /// <summary>
        /// Returns Normalized length of an Edge between given Vertexes
        /// </summary>
        /// <param name="Vertex1">First Vertex</param>
        /// <param name="Vertex2">Second Vertex</param>
        /// <returns></returns>
        private double GetNormalizedLengthBetweenVertexes(Vertex Vertex1, Vertex Vertex2)
        {
            var result = 0.0;
            result = 1 - Edges[GetEdgeId(Vertex1.Name, Vertex2.Name)].NormalizedWeight;
            return result;
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
            Density = (double)MaximumEdgeCount / (double)Vertexes.Count();
        }

        /// <summary>
        /// Calculates Maximum Edge Count to use with Graph Metrics
        /// </summary>
        public void CalculateMaximumEdgeCount()
        {
            var VertexCount = Vertexes.Count;
            MaximumEdgeCount = VertexCount * (VertexCount - 1) / 2;
        }

        /// <summary>
        /// Adds Vertex with given name to graph
        /// </summary>
        /// <param name="vertexName"></param>
        /// <returns></returns>
        public int AddVertex(string vertexName)
        {
            if (!IsVertexAdded(vertexName))
            {
                var vertex = new Vertex(Vertexes.Count() , vertexName);
                Vertexes.Add(vertex);
                return Vertexes.Count();
            }
            else
            {
                var Vertex = Vertexes.FirstOrDefault(x => x.Name == vertexName);
                if (Vertex != null)
                {
                    Vertex.Weight++;
                    return Vertex.Id;
                }
                else
                {
                    return 0;
                }
            }
        }


        /// <summary>
        /// Checks if Vertex Added in Graph
        /// </summary>
        /// <param name="vertexName">Vertex name to be checked id added</param>
        /// <returns></returns>
        private bool IsVertexAdded(string vertexName)
        {
            return Vertexes.Count(x => x.Name == vertexName) > 0;
        }

        private int GetVertexId(string VertexName)
        {
            var Vertex = Vertexes.FirstOrDefault(x => x.Name == VertexName);
            return Vertex != null ? Vertex.Id : 0;
        }

        /// <summary>
        /// Adds Edge to Graph
        /// </summary>
        /// <param name="edge">Enge to be added to graph</param>
        public void AddEdge(Edge edge)
        {
            var edgeId = GetEdgeId(edge.Vertex1.Name, edge.Vertex2.Name);
            if (edgeId > 0)
            {
                var edg = Edges.FirstOrDefault(x => x.Id == edgeId);
                if (edg != null) edg.Weight++;
            }
            else
            {
                var intVertex1 = AddVertex(edge.Vertex1.Name);
                var intVertex2 = AddVertex(edge.Vertex2.Name);
                edge.Vertex1.Id = intVertex1;
                edge.Vertex2.Id = intVertex2;
                edge.Weight = 1;
                edge.Id = Edges.Count();
                Edges.Add(edge);
            }
            TotalEdgeWeight++;
        }


        /// <summary>
        /// Checks if Edge already defined
        /// If not defined returns 0
        /// </summary>
        /// Mahmut Ali ÖZKURAN 
        /// 01/02/2015
        /// <param name="edge">Edge which will be checked if added or not</param>
        /// <returns></returns>
        [UsedImplicitly]private bool IsEdgeAdded(Edge edge)
        {
            var edg = Edges.FirstOrDefault(x => ((x.Vertex1.Name == edge.Vertex1.Name) && (x.Vertex2.Name == edge.Vertex2.Name)));
            return edg != null;
        }

        /// <summary>
        /// Returns id of Egde if already defined
        /// If not defined returns 0
        /// </summary>
        /// Mahmut Ali ÖZKURAN 
        /// 01/02/2015
        /// <param name="Vertex1">First Vertex to check</param>
        /// <param name="Vertex2">Second Vertex to check</param>
        /// <returns></returns>
        private int GetEdgeId(string Vertex1, string Vertex2)
        {
            var edge = Edges.FirstOrDefault(x => ((x.Vertex1.Name == Vertex1) && (x.Vertex2.Name == Vertex2))) ??
                       Edges.FirstOrDefault(x => ((x.Vertex1.Name == Vertex2) && (x.Vertex2.Name == Vertex1)));
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
            file.WriteLine("Vertexdef>name VARCHAR,weight DOUBLE");
            foreach (var Vertex in Vertexes)
            {
                file.WriteLine(Vertex.Name + ", " + Vertex.Weight);
            }
            file.WriteLine("edgedef>Vertex1 VARCHAR,Vertex2 VARCHAR,weight DOUBLE");
            foreach (var edge in Edges)
            {
                file.WriteLine(edge.Vertex1.Name + ", " + edge.Vertex2.Name + ", " + edge.Weight);
            }
            file.Close();
        }
    }
}
