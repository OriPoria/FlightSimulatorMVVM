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
        void App_Startup(object sender, StartupEventArgs e)
        {
            ITelnetClient telnetClient = new MyTelnetClient();
            IFlightModel flightModel = new MyFlight(telnetClient);

            ViewModel mapVM = new MapViewModel(flightModel);
            ViewModel steeringVM = new SteeringViewModel(flightModel);
            ViewModel dashBoardVM = new DashboardViewModel(flightModel);

            SimulatorPage simPage = new SimulatorPage();
            simPage.setMapVM(mapVM);



            MainWindow mainWindow = new MainWindow();
            mainWindow.Content = simPage;
            mainWindow.Show();
            flightModel.connect("127.0.0.1", 5402);
            Thread t = new Thread(new ThreadStart(flightModel.start));
            t.Start();
        }
    }
}
