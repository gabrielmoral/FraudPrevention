using System;
using FraudPrevention;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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

            bool isSameAddress = new AddressChecker(address, fraudAddress, new Abreviatures().Streets).IsSameAddress();

            Assert.IsTrue(isSameAddress);
        }

        [TestMethod]
        public void CompareAddressWithAbbreviatedWords()
        {
            string address = "123 Sesame St.";
            string fraudAddress = "123 Sesame Street";

            bool isSameAddress = new AddressChecker(address, fraudAddress, new Abreviatures().Streets).IsSameAddress();

            Assert.IsTrue(isSameAddress);
        }

        [TestMethod]
        public void CompareStateWithAbbreviatedWords()
        {
            string state = "IL";
            string fraudState = "Illinois";

            bool isSameState = new AddressChecker(state, fraudState, new Abreviatures().States).IsSameAddress();

            Assert.IsTrue(isSameState);
        }
    }
}