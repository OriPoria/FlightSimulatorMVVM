using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;


namespace flightSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        IFlightModel myFilght;

        public MainWindow()
        {
            InitializeComponent();
            INotifyPropertyChanged user = new User();
            ITelnetClient telnetClient = new MyTelnetClient();
            IFlightModel flightModel = new MyFlight(telnetClient);
            flightModel.PropertyChanged += test11; // test
            flightModel.connect("127.0.0.1", 5402);
            myFilght = flightModel;
            


        }
        






        //this function enrolled the event of property changed and need to deal with it
        public void test11 (Object o, PropertyChangedEventArgs e)
        {
            this.Dispatcher.Invoke(() => { x1.Content = x1.Content+ e.ToString(); });    
        }

        private void x2_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(myFilght.start);
            thread.Start();
        }

        private void x3_Click(object sender, RoutedEventArgs e)
        {
            myFilght.disconnect();
        }
    }
}
