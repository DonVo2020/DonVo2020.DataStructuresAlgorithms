using DonVo2020.Algorithms.NetCore31.BipartiteColoring;
using DonVo2020.Algorithms.NetCore31.Common;
using DonVo2020.DataStrutures.NetCore31.StringHelpers;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DonVo2020.DataStructuresAlgorithms.MVC.Controllers
{
    public class BipartiteColoringController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            string result = string.Empty;


            // The graph
            IGraph<string> graph = new UndirectedSparseGraph<string>();

            // The bipartite wrapper
            BipartiteColoring<UndirectedSparseGraph<string>, string> bipartiteGraph;

            // The status for checking bipartiteness
            bool initBipartiteStatus;

            //
            // Prepare the graph for the second case of testing
            _initializeSecondCaseGraph(ref graph, ref result);

            //
            // Test initializing the bipartite
            // This initialization must fail. The graph contains an odd cycle
            bipartiteGraph = null;
            initBipartiteStatus = false;

            try
            {
                bipartiteGraph = new BipartiteColoring<UndirectedSparseGraph<string>, string>(graph);
                initBipartiteStatus = bipartiteGraph.IsBipartite();
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                initBipartiteStatus = false;
            }

            if (!initBipartiteStatus)
                Console.WriteLine("Graph should not be bipartite.");


            //
            // Remove Odd Cycle and try to initialize again.
            initBipartiteStatus = true;
            graph.RemoveEdge("c", "v");
            graph.RemoveEdge("f", "b");

            //
            // This initialization must pass. The graph doesn't contain any odd cycle
            try
            {
                bipartiteGraph = new BipartiteColoring<UndirectedSparseGraph<string>, string>(graph);
                initBipartiteStatus = bipartiteGraph.IsBipartite();
            }
            catch
            {
                initBipartiteStatus = false;
            }

            if (!initBipartiteStatus)
                Console.WriteLine("Graph should not be bipartite.");

            result = result + " 'a' color is " + bipartiteGraph.ColorOf("a") + "\n";
            result = result + " 's' color is " + bipartiteGraph.ColorOf("s") + "\n";
            result = result + " 'b' color is " + bipartiteGraph.ColorOf("b") + "\n";
            result = result + " 'f' color is " + bipartiteGraph.ColorOf("f") + "\n";
            result = result + " 'z' color is " + bipartiteGraph.ColorOf("z") + "\n";


            HtmlString html = StringHelper.GetHtmlString(result);
            return View(html);
        }

        //
        // Second Case Initialization
        private static void _initializeSecondCaseGraph(ref IGraph<string> graph, ref string result)
        {
            // Clear the graph
            graph.Clear();

            //
            // Add vertices
            var verticesSet = new string[] { "a", "b", "c", "d", "e", "f", "s", "v", "x", "y", "z" };
            graph.AddVertices(verticesSet);

            result = result + "Initial Verrtices: 'a', 'b', 'c', 'd', 'e', 'f', 's', 'v', 'x', 'y', 'z' " + "\n\n";

            //
            // Add edges

            // Connected Component #1
            // the vertex "e" won't be connected to any other vertex

            // Connected Component #2
            graph.AddEdge("a", "s");
            graph.AddEdge("a", "d");
            graph.AddEdge("s", "x");
            graph.AddEdge("s", "a");
            graph.AddEdge("x", "d");

            // Connected Component #3
            graph.AddEdge("b", "c");
            graph.AddEdge("b", "v");
            graph.AddEdge("c", "f");
            //graph.AddEdge("c", "v");
            //graph.AddEdge("f", "b");

            // Connected Component #4
            graph.AddEdge("y", "z");

            result = result + "Graph representation:";
            result = result + graph.ToReadable() + "\r\n\n";
           
        }
    }
}
