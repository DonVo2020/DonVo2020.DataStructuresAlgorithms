using DonVo2020.Algorithms.NetCore31.Common;
using DonVo2020.Algorithms.NetCore31.ConnectedComponentsGraph;
using DonVo2020.DataStrutures.NetCore31.StringHelpers;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DonVo2020.DataStructuresAlgorithms.MVC.Controllers
{
    public class ConnectedComponentsGraphController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            string result = string.Empty;

            var graph = new UndirectedSparseGraph<string>();

            // Add vertices
            var verticesSet1 = new string[] { "a", "b", "c", "d", "e", "f", "s", "v", "x", "y", "z" };
            graph.AddVertices(verticesSet1);

            result = result + "Vertices: " + "'a', 'b', 'c', 'd', 'e', 'f', 's', 'v', 'x', 'y', 'z'" + "\n\n";

           // Add edges
           // Connected Component #1
           // the vertex "e" won't be connected to any other vertex

           // Connected Component #2
           graph.AddEdge("a", "s");
            graph.AddEdge("a", "d");
            graph.AddEdge("s", "x");
            graph.AddEdge("x", "d");

            // Connected Component #3
            graph.AddEdge("b", "c");
            graph.AddEdge("b", "v");
            graph.AddEdge("c", "f");
            graph.AddEdge("c", "v");
            graph.AddEdge("f", "b");

            // Connected Component #4
            graph.AddEdge("y", "z");

            result = result + "Edges: ";
            result = result + graph.ToReadable() + "\r\n\n";


            // Get connected components
            var connectedComponents = ConnectedComponents.Compute(graph);
            connectedComponents = connectedComponents.OrderBy(item => item.Count).ToList();

            result = result + "# of Connected Components: " + connectedComponents.Count() + "\n";


            result = result + "Components are: \n";
            foreach (var items in connectedComponents)
            {
                string edge = string.Empty;
                foreach (var item in items)
                {
                    edge = edge + item + " -> ";
                }

                result = result +  edge.Remove(edge.Length - 4) + "\n";
            }

            HtmlString html = StringHelper.GetHtmlString(result);
            return View(html);
        }
    }
}
