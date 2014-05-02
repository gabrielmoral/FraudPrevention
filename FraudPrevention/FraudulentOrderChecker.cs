using FraudPrevention.Abreviatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FraudPrevention
{
    class FraudulentOrderChecker
    {
        private Order order;
        private Order comparerOrder;

        public FraudulentOrderChecker(Order order, Order comparerOrder)
        {
            this.order = order;
            this.comparerOrder = comparerOrder;
        }

        public bool IsFraudulent()
        {
            return this.IsFraudulentOrderWithSameLocationAndDealId() || this.IsFraudulentOrderWithSameEmailAndDealId(); 
        }

        private bool IsFraudulentOrderWithSameLocationAndDealId()
        {
            return this.IsFraudulentOrderWithSameLocation() && this.IsFraudulentOrderWithSameDealId();
        }

        private bool IsFraudulentOrderWithSameEmailAndDealId()
        {
            EmailChecker emailChecker = new EmailChecker(this.order.Email, this.comparerOrder.Email);

            return emailChecker.IsSameEmail() && this.IsFraudulentOrderWithSameDealId();
        }

        private bool IsFraudulentOrderWithSameDealId()
        {
            return this.order.DealId == this.comparerOrder.DealId;
        }

        private bool IsFraudulentOrderWithSameLocation()
        {
            AddressChecker addressChecker = new AddressChecker(order.StreetAddress, this.comparerOrder.StreetAddress, new StreetAbreviatures());
            AddressChecker stateChecker = new AddressChecker(order.State, this.comparerOrder.State, new StateAbreviatures());

            bool isSameAddress = addressChecker.IsSameAddress();
            bool isSameState = stateChecker.IsSameAddress();

            return isSameAddress && isSameState && this.order.City.Equals(this.comparerOrder.City) && this.order.ZipCode.Equals(this.comparerOrder.ZipCode);
        }
    }
}
