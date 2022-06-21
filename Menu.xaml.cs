
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
using System.Data.SqlClient;

using System.Data;

namespace SchoolMark
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window

    {

        public  List<string> IndeksNumbers = new(); 
        string connectionString = @"Data Source=DAREK-PC\SQLSERVER2019;Initial Catalog=DZIENNIK_DARIUSZ_MAJ_13725;Integrated Security=True";
        public Menu()
        {
            InitializeComponent();
          

        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e) { if (e.LeftButton == MouseButtonState.Pressed) DragMove(); }
        private void Home_Click(object sender, RoutedEventArgs e)
        {

            UserStories.Visibility = Visibility.Hidden; 
            Panel_Ocen.Visibility = Visibility;
            


        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
     


        private void UploadStudentList_Button(object sender, RoutedEventArgs e)
        {
            REsult1.Text="";
            int ClassID = 0;
            if (LO1.IsSelected) ClassID = 1;
            if (LO2.IsSelected) ClassID = 2;
            if (LO3.IsSelected) ClassID = 3;
            if (LO4.IsSelected) ClassID = 4;
            if (LO5.IsSelected) ClassID = 5;
            if (LO6.IsSelected) ClassID = 6;

            string MyQuery = $"SELECT * FROM UCZNIOWIE where ID_Klasy= {ClassID} ";
            using (SqlConnection MyConnect=new SqlConnection(connectionString))
            {





                IndeksNumbers.Clear();
                SqlCommand command = new SqlCommand(MyQuery, MyConnect);
                MyConnect.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ReadSingleRow((IDataRecord)reader);
                    IndeksNumbers.Add(Convert.ToString(reader[4]));
                }
                reader.Close();


                MyConnect.Close();
            }
            
        }

        private void ReadSingleRow(IDataRecord dataRecord)
        {
           REsult1.Text += Convert.ToString(String.Format(">{0} {1}, {2}\n", dataRecord[2], dataRecord[3], dataRecord[4]));
        }
     
        private void ApplyChangedMark_Button(object sender, RoutedEventArgs e)
        {
            string NeededIndex = Convert.ToString(Numer_Albumu.Text);

            //Jeżeli studednt istnieje i znajduje się w pobranej klasie
            if (IndeksNumbers.Contains(NeededIndex))
            {
                try
                {
                    var ChoosenSubject = Przedmioty_zmiana_Oceny.SelectedIndex;
                    if (ChoosenSubject == 0)
                    {

                        UserMessages SubjectMessage = new UserMessages();
                        SubjectMessage.SomethingWrong.Text = "Wybierz przedmiot!";
                        SubjectMessage.Show();


                    }
                    else
                    {


                        using (SqlConnection MyConnect = new SqlConnection(connectionString))
                        {
                            //ID studenta po numerze albumu
                            MyConnect.Open();
                            string idquery = $"Select ID from Uczniowie where Numer_Albumu={NeededIndex}";

                            SqlCommand command_for_id = new SqlCommand(idquery, MyConnect);
                            SqlDataReader readerid = command_for_id.ExecuteReader();
                            String Student_ID = null;
                            while (readerid.Read())
                            {

                                IDataRecord dataReceordid = ((IDataRecord)readerid);
                                Student_ID = Convert.ToString(readerid.GetValue(0));
                            }
                            readerid.Close();

                            //Update oceny
                            string UpdatingQuerry = $"Update OcenyKońcowe set Ocena = {Ocena_zmiana.Text} where ID_Ucznia = {Student_ID} and ID_Przedmiotu = {ChoosenSubject}";
                            SqlCommand command = new SqlCommand(UpdatingQuerry, MyConnect);
                            SqlDataReader reader = command.ExecuteReader();



                            UserMessages NewMark = new UserMessages();
                            NewMark.SomethingWrong.Text = "Pomyślnie zmieniono ocenę!";
                            NewMark.Show();
                        }

                    }
                }
                catch (Exception)
                {
                   
                    UserMessages ErrorOccur = new UserMessages();
                    ErrorOccur.SomethingWrong.Text = "Błędne dane!";
                    ErrorOccur.Show();
                };

            }

            else
            {
             
                UserMessages StudentFailed = new UserMessages();
                StudentFailed.SomethingWrong.Text = "Upewnij się,\n że uczeń znajduje się na liście wybranej klasy!";
                StudentFailed.SomethingWrong.FontSize = 16;
                StudentFailed.Show();
            }




            }

        private void ApplyViewMarks_Button(object sender, RoutedEventArgs e)
        {
            string NeededIndex = Convert.ToString(Numer_Albumu_view.Text);
            int a = 0;
            //Jeżeli studednt istnieje i znajduje się w pobranej klasie
            if (IndeksNumbers.Contains(NeededIndex))
            {
                try
                {
                    var ChoosenSubject = Przedmioty_view_Oceny.SelectedIndex;
                    if (ChoosenSubject == 0) { a = 1; }
                    

                        using (SqlConnection MyConnect = new SqlConnection(connectionString))
                        {
                            //ID studenta po numerze albumu
                            MyConnect.Open();
                            string idquery = $"Select ID from Uczniowie where Numer_Albumu={NeededIndex}";

                            SqlCommand command_for_id = new SqlCommand(idquery, MyConnect);
                            SqlDataReader readerid = command_for_id.ExecuteReader();
                            String Student_ID = null;
                            while (readerid.Read())
                            {

                                IDataRecord dataReceordid = ((IDataRecord)readerid);
                                Student_ID = Convert.ToString(readerid.GetValue(0));
                            }
                            readerid.Close();

                        //pokazanie ocen
                        string UpdatingQuerry;
                        string MarkView="";
                        string Name="";
                        int AvG_Student = 0;
                        if (a == 1) { UpdatingQuerry = $"select * from OcenyKońcowe JOIN Przedmioty ON OcenyKońcowe.ID_Przedmiotu=Przedmioty.ID join Uczniowie on OcenyKońcowe.ID_Ucznia=Uczniowie.ID where ID_Ucznia = {Student_ID}"; }
                        else { UpdatingQuerry = $"select * from OcenyKońcowe JOIN Przedmioty ON OcenyKońcowe.ID_Przedmiotu=Przedmioty.ID join Uczniowie on OcenyKońcowe.ID_Ucznia=Uczniowie.ID where ID_Ucznia = {Student_ID} and ID_Przedmiotu = {ChoosenSubject}"; }
                            
                            SqlCommand command = new SqlCommand(UpdatingQuerry, MyConnect);
                            SqlDataReader readview = command.ExecuteReader();
                        while (readview.Read())
                        {

                            IDataRecord dataReceordid = ((IDataRecord)readview);
                            MarkView += Convert.ToString(String.Format("{0} : {1} \n", readview[5], readview[3]));
                            Name = Convert.ToString(String.Format("{0} {1} \n", readview[9], readview[10]));
                            AvG_Student += int.Parse(Convert.ToString(readview[3]));
                        }
                        readerid.Close();
                        AvG_Student = AvG_Student / 11;
                        
                     
                        UserMessages MarksView = new UserMessages();
                        MarksView.NameMessage.Text = Name;
                        MarksView.SomethingWrong.FontSize = 16;
                        if (ChoosenSubject == 0)
                        {
                            MarksView.SomethingWrong.Text = $"Oceny:  \n {MarkView} \n Średnia: {AvG_Student}";
                            MarksView.ChangeSizeOfMessageWindow.Height = 800;
                            MarksView.SomethingWrong.Height = 300;
                        }
                        else
                        { 
                            MarksView.SomethingWrong.Text = $"Oceny:  \n {MarkView}";
                            MarksView.ChangeSizeOfMessageWindow.Height = 600;
                            MarksView.SomethingWrong.Height = 60;
                        }

                        MarksView.Show();

                        }

                    
                }
                catch (Exception)
                {
                    UserMessages ErrorOccur = new UserMessages();
                    ErrorOccur.SomethingWrong.Text = "Błędne dane!";
                    ErrorOccur.Show();
                };

            }

            else
            {

           
                UserMessages StudentFailed = new UserMessages();
                StudentFailed.SomethingWrong.Text = "Upewnij się,\n że uczeń znajduje się na liście wybranej klasy!";
                StudentFailed.SomethingWrong.FontSize = 16;
                StudentFailed.Show();
            }
        }

        private void Searching_button_Click(object sender, RoutedEventArgs e)
        {
            
            using (SqlConnection MyConnect = new SqlConnection(connectionString))
            {
                //ID studenta po numerze albumu
                try { 
                MyConnect.Open();
                string idquery = $"Select ID from Uczniowie where Numer_Albumu={Searching_User_UserStories.Text}";

                SqlCommand command_for_id = new SqlCommand(idquery, MyConnect);
                SqlDataReader readerid = command_for_id.ExecuteReader();
                var checkIsStudenExist = "";
                while (readerid.Read())
                {

                    IDataRecord dataReceordid = ((IDataRecord)readerid);
                    checkIsStudenExist = Convert.ToString(readerid.GetValue(0));
                }
                readerid.Close();
                    if (checkIsStudenExist == "")
                    {
                        UserMessages ErrorOccur = new UserMessages();
                        ErrorOccur.SomethingWrong.Text = "Błędne dane!";
                        ErrorOccur.Show();
                    }
                    else
                    {
                        string UserStoriesInquiry = $"select Imię,Nazwisko,Numer_Albumu,Frekwencja,Wynik,Nazwa,ROUND(AVG(CAST(Ocena as float)),2) from Uczniowie join OcenyKońcowe on Uczniowie.ID = OcenyKońcowe.ID_Ucznia join Frekwencja on Uczniowie.ID = Frekwencja.ID_Ucznia join Wyniki on Uczniowie.ID = Wyniki.ID_Ucznia join EGZAMINY on Wyniki.ID_Egzaminu = Egzaminy.ID  where Uczniowie.ID = {checkIsStudenExist}  group by Imię,Nazwisko,Numer_Albumu,Frekwencja,Wynik,Nazwa";

                        SqlCommand UserStoriesCommand = new SqlCommand(UserStoriesInquiry, MyConnect);
                        SqlDataReader readerUserStories = UserStoriesCommand.ExecuteReader();
                        string Name = "";
                        string SurName = "";
                        string AVG_User = "";
                        string Number_User = "";
                        string Freq_User = "";
                        string Results = "";


                        while (readerUserStories.Read())
                        {

                            IDataRecord dataReceordid = ((IDataRecord)readerUserStories);
                            Name = Convert.ToString(readerUserStories.GetValue(0));
                            SurName = Convert.ToString(readerUserStories.GetValue(1));
                            Number_User = Convert.ToString(readerUserStories.GetValue(2));
                            Freq_User = Convert.ToString(readerUserStories.GetValue(3));
                            AVG_User = Convert.ToString(readerUserStories.GetValue(6));
                            Results += Convert.ToString(String.Format("{0}: {1} \n", readerUserStories[5], readerUserStories[4]));
                        }
                        readerUserStories.Close();

                        Name_UserStories.Text = Name;
                        Surname_UserStories.Text = SurName;
                        Number_UserStories.Text = Number_User;
                        Freq_UserStories.Text = Freq_User;
                        Results_UserStories.Text = Results;
                        AVG_UserStories.Text = AVG_User;


                        UserStoriesContent.Visibility = Visibility;

                    }


                }catch (Exception) {
                    UserMessages ErrorOccur = new UserMessages();
                    ErrorOccur.SomethingWrong.Text = "Błędne dane!";
                    ErrorOccur.Show();
                }
            }
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            Panel_Ocen.Visibility = Visibility.Hidden;
            UserStories.Visibility = Visibility;
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
    public class MyTime
    {
        public DateTime Clock { get; set; } = DateTime.Now;
    }
}
