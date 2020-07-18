﻿using DonVo2020.Algorithms.NetCore31.Common;
using System;
using System.Collections.Generic;

namespace DonVo2020.Algorithms.NetCore31.ConnectedComponentsGraph
{
    public static class ConnectedComponents
    {
        /// <summary>
        /// Private helper. Discovers a connected component and return from a source vertex in a graph.
        /// </summary>
        private static List<TVertex> _bfsConnectedComponent<TVertex>(IGraph<TVertex> graph, TVertex source, ref HashSet<TVertex> visited) where TVertex : IComparable<TVertex>
        {
            var component = new List<TVertex>();
            var queue = new Queue<TVertex>();

            queue.Enqueue(source);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (!visited.Contains(current))
                {
                    component.Add(current);
                    visited.Add(current);

                    foreach (var adjacent in graph.Neighbours(current))
                        if (!visited.Contains(adjacent))
                            queue.Enqueue(adjacent);
                }
            }

            return component;
        }


        /// <summary>
        /// Return the the connected components in graph as list of lists of nodes. Each list represents a connected component.
        /// </summary>
        public static List<List<TVertex>> Compute<TVertex>(IGraph<TVertex> Graph) where TVertex : IComparable<TVertex>
        {
            var components = new List<List<TVertex>>();
            var visited = new HashSet<TVertex>();

            // Validate the graph parameter
            if (Graph == null)
                throw new ArgumentNullException();
            else if (Graph.IsDirected == true)
                throw new NotSupportedException("Directed Graphs are not supported.");
            else if (Graph.VerticesCount == 0)
                return components;

            // Get connected components using BFS
            foreach (var vertex in Graph.Vertices)
                if (!visited.Contains(vertex))
                    components.Add(_bfsConnectedComponent<TVertex>(Graph, vertex, ref visited));

            return components;
        }
    }
}
