using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FraudPrevention.Abreviatures;

namespace FraudPrevention.Abreviatures
{
    class StateAbreviatures : AbreviatureType
    {
        public AbreviaturesList GetAbreviatures()
        {
            AbreviaturesListEditable abreviatures = new AbreviaturesListEditable();

            abreviatures.Add("illinois", "il");
            abreviatures.Add("new york", "ny");
            abreviatures.Add("california", "ca");

            return abreviatures;
        }
    }
}
