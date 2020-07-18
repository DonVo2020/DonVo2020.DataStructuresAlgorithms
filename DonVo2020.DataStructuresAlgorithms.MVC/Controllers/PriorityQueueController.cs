using System;
using Microsoft.AspNetCore.Mvc;
using DonVo2020.DataStrutures.NetCore31.Heaps;
using Microsoft.AspNetCore.Html;
using DonVo2020.DataStrutures.NetCore31.StringHelpers;

namespace DonVo2020.DataStructuresAlgorithms.MVC.Controllers
{
    public class PriorityQueueController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            string result = string.Empty;

            // KEYED PRIORITY QUEUE
            PriorityQueue<int, int, int> keyedPriorityQueue = new PriorityQueue<int, int, int>(10);

            for (int i = 0; i < 20; ++i)
            {
                keyedPriorityQueue.Enqueue(i, i, (i / 3) + 1);
            }

            result = result + "Enqueue Keys: ";
            foreach (var key in keyedPriorityQueue.Keys)
            {
                result = result + key + ",";
            }

            var keyedPQHighest = keyedPriorityQueue.Dequeue();
            result = result + "\nAfter Dequeue, Keyed PQ Highest = " + keyedPQHighest + "\n\n";

            // Integer-index priority-queue
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            result = result + "Alphabets: " + "abcdefghijklmnopqrstuvwxyz" + "\n";
            MinPriorityQueue<string, int> priorityQueue = new MinPriorityQueue<string, int>((uint)alphabet.Length);

            for (int i = 0; i < alphabet.Length; ++i)
            {
                priorityQueue.Enqueue(alphabet[i].ToString(), (i / 3) + 1);
            }

            var PQMin = priorityQueue.DequeueMin();
            result = result + "PQ Min = " + PQMin + "\n\n";

            // Processes with priorities
            MinPriorityQueue<Process, int> sysProcesses = new MinPriorityQueue<Process, int>();

            var process1 = new Process(
                id: 432654,
                 action: new Action(() => System.Console.Write("I am Process #1.\r\n1 + 1 = " + (1 + 1))),
                desc: "Process 1");

            result = result + "Id: " + process1.Id + "\nI am Process #1: 1 + 1 = " + (1 + 1) + "\n\n";

            var process2 = new Process(
                id: 123456,
                action: new Action(() => System.Console.Write("Hello, World! I am Process #2")),
                desc: "Process 2");

            result = result + "Id: " + process2.Id + "\nHello, World! I am Process #2" + "\n\n";

            var process3 = new Process(
                id: 345098,
                action: new Action(() => System.Console.Write("I am Process #3")),
                desc: "Process 3");

            result = result + "Id: " + process3.Id + "\nI am Process #3" + "\n\n";

            var process4 = new Process(
                id: 109875,
                action: new Action(() => System.Console.Write("I am Process #4")),
                desc: "Process 4");

            result = result + "Id: " + process4.Id + "\nI am Process #4" + "\n\n";

            var process5 = new Process(
                id: 13579,
                action: new Action(() => System.Console.Write("I am Process #5")),
                desc: "Process 5");

            result = result + "Id: " + process5.Id + "\nI am Process #5" + "\n\n";

            var process6 = new Process(
                id: 24680,
                action: new Action(() => System.Console.Write("I am Process #6")),
                desc: "Process 6");

            result = result + "Id: " + process6.Id + "\nI am Process #6" + "\n\n";

            sysProcesses.Enqueue(process1, 1);
            sysProcesses.Enqueue(process2, 10);
            sysProcesses.Enqueue(process3, 5);
            sysProcesses.Enqueue(process4, 7);
            sysProcesses.Enqueue(process5, 3);
            sysProcesses.Enqueue(process6, 6);

            var leastPriorityProcess = sysProcesses.PeekAtMinPriority();
            result = result + "First, Least Priority Process.Id = " + leastPriorityProcess.Id + "\n";

            sysProcesses.DequeueMin();

            leastPriorityProcess = sysProcesses.PeekAtMinPriority();
            result = result + "After the second DequeueMin(), Least Priority Process.Id = " + leastPriorityProcess.Id + "\n";

            sysProcesses.DequeueMin();

            leastPriorityProcess = sysProcesses.PeekAtMinPriority();
            result = result + "After the third DequeueMin(), Least Priority Process.Id = " + leastPriorityProcess.Id + "\n";

            sysProcesses.DequeueMin();

            leastPriorityProcess = sysProcesses.PeekAtMinPriority();
            result = result + "After the forth DequeueMin(), Least Priority Process.Id = " + leastPriorityProcess.Id + "\n";

            leastPriorityProcess.Action();

            HtmlString html = StringHelper.GetHtmlString(result);
            return View(html);

        }

        internal class Process : IComparable<Process>
        {
            public int Id { get; set; }
            public Action Action { get; set; }
            public string Description { get; set; }

            public Process(int id, Action action, string desc)
            {
                Id = id;
                Action = action;
                Description = desc;
            }

            public int CompareTo(Process other)
            {
                if (other == null)
                    return -1;

                return Id.CompareTo(other.Id);
            }
        }
    }
}
