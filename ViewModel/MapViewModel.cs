using System;
using System.ComponentModel;
using Microsoft.Maps.MapControl.WPF;
using System.Windows;


namespace FlightSimulator
{
    class MapViewModel : ViewModel
    {
        private Location location;
        private double lat;
        private double lon;

        private readonly ViewModel mainVM;

        
        public MapViewModel(IFlightModel ifm) : base(ifm)
        {
            this.mainVM = (Application.Current as App).MainViewModel;
            this.myModel = ifm;
            myModel.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM" + e.PropertyName);
                NotifyPropertyChanged("VMlocation");
            };
            
        }

        public double VMlatitude
        {
            get
            {
                lat = myModel.GetData("latitude"); 
                return lat;
            }
        }

        public double VMlongitude
        {
            get
            {
                lon = myModel.GetData("longitude");
                return lon;
            }
        }
        public Location VMlocation
        {
            get
            {
                this.location = new Location();
                location.Latitude = this.lat;
                location.Longitude = this.lon;
                return location;
            }
        }

    }
}

