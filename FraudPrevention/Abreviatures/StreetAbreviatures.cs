using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FraudPrevention.Abreviatures;

namespace FraudPrevention.Abreviatures
{
    class StreetAbreviatures : AbreviatureType
    {
        public AbreviaturesList GetAbreviatures()
        {
            AbreviaturesListEditable abreviatures = new AbreviaturesListEditable();

            abreviatures.Add("street", "st.");
            abreviatures.Add("road", "rd.");

            return abreviatures;
        }
    }
}
