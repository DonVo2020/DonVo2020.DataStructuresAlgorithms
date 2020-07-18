using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DonVo2020.DataStrutures.NetCore31.Trees.AVLTree;
using Microsoft.AspNetCore.Html;
using DonVo2020.DataStrutures.NetCore31.Trees;
using DonVo2020.DataStrutures.NetCore31.StringHelpers;

namespace DonVo2020.DataStructuresAlgorithms.MVC.Controllers
{
    public class AVLTreeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            AVLTree<int> avlTree = new AVLTree<int>();
            avlTree = new AVLTree<int>();

            List<int> treeDataList = new List<int>() { 15, 25, 5, 12, 1, 16, 20, 9, 19, 7, 4, -1, 11, 29, 30, 8, 10, 13, 28, 39 };
            avlTree.Insert(treeDataList);

            string result = AVLTreeResult(avlTree);
            HtmlString html = StringHelper.GetHtmlString(result);
            return View(html);
        }

        private string AVLTreeResult(AVLTree<int> avlTree)
        {
            return avlTree.DrawTreeAVL();
        }
    }
}
