

namespace FlightSimulator
{
    public class SimulatorObject
    {
        private double val;
        public SimulatorObject(string n, string s)
        {
            this.Name = n;
            this.Sim = s;
            this.val = 0;
        }
        public string Sim { get; }
        public string Name { get; }
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
