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
        public void App_Startup(object sender, StartupEventArgs e)
        {
            ITelnetClient telnetClient = new MyTelnetClient();
            IFlightModel flightModel = new MyFlight(telnetClient);

            ViewModel mapVM = new MapViewModel(flightModel);
            ViewModel steeringVM = new SteeringViewModel(flightModel);
            ViewModel dashBoardVM = new DashboardViewModel(flightModel);




            MainWindow mainWindow = new MainWindow();
            mainWindow.setVMmap(mapVM);
            mainWindow.setVMdash(dashBoardVM);
            mainWindow.setVMsteering(steeringVM);

            
            FirstPage first = new FirstPage();
            first.setFlight(flightModel);
            first.setMain(mainWindow);

            first.ShowDialog();

        }
    }
}
