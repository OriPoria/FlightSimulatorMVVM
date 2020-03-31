using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace flightSimulator
{
    class MapViewModel : ViewModel
    {
        
        public MapViewModel(IFlightModel ifm)
        {
            this.myModel = ifm;
            myModel.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };

        }
        public double VM_latitude
        {
            get
            {
                double i = myModel.getData("latitude");
                return myModel.getData("latitude");
            }
            set
            {

            }
        }
        public double VM_longitude
        {
            get
            {
                return myModel.getData("longitude");
            }

        }






    }
}
