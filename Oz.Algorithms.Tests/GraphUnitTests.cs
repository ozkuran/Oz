using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oz.Algorithms.Math.Graph;

namespace Oz.Algorithms.Tests
{
    [TestClass]
    public class GraphUnitTests
    {
        private Graph graph;

        public GraphUnitTests()
        {
            graph = new Graph();
        }

        [TestMethod]
        public void CheckIfAVertexAdded()
        {
            graph.AddVertex("Mahmut");
            var actualItemCount = 0;
            if (graph.Vertexes != null)
            {
                actualItemCount = graph.Vertexes.Count;
            }
            Assert.AreEqual(1,actualItemCount,0,"Vertex not added.");
        }

        [TestMethod]
        public void CheckIfSecondVertexAdded()
        {
            graph.AddVertex("Mahmut");
            graph.AddVertex("Sinem");
            var actualItemCount = 0;
            if (graph.Vertexes != null)
            {
                actualItemCount = graph.Vertexes.Count;
            }
            Assert.AreEqual(2, actualItemCount, 0, "Vertex not added.");
        }


        [TestMethod]
        public void CheckIfAnEdgeAdded()
        {
            graph.AddVertex("Jon");
            graph.AddVertex("Bon");
            var edge = new Edge { Vertex1 = graph.Vertexes[0], Vertex2 = graph.Vertexes[1] };
            graph.AddEdge(edge);
            graph.Edges[0].Weight = 10;
            var actualItemCount = 0;
            if (graph.Vertexes != null)
            {
                actualItemCount = graph.Edges.Count;
            }
            Assert.AreEqual(1, actualItemCount, 0, "Edge not added.");
        }

        [TestMethod]
        public void CheckIfDensityCalculationWorks()
        {
            graph.AddVertex("Jon");
            graph.AddVertex("Bon");
            var edge = new Edge { Vertex1 = graph.Vertexes[0], Vertex2 = graph.Vertexes[1] };
            graph.AddEdge(edge);
            graph.Edges[0].Weight = 10;
            graph.NormalizeEdgeWeigths();
            graph.CalculateDensity();
            var density = graph.Density;
            Assert.AreEqual(0.5, density, 0, "Density Calculation Works.");
        }

        [TestMethod]
        public void CheckIfShortestPathCalculationWorks()
        {
            graph.AddVertex("Jon");
            graph.AddVertex("Bon");
            graph.AddVertex("Jovi");
            var edge = new Edge { Vertex1 = graph.Vertexes[0], Vertex2 = graph.Vertexes[1] };
            graph.AddEdge(edge);
            var edge1 = new Edge { Vertex1 = graph.Vertexes[1], Vertex2 = graph.Vertexes[2] };
            graph.AddEdge(edge1);
            graph.Edges[0].Weight = 10;
            graph.Edges[1].Weight = 5;
            graph.NormalizeEdgeWeigths();
            graph.CalculateShortestPathsMatrix();
            var distance = graph.DistanceMatrix[0][0];
            Assert.AreEqual(0.0, distance, 0, "Density Calculation Works.");
        }

    }
}
