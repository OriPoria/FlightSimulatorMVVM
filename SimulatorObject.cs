using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flightSimulator
{
    public class SimulatorObject
    {
        private string name;
        private string sim;
        private double val;
        private IFlightModel myFlight;
        public SimulatorObject(string n, string s)
        {
            this.name = n;
            this.sim = s;
            this.val = 0;

        }
        public string Sim
        {
            get
            {
                return this.sim;
            }
        }
        public string Name
        {
            get
            {
                return this.name;
            }
        }
        public double Value
        {
            get
            {
                return this.val;
            }
            set
            {
                this.val = value;
            }
        }



    }
}
