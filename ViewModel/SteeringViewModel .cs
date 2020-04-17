using System;
using System.ComponentModel;


namespace FlightSimulator
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
                NotifyPropertyChanged("VM" + e.PropertyName);
            };
        }

        public double VMthrottle
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
        public double VMrudder
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
        public double VMelevator
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
        public double VMaileron
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
