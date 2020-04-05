using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Microsoft.Maps.MapControl.WPF;

namespace flightSimulator
{
    class MapViewModel : ViewModel
    {
        private IFlightModel myModel;
        private Location loc;

        
        public MapViewModel(IFlightModel m)
        {
            this.myModel = m;
            myModel.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
                NotifyPropertyChanged("VM_location");

            };


        }
        public double VM_latitude
        {
            get
            {
                double val = Convert.ToDouble(String.Format("{0:0.000}",myModel.getData("latitude")));
                return val;
            }

        }
        public double VM_longitude
        {
            get
            {
                double val = Convert.ToDouble(String.Format("{0:0.000}", myModel.getData("latitude")));
                return myModel.getData("longitude");
            }


        }
        public Location VM_location
        {
            get
            {
                this.loc = new Location();
                loc.Latitude = myModel.getData("latitude");
                loc.Longitude = myModel.getData("longitude");
                return loc;
            }

        }


        }
    }

