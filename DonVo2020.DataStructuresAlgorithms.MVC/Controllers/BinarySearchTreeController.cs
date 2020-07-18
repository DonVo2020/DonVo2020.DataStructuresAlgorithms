using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Html;
using DonVo2020.DataStrutures.NetCore31.Trees.BinarySearchTree;
using DonVo2020.DataStrutures.NetCore31.StringHelpers;
using DonVo2020.DataStrutures.NetCore31.Trees;

namespace DonVo2020.DataStructuresAlgorithms.MVC.Controllers
{
    public class BinarySearchTreeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            int[] values = { 15, 25, 36, 55, 75, 21, 5, 100, 60, 12, 1, 16, 20, 9, 18, 7,  24, 33, 22, 17, -1, 44, 84, 64, 14, 74, 11, 19, 30, 8, 10, 13, 28, 39, 45,  40, 48, 47, 37, 90 };

            string result = BinarySearchTreeResult(values);
            HtmlString html = StringHelper.GetHtmlString(result);
            return View(html);
        }

        private string BinarySearchTreeResult(int[] values)
        {
            var binarySearchTree = new AugmentedBinarySearchTree<int>(allowDuplicates: true);
            binarySearchTree = new AugmentedBinarySearchTree<int>(allowDuplicates: true);
            binarySearchTree.Insert(values);
            string result = binarySearchTree.DrawTreeBTS();

            return result;
        }
    }
}
