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

namespace SchoolsMarks
{
    /// <summary>
    /// Interaction logic for UserMessages.xaml
    /// </summary>
    public partial class UserMessages : Window
    {
        public UserMessages()
        {
            InitializeComponent();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e) { if (e.LeftButton == MouseButtonState.Pressed) DragMove(); }

        public string MessageMonit { get; set; }


        private void clOSE_Click(object sender, RoutedEventArgs e)
        {

            Close();
        }
    }
}
