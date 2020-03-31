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

namespace flightSimulator.View
{
    /// <summary>
    /// Interaction logic for FirstPage.xaml
    /// </summary>
    public partial class FirstPage : Page
    {
        private MainWindow mainWindow;
        public FirstPage(MainWindow mw)
        {
            this.mainWindow = mw;
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.mainWin.Content = new SimulatorPage();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
