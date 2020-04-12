using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Microsoft.Maps.MapControl.WPF;
using System.Windows;
using System.Windows.Threading;


namespace flightSimulator
{
    class MapViewModel : ViewModel
    {
        private Location loc;
        private double lat;
        private double lon;

        private readonly ViewModel mainVM;

        
        public MapViewModel(IFlightModel ifm) : base(ifm)
        {
            this.mainVM = (Application.Current as App).MainViewModel;
            this.myModel = ifm;
            myModel.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                if (e.PropertyName == "error")
                {
                    mainVM.AddError("Model error");
                    return;
                }
                mainVM.RemoveError("Model error");
                NotifyPropertyChanged("VM_" + e.PropertyName);
                NotifyPropertyChanged("VM_location");

            };
            
        }

        public double VM_latitude
        {
            get
            {
                try
                {
                    double latMdl = myModel.GetData("latitude");
                    if (latMdl < -85 || latMdl > 85)
                    {
                        throw new Exception("Bad limits latitude");
                    }
                    this.lat = latMdl;
                    mainVM.RemoveError("Bad limits latitude");
                    return lat;
                } catch (Exception exception)
                {
                    mainVM.AddError(exception.Message);
                    return this.lat;
                }

            }

        }

        public double VM_longitude
        {
            get
            { 
                try
                {
                    double lonMdl = myModel.GetData("longitude");
                    if (lonMdl > 180 || lonMdl < -180)
                    {
                        throw new Exception("Bad limits longitude");
                    }
                    this.lon = lonMdl;
                    mainVM.RemoveError("Bad limits longitude");
                    return lon;

                } catch (Exception exception)
                {
                    mainVM.AddError(exception.Message);
                    return this.lon;
                }

            }


        }
        public Location VM_location
        {
            get
            {
                this.loc = new Location();
                loc.Latitude = this.lat;
                loc.Longitude = this.lon;
                return loc;
            }

        }





    }
}

