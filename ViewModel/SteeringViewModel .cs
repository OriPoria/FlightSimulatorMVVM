using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flightSimulator
{
    class SteeringViewModel : INotifyPropertyChanged
    {
        private IFlightModel myModel;

        private double throttle;
        private double rudder;
        private double elevator;
        private double aileron;
        public SteeringViewModel(IFlightModel m)
        {
            this.myModel = m;

        }

        public double VM_Throttle
        {
            get
            {
                return throttle ;
            }
            set
            {
                throttle = value;
                myModel.Throttle = throttle;
            }
        }
        public double VM_Rudder
        {
            get
            {
                return rudder;
            }
            set
            {
                rudder = value;
                myModel.Rudder = rudder;
            }
        }
        public double VM_Elevator
        {
            get
            {
                return elevator;
            }
            set
            {
                elevator = value;
                myModel.Elevator = elevator;
            }
        }
        public double VM_Aileron
        {
            get
            {
                return aileron;
            }
            set
            {
                aileron = value;
                myModel.Aileron = aileron;

            }
        }




        public event PropertyChangedEventHandler PropertyChanged;

    }
}
