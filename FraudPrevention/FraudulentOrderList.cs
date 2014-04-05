using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FraudPrevention
{
    public class FraudulentOrderList
    {
        private List<int> fraudulentOrderIds = new List<int>();

        public void AddOrderIfNotExists(int orderId)
        {
            if (!fraudulentOrderIds.Where(x => x == orderId).Any())
            {
                fraudulentOrderIds.Add(orderId);
            }
        }

        public int NumberOfFraudulentOrders
        {
            get
            {
                return fraudulentOrderIds.Count;
            }
        }

        public string PrintOrderIds()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var id in this.fraudulentOrderIds)
            {
                sb.Append(id);
                sb.Append(",");
            }

            sb.Remove(sb.Length - 1, 1);

            return sb.ToString();
        }
    }
}
