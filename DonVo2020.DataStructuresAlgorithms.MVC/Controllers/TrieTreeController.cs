using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Html;
using DonVo2020.DataStrutures.NetCore31.StringHelpers;
using DonVo2020.DataStrutures.NetCore31.Trees.TrieTree;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DonVo2020.DataStructuresAlgorithms.MVC.Controllers
{
    public class TrieTreeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            string result = string.Empty;

            var trie = new Trie();

            // Insert some how to words
            var prefix_howTo = "How to make";
            result = result + prefix_howTo + "\n\n";

            var word_howToSand = prefix_howTo + " a sandwitch";
            var word_howToRobot = prefix_howTo + " a robot";
            var word_howToOmelet = prefix_howTo + " an omelet";
            var word_howToProp = prefix_howTo + " a proposal";
            var listOfHow = new List<string>() { word_howToSand, word_howToRobot, word_howToOmelet, word_howToProp };

            trie.Add(word_howToOmelet);
            trie.Add(word_howToSand);
            trie.Add(word_howToRobot);
            trie.Add(word_howToProp);

            result = result + "List of How Words: " + "'" + word_howToOmelet + "'" + "; " + "'" + word_howToSand + "'" + "; " + "'" + word_howToRobot + "'"+ "; " + "'" + word_howToProp + "'" + "\n\n";

            // Count of words = 4
            result = result + "trie.Count: " + trie.Count + "\n\n";

            // Insert some dictionary words
            var prefix_act = "act";

            var word_acts = prefix_act + "s";
            var word_actor = prefix_act + "or";
            var word_acting = prefix_act + "ing";
            var word_actress = prefix_act + "ress";
            var word_active = prefix_act + "ive";
            var listOfActWords = new List<string>() { word_acts, word_actor, word_acting, word_actress, word_active };

            trie.Add(word_actress);
            trie.Add(word_active);
            trie.Add(word_acting);
            trie.Add(word_acts);
            trie.Add(word_actor);

            result = result + "List of Act Words: " + "'" + word_actress + "'" + "; " + "'" + word_active + "'" + "; " + "'" + word_acting + "'" + "; " + "'" + word_acts + "'" + "; " + "'" + word_actor + "'"  + "\n\n";

            // Count of words = 9
            result = result + "After adding 5 more, then " + "trie.Count: " + trie.Count + "\n\n";

            //
            // ASSERT THE WORDS IN TRIE.

            // Search for a word that doesn't exist
            result = result + "ContainsWord: " + "'" + prefix_howTo + "'" + " is " + trie.ContainsWord(prefix_howTo) + "\n\n";

            // Search for prefix
            result = result + "ContainsPrefix: " + "'" + prefix_howTo + "'" + " is " + trie.ContainsPrefix(prefix_howTo) + "\n\n";

            // Search for a prefix using a word
            result = result + "ContainsPrefix: " + "'" + word_howToSand + "'" + " is " + trie.ContainsPrefix(word_howToSand) + "\n\n";

            // Get all words that start with the how-to prefix
            var someHowToWords = trie.SearchByPrefix(prefix_howTo).ToList();
            result = result + "someHowToWords.Count: " + someHowToWords.Count + " and " + "listOfHow.Count: " + listOfHow.Count + "\n\n";

            // Assert there are only two words under the prefix "acti" -> active, & acting
            result = result + "There are only two words under the prefix 'acti' -> active, & acting" + "\n";
            var someActiWords = trie.SearchByPrefix("acti").ToList();

            //foreach (var word in someActiWords)
            //{
            //    result = result + word;
            //}

            result = result + "\n\n";
            result = result + "someActiWords.Contains" + "'" + word_acting + "'" + " is " + someActiWords.Contains(word_acting) + "\n";
            result = result + "someActiWords.Contains" + "'" + word_active + "'" + " is " + someActiWords.Contains(word_active) + "\n\n";

            // Assert that "acto" is not a word
            result = result + "trie.ContainsWord('acto')" + " is " + trie.ContainsWord("acto") + "\n\n";

            // Check the existance of other words
            result = result + "trie.ContainsWord: " + "'" + word_actress + "'" + " is " + trie.ContainsWord(word_actress) + "\n";
            result = result + "trie.ContainsWord: " + "'" + word_howToProp + "'" + " is " + trie.ContainsWord(word_howToProp) + "\n\n";

            //
            // TEST DELETING SOMETHINGS

            // Removing a prefix should fail
            var removing_acto_fails = false;
            try
            {
                // try removing a non-terminal word
                trie.Remove("acto");
                removing_acto_fails = false;
            }
            catch
            {
                // if exception occured then code works, word doesn't exist.
                removing_acto_fails = true;
            }

            result = result + "removing_acto_fails: " + removing_acto_fails + "\n";
            result = result + "trie.Count: " + trie.Count + "\n\n";


            // Removing a word should work
            var removing_acting_passes = false;
            try
            {
                // try removing a non-terminal word
                trie.Remove(word_acting);
                removing_acting_passes = true;
            }
            catch
            {
                // if exception occured then code DOESN'T work, word does exist.
                removing_acting_passes = false;
            }

            result = result + "removing_acting_passes: " + removing_acting_passes + "\n";
            result = result + "trie.Count: " + trie.Count + "\n\n";

            someActiWords = trie.SearchByPrefix("acti").ToList();
            result = result + "someActiWords.Count: " + someActiWords.Count + "\n";
            result = result + "someActiWords.Contains: " + "'" + word_active + "'" + " is " + someActiWords.Contains(word_active) + "\n\n";

            //
            // TEST ENUMERATOR

            var enumerator = trie.GetEnumerator();
            var allWords = new List<string>();
            while (enumerator.MoveNext())
                allWords.Add(enumerator.Current);

            // Assert size
            result = result + "allWords.Count: " + allWords.Count + "\n";
            result = result + "trie.Count: " + trie.Count + "\n\n";

            // Assert each element
            Console.WriteLine();
            foreach (var word in allWords)
            {
                result = result + "listOfActWords.Contains: " + "'" + word + "'" + " is " + listOfActWords.Contains(word) + "\n";
                result = result + "listOfHow.Contains: " + "'" + word + "'" + " is " + listOfHow.Contains(word) + "\n\n";
            }


            result = result + "Testing is finished.";

            HtmlString html = StringHelper.GetHtmlString(result);
            return View(html);
        }
    }
}
