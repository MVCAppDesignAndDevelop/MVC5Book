using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linq05_IEnumerableAndYield
{
    class Program
    {
        static void Main(string[] args)
        {
            var c1 = GetCollection1();

            Console.Write("Output of GetCollection1(): ");

            foreach (var c in c1)
                Console.Write(c + " ");

            Console.WriteLine();

            var c2 = GetCollection2();

            Console.Write("Output of GetCollection2(): ");

            foreach (var c in c2)
                Console.Write(c + " ");

            Console.WriteLine();

            // object initializer
            List<int> numberSeries = new List<int>()
            {
                1, 2, 3, 4, 10, 20, 40, 80, 150
            };

            var c3 = GetCollection3(numberSeries);
            
            Console.Write("Output of GetCollection3(): ");

            foreach (var c in c3)
                Console.Write(c + " ");

            Console.ReadLine();
        }

        private static IEnumerable<int> GetCollection1()
        {
            List<int> list = new List<int>();

            for (int i = 1; i <= 5; i++)
                list.Add(i);

            return list;
        }

        private static IEnumerable<int> GetCollection2()
        {
            for (int i = 1; i <= 5; i++)
                yield return i;
        }

        private static IEnumerable<int> GetCollection3(IEnumerable<int> NumberSeries)
        {
            foreach (var number in NumberSeries)
            {
                if (number > 100)
                    yield break;
                else
                    yield return number;
            }
        }
    }
}
