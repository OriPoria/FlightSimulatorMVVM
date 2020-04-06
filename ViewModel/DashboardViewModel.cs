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
        public DashboardViewModel(IFlightModel m) : base(m)
        {
            this.myModel = m;
            myModel.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };

        }


        public double VM_heading
        {
            get { return myModel.GetData("heading"); }
            set { }
        }
        public double VM_verticalSpeed
        {
            get { return myModel.GetData("verticalSpeed"); }
            set { }
        }
        public double VM_groundSpeed
        {
            get { return myModel.GetData("groundSpeed"); }
            set { }
        }
        public double VM_airSpeed
        {
            get { return myModel.GetData("airSpeed"); }
            set { }
        }
        public double VM_altitude
        {
            get { return myModel.GetData("altitude"); }
            set { }
        }
        public double VM_roll
        {
            get { return myModel.GetData("roll"); }
            set { }
        }
        public double VM_pitch
        {
            get { return myModel.GetData("pitch"); }
            set { }
        }
        public double VM_altimeter
        {
            get { return myModel.GetData("altimeter"); }
            set { }
        }

    }

}
