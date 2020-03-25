using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flightSimulator.ViewModel
{
    class SteeringViewModel : INotifyPropertyChanged
    {
        private IFlightModel myModel;
        SteeringViewModel(IFlightModel m)
        {
            this.myModel = m;

        }

        public double VM_throttle
        {
            get
            {
                return 0;
            }
            set
            {

            }
        }
        public double VM_rudder
        {
            get
            {
                return 0;
            }
            set
            {

            }
        }
        public double VM_elevator
        {
            get
            {
                return 0;
            }
            set
            {

            }
        }
        public double VM_aileron
        {
            get
            {
                return 0;
            }
            set
            {

            }
        }




        public event PropertyChangedEventHandler PropertyChanged;

    }
}
