using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Linq08_LINQMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list1 = new List<int>() { 1, 2, 3, 4, 5, 6 };
            List<int> list2 = new List<int>() { 6, 4, 2, 7, 9, 0 };

            // select many with list2.
            var query = list1.SelectMany(o => list2);

            foreach (var q in query)
                Console.Write("{0} ", q);

            // LINQ statement of SelectMany
            var query1 = from item1 in list1
                         from item2 in list2
                         select new { a = item1, b = item2 };

            foreach (var q in query1)
                Console.WriteLine("{0} ", q);

            // select many with list2
            var query2 = list1.SelectMany(o => list2, (a, b) => new { a, b });

            foreach (var q in query2)
                Console.WriteLine("{0} ", q);

            // join is equivalent to LINQ statement.
            //var query = from item1 in list1
            //            join item2 in list2 on item1 equals item2
            //            select item2;

            var query3 = list1.Join(
                list2,
                item1 => item1,
                item2 => item2,
                (item1, item2) => item2);

            foreach (var q in query3)
                Console.WriteLine("{0} ", q);

            // LINQ statement with group join
            var query4 = from item1 in list1
                         join item2 in list2 on item1 equals item2 into g
                         from item in g
                         select new { v = item1, c = item };

            foreach (var q in query4)
                Console.WriteLine("{0} count: {1} ", q.v, q.c);

            // LINQ method call equivalent to LINQ statement.            
            var query5 = list1.GroupJoin(
                list2,
                item1 => item1,
                item2 => item2,
                (item1, item2) => new { v = item1, c = item2.Count() });

            foreach (var q in query5)
                Console.WriteLine("{0} count: {1} ", q.v, q.c);

            //List<int> sequences = new List<int>() { 1, 2, 4, 3, 2, 4, 6, 4, 2, 4, 5, 6, 5, 2, 2, 6, 3, 5, 7, 5 };

            //var group = sequences.GroupBy(o => o);

            //foreach (var g in group)
            //    Console.WriteLine("{0} count: {1}", g.Key, g.Count());

            //var group2 = sequences.GroupBy(
            //    o => (o % 2 == 0) ? "Odd Number" : "Even Numbder",
            //    o2 => (o2 % 2 == 0) ? "Odd" : "Even");

            //foreach (var g in group2)
            //    Console.WriteLine(g.ToString());

            // ToLookup() demo
            var nameValuesGroup = new[]
            {
                new { name = "Allen", value = 65, group = "A" },
                new { name = "Abbey", value = 120, group = "A" },
                new { name = "Slong", value = 330, group = "B" },
                new { name = "George", value = 213, group = "C" },
                new { name = "Meller", value = 329, group = "C" },
                new { name = "Mary", value = 192, group = "B" },
                new { name = "Sue", value = 200, group = "C" }
            };
            var lookupValues = nameValuesGroup.ToLookup(c => c.group);
            foreach (var g in lookupValues)
            {
                Console.WriteLine("=== Group : {0} ===", g.Key);
                foreach (var item in g)
                    Console.WriteLine("name: {0}, value: {1}", item.name, item.value);
            }

            // order list.
            var nameValues = new[]
            {
                new { name = "Allen", value = 65 },
                new { name = "Abbey", value = 120 },
                new { name = "Slong", value = 330 },
                new { name = "George", value = 213 },
                new { name = "Meller", value = 329 },
                new { name = "Mary", value = 192 },
                new { name = "Sue", value = 200 }
            };

            // single sort
            var sortedNames = nameValues.OrderBy(c => c.name);
            var sortedValues = nameValues.OrderBy(c => c.value);
            Console.WriteLine("== OrderBy() demo: sortedNames ==");
            foreach (var q in sortedNames)
                Console.WriteLine("name: {0} value: {1} ", q.name, q.value);
            Console.WriteLine("== OrderBy() demo: sortedValues ==");
            foreach (var q in sortedValues)
                Console.WriteLine("name: {0} value: {1} ", q.name, q.value);

            // multiple sort conditions.
            var sortedByNameValues = nameValues.OrderBy(c => c.name).ThenBy(c =>
            c.value);
            var sortedByValueNames = nameValues.OrderBy(c => c.value).ThenBy(c => c.name);
            Console.WriteLine("== OrderBy() + ThenBy() demo: sortedByNameValues ==");
            foreach (var q in sortedByNameValues)
                Console.WriteLine("name: {0} value: {1} ", q.name, q.value);
            Console.WriteLine("== OrderBy() + ThenBy() demo: sortedByValueNames ==");
            foreach (var q in sortedByValueNames)
                Console.WriteLine("name: {0} value: {1} ", q.name, q.value);

            // Union/Intersect/Except
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            var unionResults = numbersA.Union(numbersB);
            var intersectResults = numbersA.Intersect(numbersB);
            var exceptResults = numbersA.Except(numbersB);

            Console.WriteLine("== Union ==");

            foreach (var q in unionResults)
                Console.Write(q + " ");

            Console.WriteLine();
            Console.WriteLine("== Intersect ==");

            foreach (var q in intersectResults)
                Console.Write(q + " ");

            Console.WriteLine();
            Console.WriteLine("== Except ==");

            foreach (var q in exceptResults)
                Console.Write(q + " ");

            Console.WriteLine();

            // distinct
            int[] numberSeries = { 2, 2, 3, 5, 5 };

            var distinctValues = numberSeries.Distinct();

            Console.WriteLine("Distinct values from numberSeries");

            foreach (var q in distinctValues)
                Console.Write(q + " ");

            Console.WriteLine();

            var firstLastItems = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            // First()/Last()
            string firstContainsO = firstLastItems.First(s => s.Contains('o'));
            string lastContainsO = firstLastItems.Last(s => s.Contains('o'));

            Console.WriteLine("First string starting with 'o': {0}", firstContainsO);
            Console.WriteLine("Last string starting with 'o': {0}", lastContainsO);
            
            // ElementAt()
            string itemAtThree = firstLastItems.ElementAt(2);
            string itemAtSix = firstLastItems.ElementAt(5);

            Console.WriteLine("3rd string in list : {0}", itemAtThree);
            Console.WriteLine("6th string in list : {0}", itemAtSix);

            // 存款
            double myBalance = 100.0;
            // 提款的額度
            int[] withdrawItems = { 20, 10, 40, 50, 10, 70, 30 };
            double balance = withdrawItems.Aggregate(myBalance,
            (originbalance, nextWithdrawal) =>
            {
                Console.WriteLine("originbalance: {0}, nextWithdrawal: {1}",
                originbalance, nextWithdrawal);
                Console.WriteLine("Withdrawal status: {0}", (nextWithdrawal <=
                originbalance) ? "OK" : "FAILED");
                // 若存款餘額不夠時，不會扣除，否則扣除提款額度。
                return ((nextWithdrawal <= originbalance) ? (originbalance -
                nextWithdrawal) : originbalance);
            });
            // 顯示最終的存款數
            Console.WriteLine("Ending balance: {0}", balance);

            var balanceStatus = withdrawItems.Aggregate(myBalance,
                (originbalance, nextWithdrawal) =>
                {
                    return ((nextWithdrawal <= originbalance) ? (originbalance -
                    nextWithdrawal) : originbalance);
                },
                (finalbalance) =>
                {
                    return (finalbalance >= 1000) ? "Normal" : "Lower";
                });

            Console.WriteLine("Balance status: {0}", balanceStatus);


            Console.ReadLine();
        }
    }
}
