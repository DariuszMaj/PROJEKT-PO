using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using SchoolsMarks;

namespace SchoolsMarks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            Database.SetInitializer(new SchoolMarkInitializer());
        }
    

        private void Window_MouseDown(object sender, MouseButtonEventArgs e) { if (e.LeftButton == MouseButtonState.Pressed) DragMove(); }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new Model1())
            {
                var query = from Logg in context.Passwords
                            where Logg.Login == username.Text && Logg.Password1 == Password.Password
                            select(Logg);
                if (query.SingleOrDefault() != null)
                {
                    Menu menu1 = new Menu();
                    menu1.Show();
                    Close();    
                }
                else
                {
                    UserMessages NewInfo = new UserMessages();
                    NewInfo.SomethingWrong.Text = "Błędne dane!\n Spróbuj jeszcze raz!";
                    NewInfo.Show();
                }
            }
        }
    }
}
