using System;
using System.Windows;


namespace FlightSimulator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public ViewModel MainViewModel { get; internal set; }

        [Obsolete]
        public void App_Startup(object sender, StartupEventArgs e)
        {
            ITelnetClient telnetClient = new MyTelnetClient();
            IFlightModel flightModel = new MyFlight(telnetClient);

            MainViewModel = new ViewModel(flightModel);
            MainViewModel.InitializeVM();


            MainWindow mainWindow = new MainWindow(flightModel);

            FirstPage first = new FirstPage();
            first.SetFlight(flightModel);
            first.SetMain(mainWindow);

            first.ShowDialog();

        }



    }
   
}
