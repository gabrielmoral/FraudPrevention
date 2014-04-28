﻿using System;
using FraudPrevention;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FraudPrevention.Tests
{
    [TestClass]
    public class EmailFraudTest
    {
        [TestMethod]
        public void CompareEmailWithPoint()
        {
            string email = "bugs1@bunny.com";
            string fraudEmail = "bugs.1@bunny.com";

            bool isSameEmail = this.IsSameEmail(email, fraudEmail);

            Assert.IsTrue(isSameEmail);
        }

        [TestMethod]
        public void CompareEmailWithUpperCase()
        {
            string email = "bugs@bunny.com";
            string fraudEmail = "BuGS@BuNNy.COM";

            bool isSameEmail = this.IsSameEmail(email, fraudEmail);

            Assert.IsTrue(isSameEmail);
        }

        [TestMethod]
        public void CompareEmailWithPlus()
        {
            string email = "bugs@bunny.com";
            string fraudEmail = "bugs+10@bunny.com";

            bool isSameEmail = this.IsSameEmail(email, fraudEmail);

            Assert.IsTrue(isSameEmail);
        }

        private bool IsSameEmail(string email, string fraudEmail) 
        {
            return new EmailChecker(email, fraudEmail).IsSameEmail();
        }
    }
}