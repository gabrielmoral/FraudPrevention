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
        private Order actualOrder;
        private Order comparerOrder;

        public OrderProcessor(OrderList orderList)
        {
            this.orderList = orderList;
        }

        public FraudulentOrderList Process()
        {
            FraudulentOrderList fraudulentOrders = new FraudulentOrderList();

            foreach (var order in orderList)
            {
                this.actualOrder = order;

                foreach (var comparerOrder in orderList)
                {
                    this.comparerOrder = comparerOrder;

                    if (this.actualOrder.OrderId == this.comparerOrder.OrderId)
                        continue;

                    bool isFraudulentByEmail = this.IsFraudulentOrderWithSameEmailAndDealId();
                    bool isFraudulentByLocation = this.IsFraudulentOrderWithSameLocationAndDealId();

                    if (isFraudulentByEmail || isFraudulentByLocation)
                    {
                        fraudulentOrders.AddOrderIfNotExists(this.actualOrder);
                        fraudulentOrders.AddOrderIfNotExists(this.comparerOrder);
                    }
                }
            }

            return fraudulentOrders;
        }

        private bool IsFraudulentOrderWithSameLocationAndDealId()
        {
            return this.IsFraudulentOrderWithSameLocation() && this.IsFraudulentOrderWithSameDealId();
        }

        private bool IsFraudulentOrderWithSameEmailAndDealId()
        {
            EmailChecker emailChecker = new EmailChecker(this.actualOrder.Email, this.comparerOrder.Email);

            return emailChecker.IsSameEmail() && this.IsFraudulentOrderWithSameDealId();
        }

        private bool IsFraudulentOrderWithSameDealId()
        {
            return this.actualOrder.DealId == this.comparerOrder.DealId;
        }

        private bool IsFraudulentOrderWithSameLocation()
        {
            AddressChecker addressChecker = new AddressChecker(actualOrder.StreetAddress, this.comparerOrder.StreetAddress, new StreetAbreviatures());
            AddressChecker stateChecker = new AddressChecker(actualOrder.State, this.comparerOrder.State, new StateAbreviatures());

            bool isSameAddress = addressChecker.IsSameAddress();
            bool isSameState = stateChecker.IsSameAddress();

            return isSameAddress && isSameState && this.actualOrder.City.Equals(this.comparerOrder.City) && this.actualOrder.ZipCode.Equals(this.comparerOrder.ZipCode);
        }
    }
}
