using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linq04_AnonymousType
{
    class Program
    {
        static void Main(string[] args)
        {
            // 匿名型別
            var o = new
            {
                name = "123",
                value = "456"
            };

            // 匿名型別陣列
            var ol = new[] {
                new { name = "123", value = "456"},
                new { name = "123", value = "456"},
                new { name = "123", value = "456"},
                new { name = "123", value = "456"}
            };
        }
    }
}
