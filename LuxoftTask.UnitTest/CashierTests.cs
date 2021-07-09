using LuxoftTask;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LuxoftTask.UnitTest
{
    [TestClass]
    public class CashierTests
    {
        List<double> denominations = new List<double>() { 0.01, 0.05, 0.10, 0.25, 0.50, 1.00, 2.00, 5.00, 10.00, 20.00, 50.00, 100.00 };
        [TestMethod]
        public void ValidatePayment_AmountBiggerThanPrice_ExcpectTrue()
        {
            var cashier = new Cashier(denominations);

            var result = cashier.ValidatePayment(5.25, 6);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidatePayment_AmountEqualThanPrice_ExcpectTrue()
        {
            var cashier = new Cashier(denominations);

            var result = cashier.ValidatePayment(5.25, 5.25);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidatePayment_AmountMinorThanPrice_ExcpectFalse()
        {
            var cashier = new Cashier(denominations);

            var result = cashier.ValidatePayment(5.25, 4);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CalulateChange_PayExactly_ExcpectCountIsZero()
        {
            var cashier = new Cashier(denominations);
            List<double> amount = new List<double>() {
                5.25
            };
            var result = cashier.CalculateChange(5.25, amount);

            Assert.AreEqual(0 ,result.Count);
        }

        [TestMethod]
        public void CalulateChange_NeedChange_ExcpectTrue()
        {
            var itemPrice = 5.25;

            var cashier = new Cashier(denominations);
            List<double> amount = new List<double>() {
                2,
                2,
                2,
            };

            var change = amount.Sum() - itemPrice;

            var result = cashier.CalculateChange(itemPrice, amount);

            Assert.AreEqual(change, result.Sum());
        }
    }
}
