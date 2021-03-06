﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FraudPrevention
{
    public class OrderCreator
    {
        private IEnumerable<string> orderStringList;

        public OrderCreator(IEnumerable<string> orderStringList)
        {
            this.orderStringList = orderStringList;
        }

        public OrderList Create()
        {
            OrderList orderList = new OrderList();

            foreach (var stringOrder in this.orderStringList)
            {
                orderList.Add(this.CreateOrder(stringOrder));
            }

            return orderList;
        }

        private Order CreateOrder(string stringOrder)
        {
            var orderElements = stringOrder.Split(',');

            return new Order()
            {
                OrderId = int.Parse(orderElements[0]),
                DealId = int.Parse(orderElements[1]),
                Email = orderElements[2],
                StreetAddress = orderElements[3],
                City = orderElements[4],
                State = orderElements[5],
                ZipCode = orderElements[6],
                CreditCard = orderElements[7],
            };
        }
    }
}
