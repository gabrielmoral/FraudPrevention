using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FraudPrevention.Abreviatures
{
    internal class AbreviaturesList : IEnumerable<KeyValuePair<string, string>>
    {
        private IDictionary<string, string> abreviatures;

        protected IDictionary<string, string> Abreviatures
        {
            get { return this.abreviatures; }
        }

        public AbreviaturesList()
        {
            this.abreviatures = new Dictionary<string, string>();
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return this.abreviatures.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
