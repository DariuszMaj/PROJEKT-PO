using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for ChangePasswordWindow.xaml
    /// </summary>
    public partial class DeleteUserWindow : Window
    {
        public DeleteUserWindow()
        {
            InitializeComponent();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e) { if (e.LeftButton == MouseButtonState.Pressed) DragMove(); }

        private void closeChangedPassword_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AproveChangedPassword_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new Model1())
            {

                var querycount = (from Logg in context.Passwords
                                  select Logg).Count();
                if(Convert.ToInt32(querycount)==1)
                {
                    UserMessages NewInfo = new UserMessages();
                    NewInfo.SomethingWrong.Text = "Nie można usunąć.";
                    NewInfo.Show();
                    Thread.Sleep(1000);
                    this.Close();
                }

                else
                {

              
                var query = from Logg in context.Passwords
                            where Logg.Login == Login_to_Delete_Account.Text
                            select Logg;
                if (query.SingleOrDefault() != null)
                {
                    var query1 = (from Logg in context.Passwords
                                  where Logg.Login == Login_to_Delete_Account.Text
                                  select Logg).FirstOrDefault();


                    context.Passwords.Remove(query1);






                    context.SaveChanges();

                    UserMessages NewInfo = new UserMessages();
                    NewInfo.SomethingWrong.Text = "Użytkownik usunięty.";
                    NewInfo.Show();
                    Thread.Sleep(1000);
                    this.Close();

                  





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
}

