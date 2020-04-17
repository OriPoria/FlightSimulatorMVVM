using System;
using System.ComponentModel;
using System.Windows;

namespace FlightSimulator
{
    class ErrorViewModel : ViewModel
    {
        private Visibility errorVisi = Visibility.Hidden;
        private string errStr;

        public ErrorViewModel(IFlightModel m) : base(m)
        {
            this.myModel = m;
            myModel.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                if (e.PropertyName == "error")
                {
                    errStr = myModel.Error;
                    VMerror = Visibility.Visible;
                }
                else
                {
                    VMerror = Visibility.Hidden;
                }
            };

        }

        public Visibility VMerror
        {
            get
            {
                return this.errorVisi;
            }
            set
            {
                this.errorVisi = value;
                NotifyPropertyChanged("VMerror");
                NotifyPropertyChanged("VMerrorText");
            }
        }
        public string VMerrorText
        {
            get
            {
                return this.errStr;
            }
        }
    }
}
