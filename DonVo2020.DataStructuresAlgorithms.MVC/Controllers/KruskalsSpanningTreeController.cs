using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DonVo2020.Algorithms.NetCore31.KruskalSpanningTree;
using Microsoft.AspNetCore.Html;
using DonVo2020.DataStrutures.NetCore31.StringHelpers;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DonVo2020.DataStructuresAlgorithms.MVC.Controllers
{

    public class KruskalsSpanningTreeController : Controller
    {
        public static int treeGroupCounter = 0;
        // GET: /<controller>/
        public IActionResult Index()
        {
            string result = string.Empty;

            List<Node> Cities = new List<Node>();        //holds cities
            List<Edge> SpanningTree = new List<Edge>();  //holds edges
            List<Edge> tempTree;
            List<Edge> finalTree = new List<Edge>();

            AddCities(Cities);
            AddNeighbors(SpanningTree, Cities);

            SortSpanningTree(SpanningTree);

            AddEdgesToNodes(SpanningTree);
            tempTree = new List<Edge>(SpanningTree);//the tree is sorted at this point
            BuildKruskalsGraph(Cities, tempTree, finalTree);

            result = result + "\nTHE FINAL KRUSKAL'S SPANNING TREE\n";

            foreach (var item in finalTree)
            {
                result = result + item.edgeNodes[0] + " to " + item.edgeNodes[1] + " with cost = " + item.cost + "\n";
            }

            HtmlString html = StringHelper.GetHtmlString(result);
            return View(html);
        }

        private static void SortSpanningTree(List<Edge> spanningTree)
        {
            spanningTree.Sort(delegate (Edge e1, Edge e2) { return e1.cost.CompareTo(e2.cost); });
        }
        private static void AddEdgesToNodes(List<Edge> spanningTree)
        {
            foreach (Edge e in spanningTree)
            {
                e.edgeNodes[0].edges.Add(e);
                e.edgeNodes[1].edges.Add(e);
            }
        }
        private static void AddCities(List<Node> cities)
        {
            cities.Add(new Node("Baltimore"));    //0
            cities.Add(new Node("Buffalo"));      //1
            cities.Add(new Node("Cincinatti"));   //2
            cities.Add(new Node("Cleveland"));    //3
            cities.Add(new Node("Detroit"));      //4
            cities.Add(new Node("New York"));     //5
            cities.Add(new Node("Philadelphia")); //6
            cities.Add(new Node("Pittsburgh"));   //7
            cities.Add(new Node("Washington"));   //8
        }
        private static void AddNeighbors(List<Edge> edges, List<Node> cities)
        {
            edges.Add(new Edge(345, new Node[] { cities[1], cities[0] }));
            edges.Add(new Edge(186, new Node[] { cities[3], cities[1] }));
            edges.Add(new Edge(244, new Node[] { cities[3], cities[2] }));
            edges.Add(new Edge(252, new Node[] { cities[4], cities[1] }));
            edges.Add(new Edge(265, new Node[] { cities[4], cities[2] }));
            edges.Add(new Edge(167, new Node[] { cities[4], cities[3] }));
            edges.Add(new Edge(445, new Node[] { cities[5], cities[1] }));
            edges.Add(new Edge(507, new Node[] { cities[5], cities[3] }));
            edges.Add(new Edge(97, new Node[] { cities[6], cities[0] }));
            edges.Add(new Edge(365, new Node[] { cities[6], cities[1] }));
            edges.Add(new Edge(92, new Node[] { cities[6], cities[5] }));
            edges.Add(new Edge(230, new Node[] { cities[7], cities[0] }));
            edges.Add(new Edge(217, new Node[] { cities[7], cities[1] }));
            edges.Add(new Edge(284, new Node[] { cities[7], cities[2] }));
            edges.Add(new Edge(125, new Node[] { cities[7], cities[3] }));
            edges.Add(new Edge(386, new Node[] { cities[7], cities[5] }));
            edges.Add(new Edge(305, new Node[] { cities[7], cities[6] }));
            edges.Add(new Edge(39, new Node[] { cities[8], cities[0] }));
            edges.Add(new Edge(492, new Node[] { cities[8], cities[2] }));
            edges.Add(new Edge(231, new Node[] { cities[8], cities[7] }));
        }

        private static void BuildKruskalsGraph(List<Node> Cities, List<Edge> tempKruskalsTree, List<Edge> finalKruskalsTree)
        {
            while ((finalKruskalsTree.Count < Cities.Count - 1) &&
                tempKruskalsTree.Count != 0)
            {
                Edge tempEdge = tempKruskalsTree[0];
                tempKruskalsTree.RemoveAt(0);
                //if there is a cycle, discard the edge 
                if (!((tempEdge.edgeNodes[0].treeGroup == tempEdge.edgeNodes[1].treeGroup) &&
                    (tempEdge.edgeNodes[0].treeGroup != -1)))
                //if not a cycle and is not unassigned; in same group
                {
                    treeGroupCounter++;

                    int tempGroup0 = tempEdge.edgeNodes[0].treeGroup;
                    int tempGroup1 = tempEdge.edgeNodes[1].treeGroup;
                    tempEdge.edgeNodes[0].treeGroup = treeGroupCounter;
                    tempEdge.edgeNodes[1].treeGroup = treeGroupCounter;
                    //combines two nodes from edge into one group

                    foreach (Node n in Cities)
                    {
                        if ((n.treeGroup == tempGroup0 || n.treeGroup == tempGroup1) && (n.treeGroup != -1))
                        //if either value of treeGroup matches the old values and they are assigned;
                        {
                            n.treeGroup = treeGroupCounter; //add node to new group
                        }
                    }
                    finalKruskalsTree.Add(tempEdge);
                }
            }
        }
    }
}
