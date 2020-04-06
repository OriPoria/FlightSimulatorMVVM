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
        private Location loc;

        
        public MapViewModel(IFlightModel ifm) : base(ifm)
        {
            this.myModel = ifm;
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
                return myModel.GetData("latitude");
            }

        }
        public double VM_longitude
        {
            get
            {
                return myModel.GetData("longitude");
            }


        }
        public Location VM_location
        {
            get
            {
                this.loc = new Location();
                loc.Latitude = myModel.GetData("latitude");
                loc.Longitude = myModel.GetData("longitude");
                return loc;
            }

        }


        }
    }

