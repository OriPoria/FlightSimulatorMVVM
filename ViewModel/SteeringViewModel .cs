using System;
using System.ComponentModel;
using System.Windows;

namespace flightSimulator
{
    class SteeringViewModel : ViewModel
    {
        private double throttle;
        private double rudder;
        private double elevator;
        private double aileron;
        public SteeringViewModel(IFlightModel m) : base(m)
        {
            this.myModel = m;
            myModel.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
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


    }
}
