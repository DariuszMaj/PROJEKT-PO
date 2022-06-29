﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolsMarks
{
    public class SchoolMarkInitializer : DropCreateDatabaseIfModelChanges<Model1>
    {




        protected override void Seed(Model1 context)
        {


            //DODAWANIE EGZMINÓW

            string[,] MyExamToFill = new string[12,3];
            string EgzaminyAdd = "1,Język polski podstawowy,Czesława Musiał,2,Język polski rozszerzony,Czesława Musiał,3,Język angielski podstawowy,Ireneusz Mączka,4,Język angielski rozszerzony,Ireneusz Mączka,5,Język niemiecki podstawowy,Łukasz Drozdowski,6,Język niemiecki rozszerzony,Łukasz Drozdowski,7,Biologia,Eliza Bernat,8,Chemia,Pamela Urbaniak,9,Fizyka,Marietta Pietruszka,10,Matematyka podstawowa,Kornel Rusin,11,Matematyka rozszerzona,Kornel Rusin,12,Geografia,Joanna Szymczak";
            string[] MydataExam = EgzaminyAdd.Split(',');
            int b = 0;
             for (int i=0;i<12;i++)
            {
                for (int a = 0; a < 3; a++)
                {
                    MyExamToFill[i, a] = MydataExam[b];
                    b++;
                }
            }
             for (int i = 0; i < 12; i++)
            {
                var Egzamin = new Egzaminy()
                {
                    ID = Convert.ToInt32(MyExamToFill[i,0]),
                    OpiekunEgzaminu = MyExamToFill[i, 1],
                    Nazwa = MyExamToFill[i,2]
                };
                context.Egzaminies.Add(Egzamin);
                base.Seed(context);
            }


            //DODAWANIE FREKWENCJI

            string MyFrequency = "1,1,27,2,2,81,3,3,54,4,4,25,5,5,46,6,6,67,7,7,55,8,8,92,9,9,8,10,10,56,11,11,15,12,12,38,13,13,20,14,14,12,15,15,8,16,16,31,17,17,68,18,18,91,19,19,18,20,20,15,21,21,9,22,22,99,23,23,61,24,24,83,25,25,2,26,26,30,27,27,81,28,28,72,29,29,8,30,30,45,31,31,52,32,32,52,33,33,63,34,34,72,35,35,49,36,36,54,37,37,77,38,38,86,39,39,8,40,40,37,41,41,25,42,42,47,43,43,40,44,44,18,45,45,35,46,46,27,47,47,58,48,48,89,49,49,13,50,50,59,51,51,43,52,52,32,53,53,49,54,54,75,55,55,80,56,56,45,57,57,34,58,58,55,59,59,26,60,60,94";
            string[] MyFrequencyData = MyFrequency.Split(',');
            string[,] MyFrequencyArray = new string[60, 3];
            int FreqCount = 0;
            for (int i = 0; i < 60; i++)
            {
                for (int a = 0; a < 3; a++)
                {
                    MyFrequencyArray[i, a] = MyFrequencyData[FreqCount];
                    FreqCount++;
                }
            }
            for (int i = 0; i < 60; i++)
            {
                var MyFrekwencja = new Frekwencja()
                {
                    ID = Convert.ToInt32(MyFrequencyArray[i, 0]),
                    ID_Ucznia = Convert.ToInt32(MyFrequencyArray[i, 1]),
                    Frekwencja1 = Convert.ToInt32(MyFrequencyArray[i, 2])

                };
                context.Frekwencjas.Add(MyFrekwencja);
                base.Seed(context);
            }



            //DODANIE KLAS

            string MyClasses ="1,3LO1,Kornel Rusin,2,3LO2,Bożena Frankowski,3,3LO3,Ireneusz Mączka,4,3LO4,Czesława Musiał,5,3LO5,Pamela Urbaniak,6,3LO6,Łukasz Drozdowski";
        string[] MyClassesData = MyClasses.Split(',');
        string[,] MyClassesArray = new string[6, 3];
        int MyClassCount = 0;

        for (int i=0;i<6;i++)
            {
                for (int a = 0; a < 3; a++)
                {
                    MyClassesArray[i, a] = MyClassesData[MyClassCount];
                    MyClassCount++;
                }
            }
        for (int i = 0; i < 6; i++)
            {
                var AddMyClasses = new Klasy()
                {
                    ID = Convert.ToInt32(MyClassesArray[i, 0]),
                    Nazwa = MyClassesArray[i, 1],
                    Opiekun=MyClassesArray[i,2]
                   

                };
                context.Klasies.Add(AddMyClasses);
                base.Seed(context);
            }

        //DODAWANIE NAGRÓD
        
        string Nagrody= "5,Ksiązka,1,Laptop,4,Słuchawki,3,Smartphone,2,Tablet";
        string[] NagrodyData = Nagrody.Split(',');
        string[,] NagrodyArray = new string[5, 3];
        int NagrodyDataCount=0;
            for (int i = 0; i < 5; i++)
            {
                for (int a = 0; a < 2; a++)
                {
                    NagrodyArray[i, a] = NagrodyData[NagrodyDataCount];
                    NagrodyDataCount++;
                }
            }
            for (int i = 0; i < 5; i++)
            {
                var NagrodyAdd = new Nagrody()
                {
                    ID = Convert.ToInt32(NagrodyArray[i, 0]),
                    Nazwa = NagrodyArray[i, 1]
                    
                };
                context.Nagrodies.Add(NagrodyAdd);
                base.Seed(context);
            }
            

            //DODAWANIE HASŁA
            var AddPassword = new Password()
            {
                ID = 1,
                Imie = "Dariusz",
                Nazwisko = "Maj",
                Password1 = "1234",
                Login="DariuszMaj"
                
            };
            context.Passwords.Add(AddPassword);
            base.Seed(context);

            string Subject = "1,Język polski,Czesława Musiał,2,Język angielski,Ireneusz Mączka,3,Język niemiecki,Łukasz Drozdowski,4,Biologia,Eliza Bernat,5,Chemia,Pamela Urbaniak,6,Fizyka,Marietta Pietruszka,7,Informatyka,Ida Urban,8,Matematyka,Kornel Rusin,9,WF,Adriana Daniel,10,Religia,Bożena Frankowski,11,Geografia,Joanna Szymczak";
            string[] SubjectData = Subject.Split(',');
            string[,] SubjectArray = new string[11, 3];
            int SubjectCount = 0;
            
            for (int i = 0; i < 11; i++)
            {
                for (int a = 0; a < 3; a++)
                {
                    SubjectArray[i, a] = SubjectData[SubjectCount];
                    SubjectCount++;
                }
            }
            for (int i = 0; i < 11; i++)
            {
                var MySubject = new Przedmioty()
                {
                    ID = Convert.ToInt32(SubjectArray[i, 0]),
                    Nazwa = SubjectArray[i, 1],
                    Nauczyciel=SubjectArray[i,2]
                };
                context.Przedmioties.Add(MySubject);
                base.Seed(context);
            }

            var AddChairMan = new Samorząd()
            {
                ID = 1,
                ID_Ucznia=36,
                Stanowisko="Przewodniczący"
            };
            context.Samorząd.Add(AddChairMan);
            base.Seed(context);
            var AddChairMan2 = new Samorząd()
            {
                ID = 2,
                ID_Ucznia = 42,
                Stanowisko = "Zastępca Przewodniczącego"
            };
            context.Samorząd.Add(AddChairMan2);
            base.Seed(context);

            var AddChairMan3 = new Samorząd()
            {
                ID = 3,
                ID_Ucznia = 55,
                Stanowisko = "Skarbink"
            };
            context.Samorząd.Add(AddChairMan3);
            base.Seed(context);




            string AddStudents = "1, 3, Ildefons, Gołąb, 515	,2, 2, Krystiana, Grygiel, 516	,3, 2, Aldona, Adamczak, 517	,4, 6, Afra, Michalak, 518	,5, 4, Kazimiera, Dominiak, 519	,6, 4, Przemysław, Adamek, 520	,7, 5, Miłomir, Łukasik, 521	,8, 1, Dąbrówka, Sobczyński, 522	,9, 6, Radomiła, Adamiec, 523	,10, 5, Cezaria, Łapiński, 524	,11, 2, Gustawa, Banaszak, 525	,12, 4, Joanna, Lewandowski, 526	,13, 1, Przybysława, Drożdż, 527	,14, 6, Tomiła, Sikorski, 528	,15, 5, Wilma, Tomasik, 529	,16, 3, Antoni, Szpak, 530	,17, 5, Katarzyna, Marciniak, 531	,18, 3, Bartłomieja, Żuchowski, 532	,19, 2, Zyta, Dębowski, 533	,20, 6, Hugo, Zieliński, 534	,21, 3, Rodzisława, Kaczmarczyk, 535	,22, 1, Józefa, Kotowski, 536	,23, 6, Maria, Zalewski, 537	,24, 4, Olga, Partyka, 538	,25, 2, Salomea, Kawka, 539	,26, 2, Donata, Laskowski, 540	,27, 6, Adelard, Kasprzyk, 541	,28, 6, Agrypina, Chudy, 542	,29, 3, Miłosława, Karaś, 543	,30, 6, Ilia, Szczepanek, 544	,31, 3, Natalia, Skowronek, 545	,32, 4, Zofia, Urbańczyk, 546	,33, 1, Krystiana, Głogowski, 547	,34, 4, Ana, Szulc, 548	,35, 5, Eryka, Zagórski, 549	,36, 5, Odeta, Strzelczyk, 550	,37, 1, Pelagia, Rosiak, 551	,38, 6, Jasława, Adamowicz, 552	,39, 4, Symeo, Kotowski, 553	,40, 2, Samanta, Czapski, 554	,41, 4, Nora, Dąbrowski, 555	,42, 4, Sławomir, Niemczyk, 556	,43, 3, Elwira, Banasiak, 557	,44, 2, Lucjola, Lewandowski, 558	,45, 3, Żelisława, Cieśla, 559	,46, 3, Tytus, Bochenek, 560	,47, 2, Selena, Jezierski, 561	,48, 6, Lidia, Adamek, 562	,49, 2, Marietta, Grzybowski, 563	,50, 3, Agata, Bożek, 564	,51, 3, Krystiana, Konieczna, 565	,52, 4, Kasandra, Skrzypczak, 566	,53, 5, Czesław, Marczewski, 567	,54, 4, Beata, Chmura, 568	,55, 5, Noemi, Drzewiecki, 569	,56, 2, Kazimiera, Dutkiewicz, 570	,57, 2, Ewaryst, Karaś, 571	,58, 1, Aida, Tokarski, 572	,59, 4, Ezechiel, Klimaszewski, 573	,60, 6, Ola, Niemiec, 574";
            string[] AddStudentsData = AddStudents.Split(',');
            string[,] AddStudentsArray = new string[60, 5];
            int AddStudentsCount = 0;
            for (int i = 0; i < 60; i++)
            {
                for (int a = 0; a < 5; a++)
                {
                    AddStudentsArray[i, a] = AddStudentsData[AddStudentsCount];
                    AddStudentsCount++;
                }
            }
            for (int i = 0; i < 60; i++)
            {
                var MyStudent = new Uczniowie()
                {
                    ID = Convert.ToInt32(AddStudentsArray[i, 0]),
                    ID_Klasy= Convert.ToInt32(AddStudentsArray[i, 1]),
                    Imię= AddStudentsArray[i,2],
                    Nazwisko= AddStudentsArray[i, 3],
                    Numer_Albumu= Convert.ToInt32(AddStudentsArray[i, 4]),
                };
                context.Uczniowies.Add(MyStudent);
                base.Seed(context);

            }

            //DODAJE WYNIKI
            string wyniki = "1, 1, 5, 33 	,2, 2, 5, 30 	,3, 3, 5, 0 	,4, 4, 5, 6 	,5, 5, 5, 62 	,6, 6, 5, 56 	,7, 7, 5, 61 	,8, 8, 5, 66 	,9, 9, 5, 10 	,10, 10, 5, 30 	,11, 11, 5, 21 	,12, 12, 5, 81 	,13, 13, 5, 92 	,14, 14, 5, 82 	,15, 15, 5, 70 	,16, 16, 5, 58 	,17, 17, 5, 72 	,18, 18, 5, 19 	,19, 19, 5, 63 	,20, 20, 5, 88 	,21, 21, 5, 36 	,22, 22, 5, 24 	,23, 23, 5, 52 	,24, 24, 5, 70 	,25, 25, 5, 71 	,26, 26, 5, 74 	,27, 27, 5, 86 	,28, 28, 5, 39 	,29, 29, 5, 77 	,30, 30, 5, 77 	,31, 31, 5, 36 	,32, 32, 5, 73 	,33, 33, 5, 88 	,34, 34, 5, 24 	,35, 35, 5, 92 	,36, 36, 5, 18 	,37, 37, 6, 62 	,38, 38, 6, 86 	,39, 39, 6, 86 	,40, 40, 6, 19 	,41, 41, 6, 34 	,42, 42, 6, 29 	,43, 43, 6, 68 	,44, 44, 6, 49 	,45, 45, 6, 91 	,46, 46, 6, 77 	,47, 47, 6, 44 	,48, 48, 6, 20 	,49, 49, 6, 60 	,50, 50, 6, 66 	,51, 51, 6, 91 	,52, 52, 7, 33 	,53, 53, 7, 3 	,54, 54, 7, 18 	,55, 55, 7, 41 	,56, 56, 7, 54 	,57, 57, 7, 28 	,58, 58, 7, 18 	,59, 59, 7, 28 	,60, 60, 7, 49 	,61, 1, 7, 27 	,62, 2, 7, 35 	,63, 3, 7, 37 	,64, 4, 7, 60 	,65, 5, 7, 37 	,66, 6, 7, 46 	,67, 7, 7, 90 	,68, 8, 7, 89 	,69, 9, 7, 66 	,70, 10, 7, 87 	,71, 11, 7, 86 	,72, 12, 7, 99 	,73, 13, 7, 64 	,74, 14, 7, 93 	,75, 15, 7, 28 	,76, 16, 7, 3 	,77, 17, 7, 27 	,78, 18, 7, 4 	,79, 19, 7, 63 	,80, 20, 7, 26 	,81, 21, 7, 21 	,82, 22, 7, 29 	,83, 23, 7, 99 	,84, 24, 7, 60 	,85, 25, 7, 59 	,86, 26, 7, 27 	,87, 27, 7, 99 	,88, 28, 7, 66 	,89, 29, 7, 55 	,90, 30, 7, 6 	,91, 31, 7, 73 	,92, 32, 7, 49 	,93, 33, 7, 8 	,94, 34, 7, 42 	,95, 35, 7, 94 	,96, 36, 7, 49 	,97, 37, 7, 31 	,98, 38, 7, 40 	,99, 39, 7, 91 	,100, 40, 7, 48 	,101, 41, 7, 34 	,102, 42, 7, 43 	,103, 43, 7, 92 	,104, 44, 7, 56 	,105, 45, 7, 67 	,106, 46, 7, 88 	,107, 47, 7, 21 	,108, 48, 7, 57 	,109, 49, 7, 12 	,110, 50, 7, 37 	,111, 51, 7, 76 	,112, 52, 7, 1 	,113, 53, 7, 92 	,114, 1, 8, 63 	,115, 2, 8, 32 	,116, 3, 8, 55 	,117, 4, 8, 26 	,118, 5, 8, 87 	,119, 6, 8, 91 	,120, 7, 8, 48 	,121, 8, 8, 39 	,122, 9, 8, 72 	,123, 10, 8, 78 	,124, 11, 8, 1 	,125, 12, 8, 68 	,126, 13, 8, 27 	,127, 14, 8, 2 	,128, 15, 8, 59 	,129, 16, 8, 24 	,130, 17, 8, 74 	,131, 18, 8, 3 	,132, 19, 8, 69 	,133, 20, 8, 12 	,134, 21, 8, 89 	,135, 22, 8, 15 	,136, 23, 8, 96 	,137, 24, 8, 19 	,138, 25, 8, 2 	,139, 26, 8, 66 	,140, 27, 8, 17 	,141, 28, 8, 55 	,142, 29, 8, 33 	,143, 30, 8, 95 	,144, 31, 8, 19 	,145, 32, 8, 51 	,146, 33, 8, 8 	,147, 34, 8, 1 	,148, 35, 8, 69 	,149, 36, 8, 38 	,150, 37, 8, 29 	,151, 38, 8, 85 	,152, 39, 8, 49 	,153, 40, 8, 86 	,154, 41, 8, 78 	,155, 42, 8, 18 	,156, 43, 8, 88 	,157, 44, 8, 19 	,158, 45, 8, 33 	,159, 46, 8, 60 	,160, 47, 8, 80 	,161, 48, 8, 32 	,162, 49, 8, 31 	,163, 50, 8, 3 	,164, 51, 8, 92 	,165, 52, 8, 4 	,166, 53, 8, 54 	,167, 54, 8, 97 	,168, 55, 8, 33 	,169, 56, 8, 26 	,170, 57, 8, 42 	,171, 58, 8, 78 	,172, 59, 8, 59 	,173, 60, 8, 60 	,174, 1, 9, 42 	,175, 2, 9, 29 	,176, 3, 9, 61 	,177, 4, 9, 56 	,178, 5, 9, 24 	,179, 6, 9, 60 	,180, 7, 9, 43 	,181, 8, 9, 71 	,182, 9, 9, 40 	,183, 10, 9, 19 	,184, 11, 9, 4 	,185, 12, 9, 23 	,186, 13, 9, 3 	,187, 14, 9, 79 	,188, 15, 9, 71 	,189, 16, 9, 54 	,190, 17, 9, 40 	,191, 18, 9, 68 	,192, 19, 9, 83 	,193, 20, 9, 65 	,194, 21, 9, 80 	,195, 22, 9, 61 	,196, 23, 9, 1 	,197, 24, 9, 22 	,198, 25, 9, 77 	,199, 26, 9, 54 	,200, 27, 9, 1 	,201, 28, 9, 53 	,202, 29, 9, 43 	,203, 30, 9, 78 	,204, 31, 9, 36 	,205, 32, 9, 31 	,206, 33, 9, 1 	,207, 34, 9, 68 	,208, 35, 9, 50 	,209, 36, 9, 30 	,210, 37, 9, 2 	,211, 1, 12, 96 	,212, 2, 12, 88 	,213, 3, 12, 37 	,214, 4, 12, 97 	,215, 5, 12, 15 	,216, 6, 12, 87 	,217, 7, 12, 81 	,218, 8, 12, 66 	,219, 9, 12, 19 	,220, 10, 12, 44 	,221, 11, 12, 32 	,222, 12, 12, 66 	,223, 13, 12, 80 	,224, 14, 12, 64 	,225, 15, 12, 60 	,226, 16, 12, 64 	,227, 17, 12, 95 	,228, 18, 12, 93 	,229, 19, 12, 36 	,230, 20, 12, 95 	,231, 21, 12, 14 	,232, 22, 12, 71 	,233, 23, 12, 25 	,234, 24, 12, 91 	,235, 25, 12, 20 	,236, 26, 12, 93 	,237, 27, 12, 87 	,238, 28, 12, 42 	,239, 1, 11, 36 	,240, 2, 11, 46 	,241, 3, 11, 41 	,242, 4, 11, 29 	,243, 5, 11, 7 	,244, 6, 11, 69 	,245, 7, 11, 54 	,246, 8, 11, 81 	,247, 9, 11, 31 	,248, 10, 11, 23 	,249, 11, 11, 5 	,250, 12, 11, 72 	,251, 13, 11, 44 	,252, 14, 11, 49 	,253, 15, 11, 64 	,254, 16, 11, 26 	,255, 17, 11, 24 	,256, 18, 11, 36 	,257, 19, 11, 91 	,258, 20, 11, 26 	,259, 21, 11, 94 	,260, 22, 11, 64 	,261, 23, 11, 43 	,262, 24, 11, 84 	,263, 25, 11, 95 	,264, 26, 11, 31 	,265, 27, 11, 2 	,266, 28, 11, 82 	,267, 29, 11, 76 	,268, 30, 11, 35 	,269, 31, 11, 3 	,270, 32, 11, 99 	,271, 33, 11, 7 	,272, 34, 11, 48 	,273, 35, 11, 77 	,274, 36, 11, 28 	,275, 37, 11, 92 	,276, 38, 11, 31 	,277, 39, 11, 27 	,278, 40, 11, 66 	,279, 41, 11, 24 	,280, 42, 11, 80 	,281, 43, 11, 16 	,282, 44, 11, 36 	,283, 45, 11, 84 	,284, 46, 11, 61 	,285, 47, 11, 78 	,286, 48, 11, 79 	,287, 49, 11, 5 	,288, 50, 11, 0 	,289, 51, 11, 48 	,290, 52, 11, 96 	,291, 53, 11, 97 	,292, 54, 11, 41 	,293, 55, 11, 70 	,294, 56, 11, 30 	,295, 57, 11, 51 	,296, 58, 11, 28 	,297, 59, 11, 36 	,298, 60, 11, 6 "; 
            string[] WynikiData = wyniki.Trim().Split(',');
            string[,] WynikiArray = new string[298, 4];
            int WynikiCount = 0;
            for (int i = 0; i < 298; i++)
            {
                for (int a = 0; a < 4; a++)
                {
                    WynikiArray[i, a] = WynikiData[WynikiCount];
                    WynikiCount++;

                }

            }

            for (int i = 0; i < 298; i++)
            {
                var MyResults = new Wyniki()
                {
                    ID = Convert.ToInt32(WynikiArray[i, 0]),
                    ID_Ucznia = Convert.ToInt32(WynikiArray[i, 1]),
                    ID_Egzaminu = Convert.ToInt32(WynikiArray[i, 2]),
                    Wynik = Convert.ToInt32(WynikiArray[i, 3])
                    
                };
                context.Wynikis.Add(MyResults);
                base.Seed(context);
            }


            // DODAWANIE OCEN

            string MyMarks = "1,1,1,2,2,2,1,2,3,3,1,5,4,4,1,6,5,5,1,3,6,6,1,3,7,7,1,3,8,8,1,1,9,9,1,3,10,10,1,4,11,11,1,6,12,12,1,2,13,13,1,3,14,14,1,5,15,15,1,6,16,16,1,5,17,17,1,4,18,18,1,5,19,19,1,6,20,20,1,6,21,21,1,4,22,22,1,4,23,23,1,4,24,24,1,4,25,25,1,5,26,26,1,6,27,27,1,2,28,28,1,3,29,29,1,4,30,30,1,6,31,31,1,2,32,32,1,6,33,33,1,4,34,34,1,2,35,35,1,3,36,36,1,3,37,37,1,6,38,38,1,3,39,39,1,4,40,40,1,4,41,41,1,6,42,42,1,4,43,43,1,4,44,44,1,5,45,45,1,2,46,46,1,5,47,47,1,4,48,48,1,3,49,49,1,3,50,50,1,4,51,51,1,5,52,52,1,5,53,53,1,2,54,54,1,6,55,55,1,3,56,56,1,5,57,57,1,3,58,58,1,3,59,59,1,6,60,60,1,6,61,1,2,5,62,2,2,6,63,3,2,3,64,4,2,6,65,5,2,4,66,6,2,3,67,7,2,4,68,8,2,2,69,9,2,5,70,10,2,3,71,11,2,3,72,12,2,5,73,13,2,4,74,14,2,5,75,15,2,6,76,16,2,4,77,17,2,6,78,18,2,2,79,19,2,3,80,20,2,5,81,21,2,3,82,22,2,6,83,23,2,2,84,24,2,4,85,25,2,3,86,26,2,5,87,27,2,4,88,28,2,2,89,29,2,2,90,30,2,6,91,31,2,4,92,32,2,5,93,33,2,3,94,34,2,3,95,35,2,2,96,36,2,3,97,37,2,5,98,38,2,2,99,39,2,6,100,40,2,4,101,41,2,3,102,42,2,4,103,43,2,3,104,44,2,3,105,45,2,4,106,46,2,6,107,47,2,3,108,48,2,6,109,49,2,6,110,50,2,3,111,51,2,2,112,52,2,2,113,53,2,2,114,54,2,3,115,55,2,2,116,56,2,6,117,57,2,5,118,58,2,3,119,59,2,4,120,60,2,6,121,1,3,3,122,2,3,2,123,3,3,3,124,4,3,5,125,5,3,6,126,6,3,3,127,7,3,2,128,8,3,3,129,9,3,2,130,10,3,3,131,11,3,3,132,12,3,2,133,13,3,6,134,14,3,5,135,15,3,2,136,16,3,4,137,17,3,5,138,18,3,3,139,19,3,3,140,20,3,2,141,21,3,4,142,22,3,3,143,23,3,5,144,24,3,3,145,25,3,6,146,26,3,6,147,27,3,6,148,28,3,4,149,29,3,3,150,30,3,4,151,31,3,3,152,32,3,6,153,33,3,3,154,34,3,2,155,35,3,6,156,36,3,3,157,37,3,3,158,38,3,2,159,39,3,3,160,40,3,4,161,41,3,5,162,42,3,4,163,43,3,5,164,44,3,4,165,45,3,3,166,46,3,4,167,47,3,4,168,48,3,2,169,49,3,4,170,50,3,4,171,51,3,4,172,52,3,3,173,53,3,3,174,54,3,4,175,55,3,6,176,56,3,5,177,57,3,4,178,58,3,6,179,59,3,2,180,60,3,4,181,1,4,6,182,2,4,2,183,3,4,2,184,4,4,6,185,5,4,2,186,6,4,5,187,7,4,4,188,8,4,3,189,9,4,6,190,10,4,3,191,11,4,3,192,12,4,4,193,13,4,6,194,14,4,6,195,15,4,5,196,16,4,6,197,17,4,2,198,18,4,3,199,19,4,2,200,20,4,4,201,21,4,6,202,22,4,3,203,23,4,2,204,24,4,6,205,25,4,2,206,26,4,4,207,27,4,4,208,28,4,6,209,29,4,6,210,30,4,3,211,31,4,6,212,32,4,4,213,33,4,4,214,34,4,6,215,35,4,3,216,36,4,5,217,37,4,5,218,38,4,2,219,39,4,5,220,40,4,5,221,41,4,2,222,42,4,4,223,43,4,5,224,44,4,6,225,45,4,5,226,46,4,4,227,47,4,2,228,48,4,2,229,49,4,4,230,50,4,5,231,51,4,6,232,52,4,5,233,53,4,6,234,54,4,2,235,55,4,4,236,56,4,6,237,57,4,2,238,58,4,5,239,59,4,6,240,60,4,5,241,1,5,4,242,2,5,6,243,3,5,6,244,4,5,6,245,5,5,2,246,6,5,6,247,7,5,4,248,8,5,3,249,9,5,4,250,10,5,6,251,11,5,2,252,12,5,5,253,13,5,6,254,14,5,6,255,15,5,5,256,16,5,4,257,17,5,3,258,18,5,3,259,19,5,2,260,20,5,4,261,21,5,3,262,22,5,2,263,23,5,6,264,24,5,2,265,25,5,2,266,26,5,5,267,27,5,2,268,28,5,6,269,29,5,3,270,30,5,6,271,31,5,3,272,32,5,6,273,33,5,3,274,34,5,4,275,35,5,3,276,36,5,2,277,37,5,5,278,38,5,5,279,39,5,6,280,40,5,5,281,41,5,6,282,42,5,4,283,43,5,3,284,44,5,2,285,45,5,2,286,46,5,5,287,47,5,5,288,48,5,5,289,49,5,2,290,50,5,4,291,51,5,6,292,52,5,3,293,53,5,3,294,54,5,3,295,55,5,6,296,56,5,4,297,57,5,6,298,58,5,3,299,59,5,3,300,60,5,5,301,1,6,6,302,2,6,4,303,3,6,5,304,4,6,2,305,5,6,3,306,6,6,3,307,7,6,2,308,8,6,3,309,9,6,2,310,10,6,5,311,11,6,2,312,12,6,2,313,13,6,2,314,14,6,5,315,15,6,4,316,16,6,4,317,17,6,4,318,18,6,4,319,19,6,2,320,20,6,4,321,21,6,2,322,22,6,4,323,23,6,6,324,24,6,4,325,25,6,3,326,26,6,5,327,27,6,2,328,28,6,4,329,29,6,6,330,30,6,3,331,31,6,2,332,32,6,5,333,33,6,2,334,34,6,6,335,35,6,6,336,36,6,2,337,37,6,3,338,38,6,3,339,39,6,2,340,40,6,3,341,41,6,5,342,42,6,6,343,43,6,6,344,44,6,3,345,45,6,5,346,46,6,2,347,47,6,5,348,48,6,2,349,49,6,2,350,50,6,3,351,51,6,4,352,52,6,6,353,53,6,4,354,54,6,4,355,55,6,2,356,56,6,4,357,57,6,5,358,58,6,4,359,59,6,3,360,60,6,5,361,1,7,1,362,2,7,3,363,3,7,1,364,4,7,3,365,5,7,6,366,6,7,2,367,7,7,1,368,8,7,5,369,9,7,1,370,10,7,5,371,11,7,1,372,12,7,4,373,13,7,1,374,14,7,2,375,15,7,1,376,16,7,3,377,17,7,4,378,18,7,5,379,19,7,2,380,20,7,6,381,21,7,2,382,22,7,4,383,23,7,4,384,24,7,1,385,25,7,6,386,26,7,4,387,27,7,6,388,28,7,1,389,29,7,1,390,30,7,1,391,31,7,4,392,32,7,1,393,33,7,3,394,34,7,3,395,35,7,1,396,36,7,1,397,37,7,1,398,38,7,4,399,39,7,2,400,40,7,1,401,41,7,3,402,42,7,2,403,43,7,1,404,44,7,3,405,45,7,5,406,46,7,6,407,47,7,4,408,48,7,1,409,49,7,5,410,50,7,4,411,51,7,4,412,52,7,2,413,53,7,3,414,54,7,5,415,55,7,3,416,56,7,6,417,57,7,4,418,58,7,2,419,59,7,2,420,60,7,4,421,1,8,6,422,2,8,5,423,3,8,2,424,4,8,4,425,5,8,2,426,6,8,5,427,7,8,5,428,8,8,4,429,9,8,2,430,10,8,4,431,11,8,3,432,12,8,5,433,13,8,4,434,14,8,6,435,15,8,6,436,16,8,6,437,17,8,4,438,18,8,3,439,19,8,3,440,20,8,4,441,21,8,6,442,22,8,2,443,23,8,6,444,24,8,6,445,25,8,4,446,26,8,4,447,27,8,2,448,28,8,4,449,29,8,3,450,30,8,4,451,31,8,6,452,32,8,2,453,33,8,4,454,34,8,4,455,35,8,4,456,36,8,4,457,37,8,6,458,38,8,3,459,39,8,4,460,40,8,3,461,41,8,3,462,42,8,2,463,43,8,3,464,44,8,6,465,45,8,3,466,46,8,2,467,47,8,4,468,48,8,3,469,49,8,3,470,50,8,6,471,51,8,4,472,52,8,5,473,53,8,6,474,54,8,4,475,55,8,3,476,56,8,4,477,57,8,4,478,58,8,6,479,59,8,2,480,60,8,4,481,1,9,3,482,2,9,5,483,3,9,6,484,4,9,3,485,5,9,3,486,6,9,2,487,7,9,4,488,8,9,4,489,9,9,3,490,10,9,2,491,11,9,4,492,12,9,2,493,13,9,5,494,14,9,4,495,15,9,4,496,16,9,5,497,17,9,6,498,18,9,5,499,19,9,4,500,20,9,5,501,21,9,3,502,22,9,4,503,23,9,2,504,24,9,2,505,25,9,6,506,26,9,4,507,27,9,5,508,28,9,3,509,29,9,3,510,30,9,2,511,31,9,2,512,32,9,2,513,33,9,5,514,34,9,5,515,35,9,5,516,36,9,5,517,37,9,3,518,38,9,3,519,39,9,4,520,40,9,4,521,41,9,5,522,42,9,4,523,43,9,2,524,44,9,4,525,45,9,5,526,46,9,4,527,47,9,2,528,48,9,2,529,49,9,4,530,50,9,6,531,51,9,4,532,52,9,4,533,53,9,2,534,54,9,5,535,55,9,3,536,56,9,2,537,57,9,2,538,58,9,5,539,59,9,2,540,60,9,4,541,1,10,2,542,2,10,3,543,3,10,3,544,4,10,3,545,5,10,6,546,6,10,3,547,7,10,6,548,8,10,2,549,9,10,5,550,10,10,6,551,11,10,6,552,12,10,4,553,13,10,3,554,14,10,2,555,15,10,2,556,16,10,5,557,17,10,2,558,18,10,4,559,19,10,3,560,20,10,6,561,21,10,5,562,22,10,4,563,23,10,5,564,24,10,5,565,25,10,6,566,26,10,4,567,27,10,2,568,28,10,2,569,29,10,3,570,30,10,3,571,31,10,2,572,32,10,4,573,33,10,5,574,34,10,3,575,35,10,2,576,36,10,5,577,37,10,4,578,38,10,6,579,39,10,6,580,40,10,6,581,41,10,3,582,42,10,4,583,43,10,6,584,44,10,2,585,45,10,4,586,46,10,4,587,47,10,4,588,48,10,2,589,49,10,4,590,50,10,3,591,51,10,2,592,52,10,5,593,53,10,5,594,54,10,2,595,55,10,4,596,56,10,5,597,57,10,3,598,58,10,4,599,59,10,2,600,60,10,4,601,1,11,4,602,2,11,6,603,3,11,4,604,4,11,6,605,5,11,4,606,6,11,5,607,7,11,2,608,8,11,2,609,9,11,5,610,10,11,2,611,11,11,2,612,12,11,3,613,13,11,4,614,14,11,4,615,15,11,3,616,16,11,2,617,17,11,5,618,18,11,6,619,19,11,5,620,20,11,2,621,21,11,2,622,22,11,4,623,23,11,4,624,24,11,5,625,25,11,6,626,26,11,4,627,27,11,3,628,28,11,6,629,29,11,4,630,30,11,2,631,31,11,2,632,32,11,5,633,33,11,3,634,34,11,2,635,35,11,2,636,36,11,3,637,37,11,3,638,38,11,2,639,39,11,2,640,40,11,6,641,41,11,2,642,42,11,2,643,43,11,6,644,44,11,6,645,45,11,5,646,46,11,3,647,47,11,6,648,48,11,4,649,49,11,4,650,50,11,3,651,51,11,4,652,52,11,5,653,53,11,5,654,54,11,2,655,55,11,4,656,56,11,2,657,57,11,2,658,58,11,3,659,59,11,6,660,60,11,6";

            string[] MyMarksData = MyMarks.Split(',');
            string[,] MyMarksArray = new string[660, 4];
            int MyMarksCount = 0;
            for (int i = 0; i < 660; i++)
            {
                for (int a = 0; a < 4; a++)
                {
                    MyMarksArray[i, a] = MyMarksData[MyMarksCount];
                    MyMarksCount++;
                }
            }

            for (int i = 0; i < 660; i++)
            {
                var MarksAdd = new OcenyKońcowe()
                {
                    ID = Convert.ToInt32(MyMarksArray[i, 0]),
                    ID_Ucznia = Convert.ToInt32(MyMarksArray[i, 1]),
                    ID_Przedmiotu = Convert.ToInt32(MyMarksArray[i, 2]),
                    Ocena = Convert.ToInt32(MyMarksArray[i, 3])

                };
                context.OcenyKońcowe.Add(MarksAdd);
                base.Seed(context);
            }




        }

    }
}