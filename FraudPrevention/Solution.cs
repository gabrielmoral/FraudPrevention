using FraudPrevention;
using System;
using System.Collections.Generic;
using System.IO;
class Solution
{
    static void Main(String[] args)
    {
        List<string> orderStringList = new List<string>();

        int times = int.Parse(Console.ReadLine());

        for (int i = 0; i < times; i++)
        {
            orderStringList.Add(Console.ReadLine());
        }

        List<Order> orderList = new OrderCreator(orderStringList).Create();

        OrderProcessor orderProcessor = new OrderProcessor(orderList);
        FraudulentOrderList fraudulentOrders = orderProcessor.Process();

        Console.WriteLine(fraudulentOrders.PrintOrderIds());

        Console.ReadLine();
    }
}
