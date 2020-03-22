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
        private double detail;
        public PropertyChangedEventArgs(string p)
        {
            this.property = p;
        }
        public override string ToString()
        {
            var str = new StringBuilder();
            str.Append(this.property).Append(": ").Append(detail.ToString());
            return str.ToString();
        }

    }
}
