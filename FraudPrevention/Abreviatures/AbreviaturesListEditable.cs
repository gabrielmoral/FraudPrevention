using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FraudPrevention.Abreviatures
{
    class AbreviaturesListEditable : AbreviaturesList
    {
        public void Add(string key, string value)
        {
            this.Abreviatures.Add(key, value);
        }
    }
}
