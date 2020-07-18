using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DonVo2020.DataStrutures.NetCore31.Graphs;
using Microsoft.AspNetCore.Html;
using DonVo2020.DataStrutures.NetCore31.StringHelpers;

namespace DonVo2020.DataStructuresAlgorithms.MVC.Controllers
{
    public class UndirectedDenseGraphController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            string result = string.Empty;

            var graph = new UndirectedDenseGraph<string>();

            var verticesSet1 = new string[] { "a", "z", "s", "x", "d", "c", "f", "v" };

            graph.AddVertices(verticesSet1);

            graph.AddEdge("a", "s");
            graph.AddEdge("a", "z");
            graph.AddEdge("s", "x");
            graph.AddEdge("x", "d");
            graph.AddEdge("x", "c");
            graph.AddEdge("d", "f");
            graph.AddEdge("d", "c");
            graph.AddEdge("c", "f");
            graph.AddEdge("c", "v");
            graph.AddEdge("v", "f");

            var allEdges = graph.Edges.ToList();

            // TEST REMOVE nodes v and f
            graph.RemoveVertex("v");
            graph.RemoveVertex("f");

            // TEST RE-ADD REMOVED NODES AND EDGES
            graph.AddVertex("v");
            graph.AddVertex("f");
            graph.AddEdge("d", "f");
            graph.AddEdge("c", "f");
            graph.AddEdge("c", "v");
            graph.AddEdge("v", "f");

            result = ("[*] Undirected Dense Graph: " + "\n\n") + "Graph nodes and edges: \n" + (graph.ToReadable() + "\n\n");

            // RE-TEST REMOVE AND ADD NODES AND EDGES
            graph.RemoveEdge("d", "c");
            graph.RemoveEdge("c", "v");
            graph.RemoveEdge("a", "z");

            result = result + "After removing edges (d-c), (c-v), (a-z):" + "\n";
            result = result + graph.ToReadable() + "\n\n";

            graph.RemoveVertex("x");

            result = result + "After removing node(x):" + "\n";
            result = result + graph.ToReadable() + "\n\n";

            graph.AddVertex("x");
            graph.AddEdge("s", "x");
            graph.AddEdge("x", "d");
            graph.AddEdge("x", "c");
            graph.AddEdge("d", "c");
            graph.AddEdge("c", "v");
            graph.AddEdge("a", "z");

            result = result + "Re-added the deleted vertices and edges to the graph." + "\n";
            result = result + graph.ToReadable() + "\n\n";

            // BFS
            result = result + "Walk the graph using BFS:" + "\n";
            graph.BreadthFirstWalk("s");
            result = result + "output: (s) (a) (x) (z) (d) (c) (f) (v)." + "\n";
            result = result + "\n\n";

            result = result + "***************************************************\r\n";

            graph.Clear();
            result = result + "Cleared the graph from all vertices and edges.\r\n";

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

            result = result + "[*] NEW Undirected Dense Graph: " + "\n";
            result = result + "Graph nodes and edges:\n";
            result = result + "graph.ToReadable()" + "\n\n";

            result = result + "Walk the graph using DFS:\n";
            graph.DepthFirstWalk();

            result = result + "output: (a) (b) (e) (d) (c) (f)\n";

            HtmlString html = StringHelper.GetHtmlString(result);
            return View(html);
        }
    }
}
