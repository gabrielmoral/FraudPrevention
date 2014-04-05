using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FraudPrevention
{
    public class Abreviatures
    {
        private Hashtable streets;

        private Hashtable states;

        public Abreviatures()
        {
            this.streets = new Hashtable();
            this.states = new Hashtable();

            this.streets.Add("street", "st.");
            this.streets.Add("road", "rd.");

            this.states.Add("illinois", "il");
            this.states.Add("new york", "ny");
            this.states.Add("california", "ca");
        }

        public Hashtable Streets
        {
            get { return this.streets; }
        }

        public Hashtable States
        {
            get { return this.states; }
        }
    }
}