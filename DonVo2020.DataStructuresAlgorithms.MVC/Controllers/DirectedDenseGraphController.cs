using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Html;
using DonVo2020.DataStrutures.NetCore31.StringHelpers;
using DonVo2020.DataStrutures.NetCore31.Graphs;

namespace DonVo2020.DataStructuresAlgorithms.MVC.Controllers
{
    public class DirectedDenseGraphController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            string result = string.Empty;

            var graph = new DirectedDenseGraph<string>();

            var verticesSet1 = new string[] { "a", "z", "s", "x", "d", "c", "f", "v" };

            graph.AddVertices(verticesSet1);

            graph.AddEdge("a", "s");
            graph.AddEdge("a", "z");
            graph.AddEdge("s", "x");
            graph.AddEdge("x", "d");
            graph.AddEdge("x", "c");
            graph.AddEdge("x", "a");
            graph.AddEdge("d", "f");
            graph.AddEdge("d", "c");
            graph.AddEdge("d", "s");
            graph.AddEdge("c", "f");
            graph.AddEdge("c", "v");
            graph.AddEdge("c", "d");
            graph.AddEdge("v", "f");
            graph.AddEdge("f", "c");

            var allEdges = graph.Edges.ToList();

            result = ("[*] Directed Dense Graph: " + "\n\n") + "Graph nodes and edges: \n" + (graph.ToReadable() + "\n\n");

            graph.RemoveEdge("d", "c");
            graph.RemoveEdge("c", "v");
            graph.RemoveEdge("a", "z");

            result = result + "After removing edges (d-c), (c-v), (a-z):" + "\n" + (graph.ToReadable() + "\n\n");

            graph.RemoveVertex("x");

            result = result + "After removing node (x):" + "\n" + (graph.ToReadable() + "\n\n");

            graph.AddVertex("x");
            graph.AddEdge("s", "x");
            graph.AddEdge("x", "d");
            graph.AddEdge("x", "c");
            graph.AddEdge("x", "a");
            graph.AddEdge("d", "c");
            graph.AddEdge("c", "v");
            graph.AddEdge("a", "z");

            result = result + "Re-added the deleted vertices and edges to the graph. \n" + (graph.ToReadable() + "\n\n");

            // BFS from A
            result = result + "Walk the graph using BFS from A: \n";
            var bfsWalk = graph.BreadthFirstWalk("a");
            result = result + "output: (s) (a) (x) (z) (d) (c) (f) (v)." + "\n";
            foreach (var node in bfsWalk)
                result = result + String.Format("({0})", node);

            result = result + "\n\n";

            // DFS from A
            result = result + "Walk the graph using DFS from A: \n";
            var dfsWalk = graph.DepthFirstWalk("a");
            result = result + "output: (s) (a) (x) (z) (d) (c) (f) (v)." + "\n";
            foreach (var node in dfsWalk)
                result = result + String.Format("({0})", node);

            result = result + "\n\n";

            // BFS from F
            result = result + "Walk the graph using BFS from F: \n";
            bfsWalk = graph.BreadthFirstWalk("f");
            result = result + "output:(s) (a) (x) (z) (d) (c) (f) (v)." + "\n";
            foreach (var node in bfsWalk)
                result = result + String.Format("({0})", node);

            result = result + "\n\n";

            // DFS from F
            result = result + "Walk the graph using DFS from F: \n";
            dfsWalk = graph.DepthFirstWalk("f");
            result = result + "output:(s) (a) (x) (z) (d) (c) (f) (v)." + "\n";
            foreach (var node in dfsWalk)
                result = result + String.Format("({0})", node);

            result = result + "\n\n";


            graph.Clear();
            result = result + "Cleared the graph from all vertices and edges.\n\n";

            var verticesSet2 = new string[] { "a", "b", "c", "d", "e", "f" };

            result = result + "Vertices Set 2: " + "a, b, c, d, e, f" + "\n\n";

            graph.AddVertices(verticesSet2);

            graph.AddEdge("a", "b");
            graph.AddEdge("a", "d");
            graph.AddEdge("b", "e");
            graph.AddEdge("d", "b");
            graph.AddEdge("d", "e");
            graph.AddEdge("e", "c");
            graph.AddEdge("c", "f");
            graph.AddEdge("f", "f");

            result = result + "[*] NEW Directed Dense Graph:\n";
            result = result + "Graph nodes and edges:\n";
            result = result + "graph.ToReadable()";
            result = result + "\n\n";

            result = result + "Walk the graph using DFS:\n";
            dfsWalk = graph.DepthFirstWalk();
            result = result + " output: (a) (b) (e) (d) (c) (f) ." + "\n";
            foreach (var node in dfsWalk)
                result = result + String.Format("({0})", node);

            HtmlString html = StringHelper.GetHtmlString(result);
            return View(html);
        }
    }
}
