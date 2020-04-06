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

        public MainWindow(IFlightModel ifm)
        {
            InitializeComponent();
            this.myFilght = ifm;
            


        }

        private void Window_Closed(object sender, EventArgs e)
        {
            myFilght.Disconnect();
            App.Current.Shutdown();
        }
    }
}
