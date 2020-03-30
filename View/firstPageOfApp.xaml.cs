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

namespace flightSimulator
{
    /// <summary>
    /// Interaction logic for firstPageOfApp.xaml
    /// </summary>
    public partial class firstPageOfApp : Page
    {
        public firstPageOfApp()
        {
            InitializeComponent();
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int port = Int32.Parse(this.port_text_box.Text);
            // this.NavigationService.Navigate(new MainWindow(this.ip_textbox.Text,port));
            // this.NavigationService.Navigate(new SimulatorPage());

            MainWindow mainWindow = new MainWindow(this.ip_textbox.Text, port);
            mainWindow.ShowDialog();
        }



        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            //this.NavigationService.Navigate(new MainWindow("127.0.0.1", 5402));
            MainWindow mainWindow = new MainWindow("127.0.0.1", 5402);
            mainWindow.ShowDialog();
        }
    }
}
