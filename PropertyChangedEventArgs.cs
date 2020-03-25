using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flightSimulator
{
    public class PropertyChangedEventArgs
    {
        private string property;
        public PropertyChangedEventArgs(string p)
        {
            this.property = p;
        }
        public override string ToString()
        {
            return property;
        }

    }
}
