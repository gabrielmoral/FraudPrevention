using System;
using FraudPrevention;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace FraudPrevention.Tests
{
    [TestClass]
    public class AddressFraudTest
    {
        [TestMethod]
        public void CompareAddressWithUpperCase()
        {
            string address = "123 Sesame St.";
            string fraudAddress = "123 SeSAME st.";

            bool isSameAddress = this.IsSameAddress(address, fraudAddress, new Abreviatures().Streets);

            Assert.IsTrue(isSameAddress);
        }

        [TestMethod]
        public void CompareAddressWithAbbreviatedWords()
        {
            string address = "123 Sesame St.";
            string fraudAddress = "123 Sesame Street";

            bool isSameAddress = this.IsSameAddress(address, fraudAddress, new Abreviatures().Streets);

            Assert.IsTrue(isSameAddress);
        }

        [TestMethod]
        public void CompareStateWithAbbreviatedWords()
        {
            string state = "IL";
            string fraudState = "Illinois";

            bool isSameState = this.IsSameAddress(state, fraudState, new Abreviatures().States);

            Assert.IsTrue(isSameState);
        }

        private bool IsSameAddress(string address, string fraudAddress, Hashtable abreviatures)
        {
            return new AddressChecker(address, fraudAddress, abreviatures).IsSameAddress();
        }
    }
}