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

namespace flightSimulator.controls
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        bool isMouseDown = false;
        public UserControl1()
        {
            InitializeComponent();
        }

        private void Knob_MouseDown(object sender, MouseButtonEventArgs e)
        {
            x1.Content = "step1";
            isMouseDown = true;
        }

        private void Knob_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
                x1.Content = "step2";

        }

        private void Knob_MouseUp(object sender, MouseButtonEventArgs e)
        {
                x1.Content = "step0";
                isMouseDown = false;
        }   
    }

}
