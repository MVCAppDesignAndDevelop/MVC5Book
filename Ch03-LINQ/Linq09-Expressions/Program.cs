using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Linq09_Expressions
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list1 = new List<int>() { 1, 2, 3, 4, 5, 6 };
            List<int> list2 = new List<int>() { 6, 4, 2, 7, 9, 0 };

            // example 1. sample expression.
            var queryEx1 = list1.AsQueryable().Where(c => c > 3);
            var queryEx2 = list1.AsQueryable().Where(c => c > 3).Take(2);

            var query4 = from item1 in list1.AsQueryable()
                         join item2 in list2.AsQueryable() on item1 equals item2 into g
                         from item in g
                         select new { v = item1, c = item };

            // 在此設定中斷點，並用 Expression Tree Viewer 來看它的運算式組成。
            foreach (var q in query4)
                Console.WriteLine("{0} count: {1} ", q.v, q.c);

            Console.Read();
        }
    }
}
