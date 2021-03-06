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
    public partial class AddUserWindow : Window
    {
        public AddUserWindow()
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
                var query = from Logg in context.Passwords
                            where Logg.Login == Login_to_New_Account.Text
                            select (Logg);
                if (query.SingleOrDefault() == null && NewPassword.Password == ConfirmedPassword.Password)
                {
                    var AddUser = context.Set<Password>();
                    AddUser.Add(new Password { Imie = Name_to_New_Account.Text.Trim(), Nazwisko =Surname_to_New_Account.Text.Trim(), Login = Login_to_New_Account.Text, Password1 =NewPassword.Password });
                    context.SaveChanges();

                    UserMessages NewInfo = new UserMessages();
                    NewInfo.SomethingWrong.Text = "Użytkownik został dodany.";
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
               if(NewPassword.Password!=ConfirmedPassword.Password)
                {
                    UserMessages NewInfo = new UserMessages();
                    NewInfo.SomethingWrong.Text = "Hasła nie są takie same!";
                    NewInfo.Show();
                }
              
            }
        }
    }
}

