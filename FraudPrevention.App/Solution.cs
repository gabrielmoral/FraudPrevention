﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FraudPrevention.App
{
    class Solution
    {
        static void Main(string[] args)
        {
            List<string> orderStringList = new List<string>();

            int times = int.Parse(Console.ReadLine());

            for (int i = 0; i < times; i++)
            {
                orderStringList.Add(Console.ReadLine());
            }

            OrderList orderList = new OrderCreator(orderStringList).Create();

            OrderProcessor orderProcessor = new OrderProcessor(orderList);
            FraudulentOrderList fraudulentOrders = orderProcessor.Process();

            Console.WriteLine(fraudulentOrders.PrintOrderIds());

            Console.ReadLine();
        }
    }
}
