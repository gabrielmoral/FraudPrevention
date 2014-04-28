using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FraudPrevention
{
    public class OrderList : IEnumerable<Order>
    {
        IList<Order> orderList = new List<Order>();

        public void Add(Order order)
        {
            orderList.Add(order);
        }

        public IEnumerator<Order> GetEnumerator()
        {
            return orderList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
