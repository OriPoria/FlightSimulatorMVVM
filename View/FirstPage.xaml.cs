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
using System.Windows.Shapes;
using System.Threading;


namespace flightSimulator
{
    /// <summary>
    /// Interaction logic for FirstPage.xaml
    /// </summary>
    public partial class FirstPage : Window
    {
        private MainWindow myMain;
        private IFlightModel myFlight;
        public FirstPage()
        {
            InitializeComponent();
        }
        public void SetFlight(IFlightModel ifm)
        {
            this.myFlight = ifm;
        }
        public void SetMain(MainWindow mw)
        {
            this.myMain = mw;
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int port = Int32.Parse(this.port_text_box.Text);


            myFlight.Connect(this.ip_textbox.Text, port);

            Thread t = new Thread(new ThreadStart(myFlight.Start));
            t.Start();

            this.Close();
            myMain.Show();
            
        }



        private void Button_Click2(object sender, RoutedEventArgs e)
        {

            myFlight.Connect("127.0.0.1", 5402);

            Thread t = new Thread(new ThreadStart(myFlight.Start));
            t.Start();

            this.Close();
            myMain.Show();
            

        }
    }
}
