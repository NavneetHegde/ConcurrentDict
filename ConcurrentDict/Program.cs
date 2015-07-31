using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace ConcurrentDict
{
    class Program
    {
        static void Main(string[] args)
        {
            var stock = new ConcurrentDictionary<string, int>();

            //Add thread safe if exists add fails without error
            stock.TryAdd("pluralsight", 6);
            stock.TryAdd("pluralsight", 6);

            stock["buddisgtgeeks"] = 7;

            var success = stock.TryUpdate("buddisgtgeeks", 8, 7);

            var newValue = stock.AddOrUpdate("buddisgtgeeks", 1, (key, oldValue) => oldValue + 1);

            //thread safe fetch or add
            Console.WriteLine("New value is {0}", stock.GetOrAdd("buddisgtgeeks", 1));
            //stock.Remove("jDays"); -- Single thread method

            //remove threadsafe and get the value which was removed
            int removedValue;
            stock.TryRemove("NotExists", out removedValue);

            Console.WriteLine(String.Format("No. of shirts in stock = {0}", stock.Count));

            foreach (var keyValPair in stock)
            {
                Console.WriteLine("{0} : {1}", keyValPair.Key, keyValPair.Value);
            }

            Console.ReadLine();
        }
    }
}
