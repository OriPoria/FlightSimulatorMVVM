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
        void Connect(string ip, int port);
        void Disconnect();
        void Start();
        double GetData(string proName);
        void AddCommand(string command);

        double Throttle { set; get; }
        double Rudder { set; get; }
        double Aileron { set; get; }
        double Elevator { set; get; }

    }
}
