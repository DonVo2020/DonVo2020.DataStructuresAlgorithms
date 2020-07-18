using Microsoft.AspNetCore.Mvc;
using DonVo2020.DataStrutures.NetCore31.Lists;
using Microsoft.AspNetCore.Html;
using DonVo2020.DataStrutures.NetCore31.StringHelpers;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DonVo2020.DataStructuresAlgorithms.MVC.Controllers
{
    public class SkipListController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            string result = string.Empty;
            result = result + "SkipList Initial Items: 20, 10, 5, 11, 1" + "\n\n";

            var skipList = new SkipList<int>();
            skipList.Add(20);
            skipList.Add(10);
            skipList.Add(5);
            skipList.Add(11);
            skipList.Add(1);

            // Get enumarator
            var enumerator = skipList.GetEnumerator();
            result = result + " [*] Skip-List elements:";
            result = result + "..... ";
            while (enumerator.MoveNext())
                result = result + string.Format("{0} -> ", enumerator.Current);
            result = result + "\n===================================\n";

            int min = default(int);
            if (skipList.TryDeleteMin(out min))
                result = result + string.Format("Removed min from SkipList, and it was: {0}", min);
            result = result + "\n===================================\n";

            // Reload enumarator
            enumerator = skipList.GetEnumerator();
            result = result + " [*] Skip-List elements:";
            result = result + "..... ";
            while (enumerator.MoveNext())
                result = result + string.Format("{0} -> ", enumerator.Current);
            result = result + "\n===================================\n";

            skipList.Clear();
            result = result + "Clear SkipList, add new items to it, and reload. \n\n";

            for (int i = 100; i >= 50; --i)
                skipList.Add(i);
            for (int i = 0; i <= 35; ++i)
                skipList.Add(i);

            // Reload enumarator
            enumerator = skipList.GetEnumerator();
            result = result + " [*] Skip-List elements:";
            result = result + "..... ";
            while (enumerator.MoveNext())
                result = result + string.Format("{0} -> ", enumerator.Current);
            result = result + "\n\n" + string.Format("SkipList Count = {0}", skipList.Count) + "\n";
            result = result + "===================================\n";

            result = result + "Add more items to it, and reload. \n\n";

            for (int i = -15; i <= 0; ++i)
                skipList.Add(i);
            for (int i = -15; i >= -35; --i)
                skipList.Add(i);

            // Reload enumarator
            enumerator = skipList.GetEnumerator();
            result = result + " [*] Skip-List elements:";
            result = result + "..... ";
            while (enumerator.MoveNext())
                result = result + string.Format("{0} -> ", enumerator.Current);
            result = result + "\n\nSkipList.Count: " + skipList.Count;
            result = result + "\n===================================\n";

            skipList.Clear();
            result = result + "Clear SkipList, add new items to it, and reload.\n\n";

            for (int i = 100; i >= 0; --i)
                skipList.Add(i);

            // Reload enumarator
            enumerator = skipList.GetEnumerator();
            result = result + " [*] Skip-List elements:";
            result = result + "..... ";
            while (enumerator.MoveNext())
                result = result + string.Format("{0} -> ", enumerator.Current);
            result = result + "\n\nSkipList.Count: " + skipList.Count;
            result = result + "\n===================================\n";

            HtmlString html = StringHelper.GetHtmlString(result);
            return View(html);
        }
    }
}
