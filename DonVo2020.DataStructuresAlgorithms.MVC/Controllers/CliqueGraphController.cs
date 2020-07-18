using System;
using Microsoft.AspNetCore.Mvc;
using DonVo2020.DataStrutures.NetCore31.Graphs;
using Microsoft.AspNetCore.Html;
using DonVo2020.DataStrutures.NetCore31.StringHelpers;

namespace DonVo2020.DataStructuresAlgorithms.MVC.Controllers
{
    public class CliqueGraphController : Controller
    {
        public const int vertexPerCluster = 10;
        public const int numClusters = 10;
        static CliqueGraph<ComparableTuple> testGraph = new CliqueGraph<ComparableTuple>();
        static IGraph<ComparableTuple> compareGraph;

        // GET: /<controller>/
        public IActionResult Index()
        {
            string result = string.Empty;

            compareGraph = new UndirectedDenseGraph<ComparableTuple>(numClusters * vertexPerCluster);
            result = result + MakeGraph(compareGraph, result);

            testGraph = new CliqueGraph<ComparableTuple>(compareGraph);
            // ICollection<ComparableTuple> component = testGraph.GetConnectedComponent(new ComparableTuple(0, 0));
            // DataStructures.Lists.DLinkedList<ComparableTuple> neighbor = testGraph.Neighbours(new ComparableTuple(0, 0));

            testGraph.RemoveEdge(new ComparableTuple(0, 0), new ComparableTuple(1, 0));

            IGraph<CliqueGraph<ComparableTuple>.Clique> dualGraph = testGraph.buildDualGraph();

            foreach (var x in dualGraph.Vertices)
            {
                foreach (var y in dualGraph.Neighbours(x))
                {
                    result = result + string.Format("{0}---{1}", x, y) + "\n";
                }
            }

            // CliqueGraph.Edges test
            foreach (var edge in testGraph.Edges)
            {
                //System.Diagnostics.Debug.WriteLine(string.Format("{0} -> {1}\t", edge.Source, edge.Destination));
            }

            result = result + "\n";

            foreach (var edge in testGraph.OutgoingEdges(new ComparableTuple(0, 0)))
            {
                result = result + string.Format("{0} -> {1}\t", edge.Source, edge.Destination) + "\n";
            }

            HtmlString html = StringHelper.GetHtmlString(result.Replace("\t", "&emsp;"));
            return View(html);
        }

        private string MakeGraph(IGraph<ComparableTuple> gra, string result)
        {

            for (int i = 0; i < numClusters; i++)
            {
                for (int j = 0; j < vertexPerCluster; j++)
                {
                    gra.AddVertex(new ComparableTuple(i, j));
                }
            }

            for (int i = 0; i < numClusters; i++)
            {
                MakeCluster(gra, i);
                result = result + string.Format("Cluster {0} finished.", i) + "\n";
            }

            for (int i = 0; i < numClusters; i++)
            {
                for (int j = 0; j < numClusters; j++)
                {
                    gra.AddEdge(new ComparableTuple(i, 0), new ComparableTuple(j, 0));
                }
            }

            result = result + "\n";
            result = result + string.Format(string.Format("Graph connected")) + "\n";

            return result;
        }

        private void MakeCluster(IGraph<ComparableTuple> gra, int i)
        {
            for (int j = 0; j < vertexPerCluster; j++)
            {
                for (int k = j; k < vertexPerCluster; k++)
                {
                    gra.AddEdge(new ComparableTuple(i, j), new ComparableTuple(i, k));
                }
            }
        }
    }

    class ComparableTuple : Tuple<int, int>, IComparable<ComparableTuple>, IEquatable<ComparableTuple>
    {
        #region IComparable implementation


        int IComparable<ComparableTuple>.CompareTo(ComparableTuple other)
        {
            int myInt = ToInt;
            int otherInt = other.ToInt;
            return myInt < otherInt ? -1 : (myInt > otherInt ? 1 : 0);
        }

        #endregion

        #region IEquatable implementation

        bool IEquatable<ComparableTuple>.Equals(ComparableTuple other)
        {
            return ToInt == other.ToInt;
        }

        #endregion

        static readonly int multiplier = CliqueGraphController.numClusters;

        public ComparableTuple(int item1, int item2)
            : base(item1, item2)
        {

        }

        int ToInt
        {
            get
            {
                return Item1 * multiplier + Item2;
            }
        }

    }
}
