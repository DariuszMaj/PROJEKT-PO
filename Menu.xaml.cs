
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
using System.Timers;

namespace SchoolsMarks
{
    /// <summary>
    /// Main window class
    /// </summary>
    public partial class Menu : Window

    {

        public List<string> IndeksNumbers = new List<string>();

        //2 SPOSÓB - POŁĄCZENIE Z BAZĄ
        //string connectionString = @"Data Source=DAREK-PC\DAREKSQL;Initial Catalog=EGZAMINY;Integrated Security=True";

        public Menu()
        {
            InitializeComponent();


        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e) { if (e.LeftButton == MouseButtonState.Pressed) DragMove(); }
        private void Home_Click(object sender, RoutedEventArgs e)
        {

            UserStories.Visibility = Visibility.Hidden;
            HomePage.Visibility = Visibility.Hidden;
            Panel_Ocen.Visibility = Visibility;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }



        private void UploadStudentList_Button(object sender, RoutedEventArgs e)
        {
            REsult1.Text = "";
            int ClassID = 0;
            if (LO1.IsSelected) ClassID = 1;
            if (LO2.IsSelected) ClassID = 2;
            if (LO3.IsSelected) ClassID = 3;
            if (LO4.IsSelected) ClassID = 4;
            if (LO5.IsSelected) ClassID = 5;
            if (LO6.IsSelected) ClassID = 6;


            using (var StudentList = new Model1())
            {
                REsult1.Clear();
                REsult2.Clear();
                REsult3.Clear();
                IndeksNumbers.Clear();
                var UploadStudentListName = (from Mystudents in StudentList.Uczniowies
                                            .Where(Mystudents => Mystudents.ID_Klasy == ClassID)
                                            .OrderBy(Mystudents => Mystudents.Numer_Albumu)
                                             select Mystudents.Imię);
                var UploadStudentListSurName = (from Mystudents in StudentList.Uczniowies
                                          .Where(Mystudents => Mystudents.ID_Klasy == ClassID)
                                          .OrderBy(Mystudents => Mystudents.Numer_Albumu)
                                                select Mystudents.Nazwisko);
                var UploadStudentListindex = (from Mystudents in StudentList.Uczniowies
                                          .Where(Mystudents => Mystudents.ID_Klasy == ClassID)
                                          .OrderBy(Mystudents => Mystudents.Numer_Albumu)
                                              select Mystudents.Numer_Albumu);

                foreach (var a in UploadStudentListName)
                {

                    REsult1.Text += Convert.ToString(String.Format("   {0}\n", a));
                }
                foreach (var a in UploadStudentListSurName)
                {

                    REsult2.Text += Convert.ToString(String.Format("   {0}\n", a));
                }
                foreach (var a in UploadStudentListindex)
                {

                    REsult3.Text += Convert.ToString(String.Format("   {0}\n", a));
                    IndeksNumbers.Add(Convert.ToString(a));
                }
            } 
        }

        //2 SPOSÓB - ZAPYTANIE DO BAZY

        //string MyQuery = $"SELECT * FROM UCZNIOWIE where ID_Klasy= {ClassID} ";
        //using (SqlConnection MyConnect = new SqlConnection(connectionString))
        //{

        //    IndeksNumbers.Clear();
        //    SqlCommand command = new SqlCommand(MyQuery, MyConnect);
        //    MyConnect.Open();
        //    SqlDataReader reader = command.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        ReadSingleRow((IDataRecord)reader);
        //        IndeksNumbers.Add(Convert.ToString(reader[4]));
        //    }
        //    reader.Close();
        //    MyConnect.Close();
        //}


        //ODCZYT DANYCH 

        //private void ReadSingleRow(IDataRecord dataRecord)
        //{

        //    REsult1.Text += Convert.ToString(String.Format("   {0} {1}, {2}\n", dataRecord[2], dataRecord[3], dataRecord[4]));
        //}

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
                        int checkmyindex = int.Parse(NeededIndex);
                        using (var StudentList = new Model1())
                        {
                            var IDQuery = (from findID in StudentList.Uczniowies
                                           where findID.Numer_Albumu == checkmyindex
                                           select findID).FirstOrDefault();


                            var UpdateMarksQuery = (from MynewsMark in StudentList.OcenyKońcowe
                                                    where MynewsMark.ID_Ucznia == IDQuery.ID && MynewsMark.ID_Przedmiotu == ChoosenSubject
                                                    select MynewsMark).FirstOrDefault();

                            UpdateMarksQuery.Ocena = int.Parse(Ocena_zmiana.Text);
                            StudentList.SaveChanges();

                        }

                        UserMessages NewMark = new UserMessages();
                        NewMark.SomethingWrong.Text = "Pomyślnie zmieniono ocenę!";
                        NewMark.Show();


                        //2 SPOSÓB - ZAPYTANIE DO BAZY

                        //using (SqlConnection MyConnect = new SqlConnection(connectionString))
                        //{
                        //    ////ID studenta po numerze albumu
                        ////MyConnect.Open();
                        ////string idquery = $"Select ID from Uczniowie where Numer_Albumu={NeededIndex}";

                        ////SqlCommand command_for_id = new SqlCommand(idquery, MyConnect);
                        ////SqlDataReader readerid = command_for_id.ExecuteReader();
                        ////String Student_ID = null;
                        //while (readerid.Read())
                        //{

                        //    IDataRecord dataReceordid = ((IDataRecord)readerid);
                        //    Student_ID = Convert.ToString(readerid.GetValue(0));
                        //}
                        //readerid.Close();

                        //Update oceny
                        //string UpdatingQuerry = $"Update OcenyKońcowe set Ocena = {Ocena_zmiana.Text} where ID_Ucznia = {Student_ID} and ID_Przedmiotu = {ChoosenSubject}";
                        //SqlCommand command = new SqlCommand(UpdatingQuerry, MyConnect);
                        //SqlDataReader reader = command.ExecuteReader();

                        //UserMessages NewMark = new UserMessages();
                        //NewMark.SomethingWrong.Text = "Pomyślnie zmieniono ocenę!";
                        //NewMark.Show();
                        //}

                    }
                }
                catch (Exception)
                {

                    UserMessages ErrorOccur = new UserMessages();
                    ErrorOccur.SomethingWrong.Height = 200;
                    ErrorOccur.SomethingWrong.Text = "Błędne dane!";
                    ErrorOccur.Show();

                };
            }

            else
            {

                UserMessages StudentFailed = new UserMessages();
                StudentFailed.SomethingWrong.Height = 200;
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
                var ChoosenSubject = Przedmioty_view_Oceny.SelectedIndex;
                if (ChoosenSubject == 0) { a = 1; }

                try
                {
                    int checkmyindex = int.Parse(NeededIndex);
                    using (var StudentList = new Model1())
                    {
                        string MarkView = "";
                        string Name = "";
                        int AvG_Student = 0;
                        var IDQuery = (from findID in StudentList.Uczniowies
                                       where findID.Numer_Albumu == checkmyindex
                                       select findID).FirstOrDefault();

                        if (a == 1)
                        {
                            var MultipleSubjectView = from OneMark in StudentList.OcenyKońcowe
                                                      from OneSubject in StudentList.Przedmioties
                                                      from OneUser in StudentList.Uczniowies
                                                      where OneMark.ID_Przedmiotu == OneSubject.ID && OneMark.ID_Ucznia == OneUser.ID && OneUser.ID == IDQuery.ID
                                                      select new
                                                      {
                                                          Subject = OneSubject.Nazwa,
                                                          Mark = OneMark.Ocena,
                                                          User = OneUser.Imię,
                                                          SurName = OneUser.Nazwisko
                                                      };



                            foreach (var obj in MultipleSubjectView)
                            {
                                MarkView += Convert.ToString(String.Format("{0} : {1} \n", obj.Subject, obj.Mark));
                                Name = Convert.ToString(String.Format("{0} {1} \n", obj.User, obj.SurName));
                                AvG_Student += int.Parse(Convert.ToString(obj.Mark));
                            }

                        }
                        if (a != 1)
                        {
                            var OneSubjectView = from OneMark in StudentList.OcenyKońcowe
                                                 from OneSubject in StudentList.Przedmioties
                                                 from OneUser in StudentList.Uczniowies
                                                 where OneMark.ID_Przedmiotu == OneSubject.ID && OneMark.ID_Ucznia == OneUser.ID && OneUser.ID == IDQuery.ID && OneSubject.ID == ChoosenSubject
                                                 select new
                                                 {
                                                     Subject = OneSubject.Nazwa,
                                                     Mark = OneMark.Ocena,
                                                     User = OneUser.Imię,
                                                     SurName = OneUser.Nazwisko
                                                 };

                            foreach (var obj in OneSubjectView)
                            {

                                MarkView += Convert.ToString(String.Format("{0} : {1} \n", obj.Subject, obj.Mark));
                                Name = Convert.ToString(String.Format("{0} {1} \n", obj.User, obj.SurName));

                            }

                        }
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

                    //2 SPOSÓB - ZAPYTANIE DO BAZY

                    //using (SqlConnection MyConnect = new SqlConnection(connectionString))
                    //{
                    ////ID studenta po numerze albumu
                    //MyConnect.Open();
                    //string idquery = $"Select ID from Uczniowie where Numer_Albumu={NeededIndex}";

                    //SqlCommand command_for_id = new SqlCommand(idquery, MyConnect);
                    //SqlDataReader readerid = command_for_id.ExecuteReader();
                    //String Student_ID = null;
                    //while (readerid.Read())
                    //{

                    //    IDataRecord dataReceordid = ((IDataRecord)readerid);
                    //    Student_ID = Convert.ToString(readerid.GetValue(0));
                    //}
                    //readerid.Close();

                    //pokazanie ocen
                    //string UpdatingQuerry;
                    //string MarkView = "";
                    //string Name = "";
                    //int AvG_Student = 0;
                    // if (a == 1) { UpdatingQuerry = $"select * from OcenyKońcowe JOIN Przedmioty ON OcenyKońcowe.ID_Przedmiotu=Przedmioty.ID join Uczniowie on OcenyKońcowe.ID_Ucznia=Uczniowie.ID where ID_Ucznia = {Student_ID}"; }
                    //else { UpdatingQuerry = $"select * from OcenyKońcowe JOIN Przedmioty ON OcenyKońcowe.ID_Przedmiotu=Przedmioty.ID join Uczniowie on OcenyKońcowe.ID_Ucznia=Uczniowie.ID where ID_Ucznia = {Student_ID} and ID_Przedmiotu = {ChoosenSubject}"; }

                    // SqlCommand command = new SqlCommand(UpdatingQuerry, MyConnect);
                    // SqlDataReader readview = command.ExecuteReader();
                    // while (readview.Read())
                    // {

                    //     IDataRecord dataReceordid = ((IDataRecord)readview);
                    //     MarkView += Convert.ToString(String.Format("{0} : {1} \n", readview[5], readview[3]));
                    //     Name = Convert.ToString(String.Format("{0} {1} \n", readview[9], readview[10]));
                    //     AvG_Student += int.Parse(Convert.ToString(readview[3]));
                    // }
                    //// readerid.Close();
                    // AvG_Student = AvG_Student / 11;


                    //UserMessages MarksView = new UserMessages();
                    //MarksView.NameMessage.Text = Name;
                    //MarksView.SomethingWrong.FontSize = 16;
                    //if (ChoosenSubject == 0)
                    //{
                    //    //MarksView.SomethingWrong.Text = $"Oceny:  \n {MarkView} \n Średnia: {AvG_Student}";
                    //    //MarksView.ChangeSizeOfMessageWindow.Height = 800;
                    //    //MarksView.SomethingWrong.Height = 300;
                    //}
                    //else
                    //{
                    //    //MarksView.SomethingWrong.Text = $"Oceny:  \n {MarkView}";
                    //    //MarksView.ChangeSizeOfMessageWindow.Height = 600;
                    //    //MarksView.SomethingWrong.Height = 60;
                    //}
                    //MarksView.Show();
                    //}


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


            //ID studenta po numerze albumu
            try
            {
                Name_UserStories.Text = "";
                Surname_UserStories.Text = "";
                Number_UserStories.Text = "";
                Freq_UserStories.Text = "";
                AVG_UserStories.Text = "";
                Results_UserStories.Text = "";
                int CheckAVG = 0;

                int checkmyindex = int.Parse(Searching_User_UserStories.Text);
                using (var StudentList = new Model1())
                {

                    int AvG_Student = 0;
                    var IDQuery = (from findID in StudentList.Uczniowies
                                   where findID.Numer_Albumu == checkmyindex
                                   select findID).FirstOrDefault();
                    if (IDQuery == null)
                    {
                        UserMessages ErrorOccur = new UserMessages();
                        ErrorOccur.SomethingWrong.Text = "Błędne dane!";
                        ErrorOccur.Show();
                    }
                    else
                    {
                        var SearchingQuery = from FindStudent in StudentList.Uczniowies
                                             from FindMark in StudentList.OcenyKońcowe
                                             from FindFreq in StudentList.Frekwencjas
                                             from FindResult in StudentList.Wynikis
                                             from FindExam in StudentList.Egzaminies
                                             where FindStudent.ID == FindMark.ID_Ucznia && FindStudent.ID == FindFreq.ID_Ucznia && FindStudent.ID == FindResult.ID_Ucznia && FindResult.ID_Egzaminu == FindExam.ID && FindStudent.ID == IDQuery.ID
                                             select new
                                             {
                                                 Name = FindStudent.Imię,
                                                 Surname = FindStudent.Nazwisko,
                                                 IndexNO = FindStudent.Numer_Albumu,
                                                 frequention = FindFreq.Frekwencja1,
                                                 AVGmyUser = FindMark.Ocena,
                                                 Results = FindExam.Nazwa + " " + FindResult.Wynik
                                             };

                        var EXXamQuery = from ResultCheck in StudentList.Wynikis
                                         from ExamName in StudentList.Egzaminies
                                         from Usercheck in StudentList.Uczniowies
                                         where ResultCheck.ID_Egzaminu == ExamName.ID && Usercheck.ID == ResultCheck.ID_Ucznia && Usercheck.ID == IDQuery.ID
                                         select new
                                         {
                                             ExamNames = ExamName.Nazwa,
                                             ExamREsults = ResultCheck.Wynik+"%"
                                         };

                        var AVGVIEW = from OneMark in StudentList.OcenyKońcowe
                                      from OneSubject in StudentList.Przedmioties
                                      from OneUser in StudentList.Uczniowies
                                      where OneMark.ID_Przedmiotu == OneSubject.ID && OneMark.ID_Ucznia == OneUser.ID && OneUser.ID == IDQuery.ID
                                      select new
                                      {
                                          Mark = OneMark.Ocena,
                                      };

                        foreach (var obj in AVGVIEW)
                        {

                            AvG_Student += int.Parse(Convert.ToString(obj.Mark));
                        }


                        AvG_Student = AvG_Student / 11;
                        AVG_UserStories.Text = Convert.ToString(AvG_Student);

                        foreach (var item in SearchingQuery)
                        {

                            Name_UserStories.Text = item.Name;
                            Surname_UserStories.Text = item.Surname;
                            Number_UserStories.Text = Convert.ToString(item.IndexNO);
                            Freq_UserStories.Text = Convert.ToString(item.frequention)+"%";
                            CheckAVG += int.Parse(Convert.ToString(item.AVGmyUser));

                        }
                        foreach (var item in EXXamQuery)
                        {
                            Results_UserStories.Text += item.ExamNames + ": " + item.ExamREsults + "\n";
                        }

                        UserStoriesContent.Visibility = Visibility;
                    }

                    //2 SPOSÓB - ZAPYTANIE DO BAZY

                    //using (SqlConnection MyConnect = new SqlConnection(connectionString))
                    //{

                    //    MyConnect.Open();
                    //string idquery = $"Select ID from Uczniowie where Numer_Albumu={Searching_User_UserStories.Text}";

                    //SqlCommand command_for_id = new SqlCommand(idquery, MyConnect);
                    //SqlDataReader readerid = command_for_id.ExecuteReader();
                    //var checkIsStudenExist = "";
                    //while (readerid.Read())
                    //{

                    //    IDataRecord dataReceordid = ((IDataRecord)readerid);
                    //    checkIsStudenExist = Convert.ToString(readerid.GetValue(0));
                    //}
                    //readerid.Close();
                    //if (checkIsStudenExist == "")
                    //{
                    //    UserMessages ErrorOccur = new UserMessages();
                    //    ErrorOccur.SomethingWrong.Text = "Błędne dane!";
                    //    ErrorOccur.Show();
                    //}

                    //else
                    //{
                    //    string UserStoriesInquiry = $"select Imię,Nazwisko,Numer_Albumu,Frekwencja,Wynik,Nazwa,ROUND(AVG(CAST(Ocena as float)),2) from Uczniowie join OcenyKońcowe on Uczniowie.ID = OcenyKońcowe.ID_Ucznia join Frekwencja on Uczniowie.ID = Frekwencja.ID_Ucznia join Wyniki on Uczniowie.ID = Wyniki.ID_Ucznia join EGZAMINY on Wyniki.ID_Egzaminu = Egzaminy.ID  where Uczniowie.ID = {checkIsStudenExist}  group by Imię,Nazwisko,Numer_Albumu,Frekwencja,Wynik,Nazwa";

                    //    SqlCommand UserStoriesCommand = new SqlCommand(UserStoriesInquiry, MyConnect);
                    //    SqlDataReader readerUserStories = UserStoriesCommand.ExecuteReader();
                    //    string Name = "";
                    //    string SurName = "";
                    //    string AVG_User = "";
                    //    string Number_User = "";
                    //    string Freq_User = "";
                    //    string Results = "";


                    //    while (readerUserStories.Read())
                    //    {

                    //        IDataRecord dataReceordid = ((IDataRecord)readerUserStories);
                    //        Name = Convert.ToString(readerUserStories.GetValue(0));
                    //        SurName = Convert.ToString(readerUserStories.GetValue(1));
                    //        Number_User = Convert.ToString(readerUserStories.GetValue(2));
                    //        Freq_User = Convert.ToString(readerUserStories.GetValue(3));
                    //        AVG_User = Convert.ToString(readerUserStories.GetValue(6));
                    //        Results += Convert.ToString(String.Format("{0}: {1} \n", readerUserStories[5], readerUserStories[4]));
                    //    }
                    //    readerUserStories.Close();

                    //Name_UserStories.Text = Name;
                    //Surname_UserStories.Text = SurName;
                    //Number_UserStories.Text = Number_User;
                    //Freq_UserStories.Text = Freq_User;
                    //Results_UserStories.Text = Results;
                    //AVG_UserStories.Text = AVG_User;

                    //UserStoriesContent.Visibility = Visibility;
                }


            }
            catch (Exception)
            {
                UserMessages ErrorOccur = new UserMessages();
                ErrorOccur.SomethingWrong.Text = "Błędne dane!";
                ErrorOccur.Show();
            }
        }
    

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            Panel_Ocen.Visibility = Visibility.Hidden;
            HomePage.Visibility = Visibility.Hidden;
            UserStories.Visibility = Visibility;
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Timer_Click(object sender, EventArgs e)

        {

            DateTime d;

            d = DateTime.Now;

            label1.Content = d.Hour + " : " + d.Minute + " : " + d.Second;

        }

        private void Settings_Click(object sender, RoutedEventArgs e)

        {
            HomePage.Visibility = Visibility.Visible;
            UserStories.Visibility = Visibility.Hidden;
            Panel_Ocen.Visibility = Visibility.Hidden;
            System.Windows.Threading.DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer();
            Timer.Tick += new EventHandler(Timer_Click);
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();
        }

        private void ChangePasswordButton_Click(object sender, RoutedEventArgs e)
        {
            ChangePasswordWindow newchange = new ChangePasswordWindow();
            newchange.Show();
        }

        private void AddUSerButton_Click(object sender, RoutedEventArgs e)
        {
            AddUserWindow newWindow = new AddUserWindow();
            newWindow.Show();            
        }

        private void DeleteUSerButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteUserWindow deleteuser = new DeleteUserWindow();
            deleteuser.Show();

        }
    }

}
