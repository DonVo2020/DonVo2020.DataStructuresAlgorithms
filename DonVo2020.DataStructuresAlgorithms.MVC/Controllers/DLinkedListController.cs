using Microsoft.AspNetCore.Mvc;
using DonVo2020.DataStrutures.NetCore31.Lists;
using Microsoft.AspNetCore.Html;
using DonVo2020.DataStrutures.NetCore31.StringHelpers;

namespace DonVo2020.DataStructuresAlgorithms.MVC.Controllers
{
    public class DLinkedListController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            string result = string.Empty;

            int index = 0;
            DLinkedList<string> listOfStrings = new DLinkedList<string>();

            listOfStrings.Append("zero");
            listOfStrings.Append("first");
            listOfStrings.Append("second");
            listOfStrings.Append("third");
            listOfStrings.Append("forth");
            listOfStrings.Append("fifth");
            listOfStrings.Append("sixth");
            listOfStrings.Append("seventh");
            listOfStrings.Append("eighth");

            // Print
            result = listOfStrings.ToReadable() + "\n";

            // Remove 1st
            listOfStrings.RemoveAt(0);
            result = result + "Remove At 0:\n\n" + listOfStrings.ToReadable() + "\n";

            // Remove 4th
            listOfStrings.RemoveAt(4);
            result = result + "Remove At 4:\n\n" + listOfStrings.ToReadable() + "\n";

            // Remove 5th and 6th
            // Note that after removing 5th, the old element at index 6 becomes at index 5.
            listOfStrings.RemoveAt(5);
            listOfStrings.RemoveAt(5);
            result = result + "Remove At 5 & 6:\n\n" + listOfStrings.ToReadable() + "\n";

            // Remove 3rd
            listOfStrings.RemoveAt(listOfStrings.Count - 1);
            result = result + "Removed last:\n\n" + listOfStrings.ToReadable() + "\n";

            // Remove 1st
            listOfStrings.RemoveAt(0);
            result = result + "Remove 0th:\n\n" + listOfStrings.ToReadable() + "\n";

            listOfStrings.Prepend("semsem3");
            listOfStrings.Prepend("semsem2");
            listOfStrings.Prepend("semsem1");
            result = result + "Prepend 3 items:\n\n" + listOfStrings.ToReadable() + "\n";
            result = result + "Count: " + listOfStrings.Count + "\n\n";

            listOfStrings.InsertAt("InsertedAtLast1", listOfStrings.Count);
            listOfStrings.InsertAt("InsertedAtLast2", listOfStrings.Count);
            listOfStrings.InsertAt("InsertedAtMiddle", (listOfStrings.Count / 2));
            listOfStrings.InsertAt("InsertedAt 4", 4);
            listOfStrings.InsertAt("InsertedAt 9", 9);
            listOfStrings.InsertAfter("InsertedAfter 11", 11);

            result = result + "Inserts 3 items At:\n\n" + listOfStrings.ToReadable() + "\n";

            // Test the remove item method
            listOfStrings.Remove("third");
            result = result + "Removed item 'third':\n\n" + listOfStrings.ToReadable() + "\n";

            listOfStrings.Remove("InsertedAt 9");
            result = result + "Removed item 'InsertedAt 9':\n\n" + listOfStrings.ToReadable() + "\n";

            // Print count
            result = result + "Count: " + listOfStrings.Count + "\n\n";

            index = 0;
            result = result + "Get At " + index + ": " + listOfStrings[index] + "\n";

            index = (listOfStrings.Count / 2) + 1;
            result = result + "Get At " + index + ": " + listOfStrings[index] + "\n";

            index = (listOfStrings.Count / 2) + 2;
            result = result + "Get At " + index + ": " + listOfStrings[index] + "\n";

            index = (listOfStrings.Count - 1);
            result = result + "Get At " + index + ": " + listOfStrings[index] + "\n";

            var firstRange = listOfStrings.GetRange(4, 6);
            result = result + "GetRange(4, 6):\r\n" + firstRange.ToReadable() + "\n";

            var secondRange = firstRange.GetRange(4, 10);
            result = result + "From Previous GetRange(4, 10):\r\n" + secondRange.ToReadable() + "\n";

            var thirdRange = (new DLinkedList<string>()).GetRange(0, 10);
            result = result + "Empty List: GetRange(0, 10):\r\n" + thirdRange.ToReadable() + "\n";

            HtmlString html = StringHelper.GetHtmlString(result);
            return View(html);
        }
    }
}
