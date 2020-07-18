using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DonVo2020.DataStrutures.NetCore31.Graphs;
using Microsoft.AspNetCore.Html;
using DonVo2020.DataStrutures.NetCore31.StringHelpers;

namespace DonVo2020.DataStructuresAlgorithms.MVC.Controllers
{
    public class DirectedWeightedDenseGraphController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            string result = string.Empty;

            var graph = new DirectedWeightedDenseGraph<string>();

            var verticesSet1 = new string[] { "a", "z", "s", "x", "d", "c", "f", "v" };

            graph.AddVertices(verticesSet1);

            graph.AddEdge("a", "s", 1);
            graph.AddEdge("a", "z", 2);
            graph.AddEdge("s", "x", 3);
            graph.AddEdge("x", "d", 1);
            graph.AddEdge("x", "c", 2);
            graph.AddEdge("x", "a", 3);
            graph.AddEdge("d", "f", 1);
            graph.AddEdge("d", "c", 2);
            graph.AddEdge("d", "s", 3);
            graph.AddEdge("c", "f", 1);
            graph.AddEdge("c", "v", 2);
            graph.AddEdge("c", "d", 3);
            graph.AddEdge("v", "f", 1);
            graph.AddEdge("f", "c", 2);

            var allEdges = graph.Edges.ToList();

            result = ("[*] Directed Weighted Dense Graph: " + "\n\n") + "Graph nodes and edges: \n" + (graph.ToReadable() + "\n\n");

            var f_to_c = graph.HasEdge("f", "c");
            var f_to_c_weight = graph.GetEdgeWeight("f", "c");

            result = result + "Is there an edge from f to c? " + f_to_c + ". If yes it's weight is: " + f_to_c_weight + "." + "\n";

            var d_to_s = graph.HasEdge("d", "s");
            var d_to_s_weight = graph.GetEdgeWeight("d", "s");

            result = result + "Is there an edge from d to d? " + d_to_s + ". If yes it's weight is: " + d_to_s_weight + "." + "\n";

            graph.RemoveEdge("d", "c");
            graph.RemoveEdge("c", "v");
            graph.RemoveEdge("a", "z");

            result = result + "After removing edges (d-c), (c-v), (a-z):" + "\n";
            result = result + graph.ToReadable() + "\n\n";

            graph.RemoveVertex("x");

            result = result + "After removing node (x):" + "\n";
            result = result + graph.ToReadable() + "\n\n";

            graph.AddVertex("x");
            graph.AddEdge("s", "x", 3);
            graph.AddEdge("x", "d", 1);
            graph.AddEdge("x", "c", 2);
            graph.AddEdge("x", "a", 3);
            graph.AddEdge("d", "c", 2);
            graph.AddEdge("c", "v", 2);
            graph.AddEdge("a", "z", 2);

            result = result + "Re-added the deleted vertices and edges to the graph." + "\n";
            result = result + graph.ToReadable() + "\n\n";

            // BFS from A
            result = result + "Walk the graph using BFS from A: ";
            var bfsWalk = graph.BreadthFirstWalk("a");
            result = result + "output: (s) (a) (x) (z) (d) (c) (f) (v)." + "\n";
            foreach (var node in bfsWalk)
                result = result + String.Format("({0})", node);
            result = result + graph.ToReadable() + "\n\n";

            // DFS from A
            result = result + "Walk the graph using DFS from A: ";
            var dfsWalk = graph.DepthFirstWalk("a");
            result = result + "output: (s) (a) (x) (z) (d) (c) (f) (v)." + "\n";
            foreach (var node in dfsWalk)
                result = result + String.Format("({0})", node);
            result = result + "\n\n";

            // BFS from F
            result = result + "Walk the graph using BFS from F: ";
            bfsWalk = graph.BreadthFirstWalk("f");
            result = result + "output: (s) (a) (x) (z) (d) (c) (f) (v)." + "\n";
            foreach (var node in bfsWalk)
                result = result + String.Format("({0})", node);
            result = result + "\n\n";

            // DFS from F
            result = result + "Walk the graph using DFS from F: ";
            dfsWalk = graph.DepthFirstWalk("f");
            result = result + "output: (s) (a) (x) (z) (d) (c) (f) (v)." + "\n";
            foreach (var node in dfsWalk)
                result = result + String.Format("({0})", node);
            result = result + "\n\n";

            result = result + "***************************************************\n\n";

            graph.Clear();
            result = result + "Cleared the graph from all vertices and edges.\n\n";

            var verticesSet2 = new string[] { "a", "b", "c", "d", "e", "f" };

            result = result + "Vertices Set 2: " + "a, b, c, d, e, f" + "\n\n";

            graph.AddVertices(verticesSet2);

            graph.AddEdge("a", "b", 1);
            graph.AddEdge("a", "d", 2);
            graph.AddEdge("b", "e", 3);
            graph.AddEdge("d", "b", 1);
            graph.AddEdge("d", "e", 2);
            graph.AddEdge("e", "c", 3);
            graph.AddEdge("c", "f", 1);
            graph.AddEdge("f", "f", 1);

            result = result + "[*] NEW Directed Weighted Dense Graph: " + "\n";
            result = result + "Graph nodes and edges:\n";
            result = result + "graph.ToReadable()" + "\n\n";

            result = result + "Walk the graph using DFS:\n";
            dfsWalk = graph.DepthFirstWalk();
            result = result + "output: (a) (b) (e) (d) (c) (f) ." + "\n";
            foreach (var node in dfsWalk)
                result = result + String.Format("({0})", node);

            HtmlString html = StringHelper.GetHtmlString(result);
            return View(html);
        }
    }
}
