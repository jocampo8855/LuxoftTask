using LuxoftTask;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LuxoftTask.UnitTest
{
    [TestClass]
    public class CashierTests
    {
        [TestMethod]
        public void ValidatePayment_AmountBiggerThanPrice_ExcpectTrue()
        {
            var cashier = new Cashier();

            var result = cashier.ValidatePayment(5.25, 6);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidatePayment_AmountEqualThanPrice_ExcpectTrue()
        {
            var cashier = new Cashier();

            var result = cashier.ValidatePayment(5.25, 5.25);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidatePayment_AmountMinorThanPrice_ExcpectFalse()
        {
            var cashier = new Cashier();

            var result = cashier.ValidatePayment(5.25, 4);

            Assert.IsFalse(result);
        }
    }
}
