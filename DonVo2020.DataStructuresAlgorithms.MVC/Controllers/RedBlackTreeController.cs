using Microsoft.AspNetCore.Mvc;
using static DonVo2020.DataStrutures.NetCore31.Trees.RedBlackTree.RedBlackTree;
using Microsoft.AspNetCore.Html;
using DonVo2020.DataStrutures.NetCore31.StringHelpers;
using DonVo2020.DataStrutures.NetCore31.Trees;

namespace DonVo2020.DataStructuresAlgorithms.MVC.Controllers
{
    public class RedBlackTreeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var redBlackTree = new RedBlackTreeAlgorithm<int>(allowDuplicates: false);

            redBlackTree.Insert(4);
            redBlackTree.Insert(5);
            redBlackTree.Insert(7);
            redBlackTree.Insert(2);
            redBlackTree.Insert(1);
            redBlackTree.Insert(3);
            redBlackTree.Insert(6);
            redBlackTree.Insert(0);
            redBlackTree.Insert(8);
            redBlackTree.Insert(10);
            redBlackTree.Insert(9);

            string result = RedBlackTreeResult(redBlackTree);
            HtmlString html = StringHelper.GetHtmlString(result);
            return View(html);
        }

        private string RedBlackTreeResult(RedBlackTreeAlgorithm<int> redBlackTree)
        {
            return redBlackTree.DrawTreeRBT();
        }
    }
}
