using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace flightSimulator
{
    public class DashboardViewModel : ViewModel
    {
        private IFlightModel myModel;
        public DashboardViewModel(IFlightModel m)
        {
            this.myModel = m;
            myModel.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };

        }


        public double VM_heading
        {
            get { return myModel.getData("heading"); }
            set { }
        }
        public double VM_verticalSpeed
        {
            get { return myModel.getData("verticalSpeed"); }
            set { }
        }
        public double VM_groundSpeed
        {
            get { return myModel.getData("groundSpeed"); }
            set { }
        }
        public double VM_airSpeed
        {
            get { return myModel.getData("airSpeed"); }
            set { }
        }
        public double VM_altitude
        {
            get { return myModel.getData("altitude"); }
            set { }
        }
        public double VM_roll
        {
            get { return myModel.getData("roll"); }
            set { }
        }
        public double VM_pitch
        {
            get { return myModel.getData("pitch"); }
            set { }
        }
        public double VM_altimeter
        {
            get { return myModel.getData("altimeter"); }
            set { }
        }

    }

}
