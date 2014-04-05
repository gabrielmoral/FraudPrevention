using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FraudPrevention
{
    public class AddressChecker
    {
        private string address;
        private string fraudAddress;
        private Hashtable abreviatures;

        public AddressChecker(string address, string fraudAddress, Hashtable abreviatures)
        {
            this.address = address;
            this.fraudAddress = fraudAddress;
            this.abreviatures = abreviatures;
        }

        public bool IsSameAddress()
        {
            this.ConvertToLower();
            this.CheckAbreviatures();

            return this.address.Equals(this.fraudAddress);
        }

        private void CheckAbreviatures()
        {
            foreach (DictionaryEntry item in abreviatures)
            {
                string pattern = String.Concat(@"\b", item.Key.ToString(), @"\b");
                string replace = item.Value.ToString();

                this.address = Regex.Replace(this.address, pattern, replace);
                this.fraudAddress = Regex.Replace(this.fraudAddress, pattern, replace);
            }
        }

        private void ConvertToLower()
        {
            this.address = this.address.ToLower();
            this.fraudAddress = this.fraudAddress.ToLower();
        }
    }
}