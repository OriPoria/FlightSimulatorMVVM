using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flightSimulator
{
    class MapViewModel : INotifyPropertyChanged
    {
        private IFlightModel myModel;
        public MapViewModel(IFlightModel m)
        {
            this.myModel = m;
            myModel.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.ToString());
            };

        }
        public double VM_latitude
        {
            get
            {
                return myModel.getData("latitude");
            }
        }
        public double VM_longitude
        {
            get
            {
                return myModel.getData("longitude");
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }

        }
    }
}
