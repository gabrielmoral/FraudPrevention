using FraudPrevention.Abreviatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FraudPrevention
{
    public class OrderProcessor
    {
        private OrderList orderList;

        public OrderProcessor(OrderList orderList)
        {
            this.orderList = orderList;
        }

        public FraudulentOrderList Process()
        {
            FraudulentOrderList fraudulentOrders = new FraudulentOrderList();

            foreach (var order in orderList)
            {
                foreach (var comparerOrder in orderList)
                {
                    if (order.OrderId == comparerOrder.OrderId)
                        continue;

                    FraudulentOrderChecker checker = new FraudulentOrderChecker(order, comparerOrder);

                    if (checker.IsFraudulent())
                    {
                        fraudulentOrders.AddOrderIfNotExists(order);
                        fraudulentOrders.AddOrderIfNotExists(comparerOrder);
                    }
                }
            }

            return fraudulentOrders;
        }
    }
}
