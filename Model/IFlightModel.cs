using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace flightSimulator
{
    public interface IFlightModel : INotifyPropertyChanged
    {
        void connect(string ip, int port);
        void disconnect();
        void start();
        double getData(string proName);
        void addCommand(string command);

        double Throttle { set; get; }
        double Rudder { set; get; }
        double Aileron { set; get; }
        double Elevator { set; get; }

    }
}
