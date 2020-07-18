using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
//using DonVo2020.DataStrutures.NetCore31.Graphs;
using DonVo2020.Algorithms.NetCore31.DijkstraShortestPaths;
using System.Diagnostics;
using Microsoft.AspNetCore.Html;
using DonVo2020.DataStrutures.NetCore31.StringHelpers;
using DonVo2020.Algorithms.NetCore31.Common;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DonVo2020.DataStructuresAlgorithms.MVC.Controllers
{
    public class DijkstraShortestPathsController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            string result = string.Empty;

            string[] V;
            IEnumerable<WeightedEdge<string>> E;
            DirectedWeightedSparseGraph<string> graph;
            DijkstraShortestPaths<DirectedWeightedSparseGraph<string>, string> dijkstra;

            // Init graph object
            graph = new DirectedWeightedSparseGraph<string>();

            // Init V
            V = new string[6] { "r", "s", "t", "x", "y", "z" };
            result = result + "Initial Verrtices: 'r', 's', 't', 'x', 'y', 'z'" + "\n";

            // Insert V
            graph.AddVertices(V);
            result = result + "# of vertices: " + V.Length + "\n";

            // Insert E
            var status = graph.AddEdge("r", "s", 7);
            status = graph.AddEdge("r", "t", 6);
            status = graph.AddEdge("s", "t", 5);
            status = graph.AddEdge("s", "x", 9);
            status = graph.AddEdge("t", "x", 10);
            status = graph.AddEdge("t", "y", 7);
            status = graph.AddEdge("t", "z", 5);
            status = graph.AddEdge("x", "y", 2);
            status = graph.AddEdge("x", "z", 4);
            status = graph.AddEdge("y", "z", 1);

            // Get E
            E = graph.Edges;
            //Debug.Assert(graph.EdgesCount == 10, "Wrong Edges Count.");
            result = result + "# of edges: " + graph.EdgesCount + "\n\n";

            //
            // PRINT THE GRAPH
            result = result + "[*] DIJKSTRA ON DIRECTED WEIGHTED GRAPH:\r\n";

            result = result + "Graph representation:";
            result = result + graph.ToReadable() + "\r\n\n";

            // Init DIJKSTRA
            dijkstra = new DijkstraShortestPaths<DirectedWeightedSparseGraph<string>, string>(graph, "s");

            result = result + "dijkstra.HasPathTo('r') is " + dijkstra.HasPathTo("r") + "\n";
            result = result + "dijkstra.HasPathTo('z') is " + dijkstra.HasPathTo("z") + "\n\n";

            // Get shortest path to Z
            var pathToZ = string.Empty;
            foreach (var node in dijkstra.ShortestPathTo("z"))
                pathToZ = String.Format("{0}({1}) -> ", pathToZ, node);
            pathToZ = pathToZ.TrimEnd(new char[] { ' ', '-', '>' });

            result = result + "Shortest path to node 'z': " + pathToZ + "\r\n";

            var pathToY = string.Empty;
            foreach (var node in dijkstra.ShortestPathTo("y"))
                pathToY = String.Format("{0}({1}) -> ", pathToY, node);
            pathToY = pathToY.TrimEnd(new char[] { ' ', '-', '>' });

            result = result + "Shortest path to node 'y': " + pathToY + "\r\n\n";


            ///***************************************************************************************/


            //// Clear the graph and insert new V and E to the instance
            //graph.Clear();

            //V = new string[] { "A", "B", "C", "D", "E" };

            //// Insert new values of V
            //graph.AddVertices(V);
            //Debug.Assert(graph.VerticesCount == V.Length, "Wrong Vertices Count.");

            //// Insert new value for edges
            //status = graph.AddEdge("A", "C", 7);
            //Debug.Assert(status == true);
            //status = graph.AddEdge("B", "A", 19);
            //Debug.Assert(status == true);
            //status = graph.AddEdge("B", "C", 11);
            //Debug.Assert(status == true);
            //status = graph.AddEdge("C", "E", 5);
            //Debug.Assert(status == true);
            //status = graph.AddEdge("C", "D", 15);
            //Debug.Assert(status == true);
            //status = graph.AddEdge("D", "B", 4);
            //Debug.Assert(status == true);
            //status = graph.AddEdge("E", "D", 13);
            //Debug.Assert(status == true);

            //Debug.Assert(graph.EdgesCount == 7, "Wrong Edges Count.");

            ////
            //// PRINT THE GRAPH
            //Console.Write("[*] DIJKSTRA ON DIRECTED WEIGHTED GRAPH - TEST 01:\r\n");

            //Console.WriteLine("Graph representation:");
            //Console.WriteLine(graph.ToReadable() + "\r\n");

            //// Init DIJKSTRA
            //dijkstra = new DijkstraShortestPaths<DirectedWeightedSparseGraph<string>, string>(graph, "A");

            //var pathToD = string.Empty;
            //foreach (var node in dijkstra.ShortestPathTo("D"))
            //    pathToD = String.Format("{0}({1}) -> ", pathToD, node);
            //pathToD = pathToD.TrimEnd(new char[] { ' ', '-', '>' });

            //Console.WriteLine("Shortest path from 'A' to 'D': " + pathToD + "\r\n");

            //Console.WriteLine("*********************************************\r\n");


            ///***************************************************************************************/


            var dijkstraAllPairs = new DijkstraAllPairsShortestPaths<DirectedWeightedSparseGraph<string>, string>(graph);

            var vertices = graph.Vertices;

            result = result + "Dijkstra All Pairs Shortest Paths: \r\n";

            foreach (var source in vertices)
            {

                foreach (var destination in vertices)
                {
                    var shortestPath = string.Empty;
                    if (dijkstraAllPairs.ShortestPath(source, destination) != null)
                    {
                        foreach (var node in dijkstraAllPairs.ShortestPath(source, destination))
                            shortestPath = String.Format("{0}({1}) -> ", shortestPath, node);


                        shortestPath = shortestPath.TrimEnd(new char[] { ' ', '-', '>' });

                        result = result + "Shortest path from '" + source + "' to '" + destination + "' is: " + shortestPath + "\r\n";
                    }
                }
            }

            //Console.ReadLine();


            HtmlString html = StringHelper.GetHtmlString(result);
            return View(html);
        }
    }
}
