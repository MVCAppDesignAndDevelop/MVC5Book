using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorSample;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace CalculatorSample.Tests
{
    [TestClass()]
    public class CalculatorTests
    {
        [TestMethod()]
        public void AddTest_first為1_second為2_result應為3()
        {
            //arrange
            var target = new Calculator();

            var first = 1;
            var second = 2;

            var expected =3;

            //act
            var actual = target.Add(first, second);

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
