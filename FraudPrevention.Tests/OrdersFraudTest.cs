using System;
using FraudPrevention;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FraudPrevention.Tests
{
    [TestClass]
    public class OrdersFraudTest
    {
        [TestMethod]
        public void OrdersWithSameEmailAndDealIdAreFraudulent()
        {
            string order1 = "1,1,bugs@bunny.com,123 Sesame St.,New York,NY,10011,12345689010";
            string order2 = "2,1,elmer@fudd.com,123 Sesame12 St.,New York,NY,10011,10987654321";
            string order3 = "3,1,bugs@bunny.com,123 Sesame14 St.,New York,NY,10011,12345689010";
            
            List<string> orderStringList = new List<string>()
            {
                order1,
                order2,
                order3
            };

            List<Order> orderList = new OrderCreator(orderStringList).Create();

            OrderProcessor orderProcessor = new OrderProcessor(orderList);
            FraudulentOrderList fraudulentOrders = orderProcessor.Process();

            Assert.AreEqual(2, fraudulentOrders.NumberOfFraudulentOrders);
        }

        [TestMethod]
        public void OrdersWithSameLocationAndDealIdAreFraudulent()
        {
            string order1 = "1,1,bugs@bunny.com,123 Sesame St.,New York,NY,10011,12345689010";
            string order2 = "2,1,elmer@fudd.com,123 Sesame St.,New York,NY,10011,10987654321";
            string order3 = "3,3,bugs@bunny.com,123 Sesame St.,New York,NY,10011,12345689010";

            List<string> orderStringList = new List<string>()
            {
                order1,
                order2,
                order3
            };

            List<Order> orderList = new OrderCreator(orderStringList).Create();

            OrderProcessor orderProcessor = new OrderProcessor(orderList);
            FraudulentOrderList fraudulentOrders = orderProcessor.Process();

            Assert.AreEqual(2, fraudulentOrders.NumberOfFraudulentOrders);
        }

    }
}