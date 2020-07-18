using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Html;
using DonVo2020.DataStrutures.NetCore31.StringHelpers;
using DonVo2020.Algorithms.NetCore31.Common;
using DonVo2020.Algorithms.NetCore31.CyclesDetectorGraph;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DonVo2020.DataStructuresAlgorithms.MVC.Controllers
{
    public class CyclesDetectorGraphController : Controller
    {
        string result = string.Empty;

        // GET: /<controller>/
        public IActionResult Index()
        {
            string[] V;
            DirectedSparseGraph<string> DAG;
            //UndirectedSparseGraph<string> CyclicGraph;
            DirectedSparseGraph<string> DigraphWithCycles;

            // Init graph object
            DigraphWithCycles = new DirectedSparseGraph<string>();

            // Init V
            V = new string[6] { "r", "s", "t", "x", "y", "z" };

            result = result + "Vertices: " + "'r', 's', 't', 'x', 'y', 'z'" + "\n";

            // Insert V
            DigraphWithCycles.AddVertices(V);

            // Insert E
            DigraphWithCycles.AddEdge("r", "s");
            DigraphWithCycles.AddEdge("r", "t");
            DigraphWithCycles.AddEdge("s", "t");
            DigraphWithCycles.AddEdge("s", "x");
            DigraphWithCycles.AddEdge("t", "x");
            DigraphWithCycles.AddEdge("t", "y");
            DigraphWithCycles.AddEdge("t", "z");
            DigraphWithCycles.AddEdge("x", "y");
            DigraphWithCycles.AddEdge("x", "z");
            DigraphWithCycles.AddEdge("y", "z");
            DigraphWithCycles.AddEdge("z", "r");
            DigraphWithCycles.AddEdge("z", "s");

            var isCyclic = CyclesDetector.IsCyclic<string>(DigraphWithCycles);

            // PRINT THE GRAPH
            result = result + "[*] Directed Graph:";
            result = result + DigraphWithCycles.ToReadable() + "\r\n";
            result = result + "Is directed graph above cyclic? " + "=> answer is " + isCyclic+ "\n\n";


            ///***************************************************************************************/


            //CyclicGraph = new UndirectedSparseGraph<string>();

            //V = new string[] { "A", "B", "C", "D", "E" };
            //result = result + "Vertices: " + "'A', 'B', 'C', 'D', 'E'" + "\n";

            //// Insert new values of V
            //CyclicGraph.AddVertices(V);

            //// Insert new value for edges
            //CyclicGraph.AddEdge("A", "C");
            //CyclicGraph.AddEdge("B", "A");
            //CyclicGraph.AddEdge("B", "C");
            //CyclicGraph.AddEdge("C", "E");
            //CyclicGraph.AddEdge("C", "D");
            //CyclicGraph.AddEdge("D", "B");
            //CyclicGraph.AddEdge("E", "D");

            //isCyclic = CyclesDetector.IsCyclic<string>(CyclicGraph);

            //// PRINT THE GRAPH
            //result = result + "[*] Undirected Graph:";
            //result = result + CyclicGraph.ToReadable() + "\r\n";
            //result = result + "Is un-directed graph above cyclic? " + "=> answer is " + isCyclic;

            //Console.WriteLine("\r\n*********************************************\r\n");


            ///***************************************************************************************/


            DAG = new DirectedSparseGraph<string>();

            V = new string[] { "A", "B", "C", "D", "E", "X" };
            result = result + "Vertices: " + "'A', 'B', 'C', 'D', 'E', 'X'" + "\n";

            // Insert new values of V
            DAG.AddVertices(V);

            // Insert new value for edges
            DAG.AddEdge("A", "B");
            DAG.AddEdge("A", "X");
            DAG.AddEdge("B", "C");
            DAG.AddEdge("C", "D");
            DAG.AddEdge("D", "E");
            DAG.AddEdge("E", "X");

            isCyclic = CyclesDetector.IsCyclic<string>(DAG);
            //Debug.Assert(isCyclic == false, "Wrong status! The graph has no cycles.");

            // PRINT THE GRAPH
            result = result + "[*] DAG(Directed Asyclic Graph): ";
            result = result + DAG.ToReadable() + "\r\n";
            result = result + "Is directed graph above cyclic? " + "=> answer is " + isCyclic;


            HtmlString html = StringHelper.GetHtmlString(result);
            return View(html);
        }
    }
}
