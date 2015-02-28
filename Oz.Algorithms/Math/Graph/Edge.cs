using System;

namespace Oz.Algorithms.Math.Graph
{
    public class Edge
    {
        public int Id { get; set; }
        public Vertex Vertex1 { get; set; }
        public Vertex Vertex2 { get; set; }
        public int Weight { get; set; }
        public double NormalizedWeight { get; set; }

        public Edge()
        {
            Id = 0;
            Weight = 0;
        }

        public Edge(Vertex vertex1, Vertex vertex2)
        {
            Id = 0;
            Vertex1 = vertex1;
            Vertex2 = vertex2;
            Weight = 1;
            NormalizedWeight = 0;
        }

        public Edge(int id, Vertex vertex1, Vertex vertex2)
        {
            Id = id;
            Vertex1 = vertex1;
            Vertex2 = vertex2;
            Weight = 1;
            NormalizedWeight = 0;
        }

        /// <summary>
        /// Returns true if given Vertex present in Edge
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns></returns>
        public bool IsVertexPresent(Vertex vertex)
        {
            var result = Vertex1.Id == vertex.Id || Vertex2.Id == vertex.Id;
            return result;
        }


        /// <summary>
        /// Returns the vertex of edge other vertex than given vertex
        /// If given vertex not in edge returns -1
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns></returns>
        public int GetOtherVertex(Vertex vertex)
        {
            var result = -1;
            if (Vertex1.Id == vertex.Id)
            {
                result = Vertex2.Id;
            }
            else if (Vertex2.Id == vertex.Id)
            {
                result = Vertex2.Id;
            }
            return result;
        }
    }
}
