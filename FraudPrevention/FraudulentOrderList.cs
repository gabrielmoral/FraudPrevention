using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FraudPrevention
{
    public class FraudulentOrderList
    {
        private OrderList fraudulentOrderList = new OrderList();

        public void AddOrderIfNotExists(Order order)
        {
            if (!this.fraudulentOrderList.Where(x => x.OrderId == order.OrderId).Any())
            {
                this.fraudulentOrderList.Add(order);
            }
        }

        public int NumberOfFraudulentOrders
        {
            get
            {
                return this.fraudulentOrderList.Count();
            }
        }

        public string PrintOrderIds()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var order in this.fraudulentOrderList)
            {
                sb.Append(order.OrderId);
                sb.Append(",");
            }

            sb.Remove(sb.Length - 1, 1);

            return sb.ToString();
        }
    }
}
