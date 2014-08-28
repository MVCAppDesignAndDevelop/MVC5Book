using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linq03_ImplementExtensionMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            int money = 123456789;
            double p = 0.1029;

            Console.WriteLine("{0}", money.FormatForMoney());
            Console.WriteLine("{0}", p.FormatPercent());
            Console.ReadLine();
        }
    }

    public static class Int32Extension
    {
        public static string FormatForMoney(this int Value)
        {
            return Value.ToString("$###,###,###,##0");
        }
    }

    public static class DoubleExtension
    {
        public static string FormatPercent(this double Value)
        {
            return Value.ToString("0.00%");
        }
    }
}
