using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace StubAndMockSample.Tests
{
    [TestClass()]
    public class PubTests
    {
        [TestMethod]
        public void CheckInTest_Customer_2女1男_應收費人數為1()
        {
            //arrange
            ICheckInFee stubCheckInFee = MockRepository.GenerateStub<ICheckInFee>();
            Pub target = new Pub(stubCheckInFee);

            stubCheckInFee.Stub(x => x.GetFee(Arg<Customer>.Is.Anything)).Return(100);

            var customers = new List<Customer>
            {
                new Customer{ IsMale=true},
                new Customer{ IsMale=false},
                new Customer{ IsMale=false},
            };

            decimal expected = 1;

            //act
            var actual = target.CheckIn(customers);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Customer_2女1男_收費標準100_Income應為100()
        {
            //arrange
            ICheckInFee stubCheckInFee = MockRepository.GenerateStub<ICheckInFee>();
            Pub target = new Pub(stubCheckInFee);

            stubCheckInFee.Stub(x => x.GetFee(Arg<Customer>.Is.Anything)).Return(100);

            var customers = new List<Customer>
            {
                new Customer{ IsMale=true},
                new Customer{ IsMale=false},
                new Customer{ IsMale=false},
            };

            var inComeBeforeCheckIn = target.GetInCome();
            Assert.AreEqual(0, inComeBeforeCheckIn);

            decimal expectedIncome = 100;

            //act
            var chargeCustomerCount = target.CheckIn(customers);

            var actualIncome = target.GetInCome();

            //assert
            Assert.AreEqual(expectedIncome, actualIncome);
        }

        [TestMethod]
        public void CheckInTest_2男1女_與ICheckInFee互動2次()
        {
            //arrange mock
            var customers = new List<Customer>();

            //2男1女
            var customer1 = new Customer { IsMale = true, Seq = 1 };
            var customer2 = new Customer { IsMale = false, Seq = 2 };
            var customer3 = new Customer { IsMale = true, Seq = 3 };

            customers.Add(customer1);
            customers.Add(customer2);
            customers.Add(customer3);

            MockRepository mock = new MockRepository();
            ICheckInFee stubCheckInFee = mock.StrictMock<ICheckInFee>();

            using (mock.Record())
            {
                //期望呼叫ICheckInFee的GetFee()次數為2次
                //且第一次的參數為customer1, 第二次的參數為customer3
                stubCheckInFee.GetFee(customer1);
                LastCall
                    .Return((decimal)100);

                stubCheckInFee.GetFee(customer3);
                LastCall
                    .Return((decimal)200);

                ////若不需要檢查傳入參數，只需要確認呼叫次數為2次，可以這樣寫
                //stubCheckInFee.GetFee(customer1);
                //LastCall
                //    .IgnoreArguments().Return((decimal)200)
                //    .Repeat.Times(2);
            }

            using (mock.Playback())
            {
                var target = new Pub(stubCheckInFee);

                var count = target.CheckIn(customers);
            }
        }
    }
}