using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace flightSimulator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public ViewModel MainViewModel { get; internal set; }
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
