using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FraudPrevention
{
    public class Abreviatures
    {
        private IDictionary<string, string> streets;

        private IDictionary<string, string> states;

        public Abreviatures()
        {
            this.streets = new Dictionary<string, string>();
            this.states = new Dictionary<string, string>();

            this.streets.Add("street", "st.");
            this.streets.Add("road", "rd.");

            this.states.Add("illinois", "il");
            this.states.Add("new york", "ny");
            this.states.Add("california", "ca");
        }

        public IDictionary<string, string> Streets
        {
            get { return this.streets; }
        }

        public IDictionary<string, string> States
        {
            get { return this.states; }
        }
    }
}