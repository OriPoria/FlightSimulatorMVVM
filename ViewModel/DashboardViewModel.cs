using System;
using System.ComponentModel;

namespace FlightSimulator
{
    public class DashboardViewModel : ViewModel
    {
        public DashboardViewModel(IFlightModel m) : base(m)
        {
            this.myModel = m;
            myModel.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM" + e.PropertyName);
            };

        }


        public double VMheading
        {
            get { return myModel.GetData("heading"); }
            set { }
        }
        public double VMverticalSpeed
        {
            get { return myModel.GetData("verticalSpeed"); }
            set { }
        }
        public double VMgroundSpeed
        {
            get { return myModel.GetData("groundSpeed"); }
            set { }
        }
        public double VMairSpeed
        {
            get { return myModel.GetData("airSpeed"); }
            set { }
        }
        public double VMaltitude
        {
            get { return myModel.GetData("altitude"); }
            set { }
        }
        public double VMroll
        {
            get { return myModel.GetData("roll"); }
            set { }
        }
        public double VMpitch
        {
            get { return myModel.GetData("pitch"); }
            set { }
        }
        public double VMaltimeter
        {
            get { return myModel.GetData("altimeter"); }
            set { }
        }

    }

}
