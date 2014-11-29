using UITournament.CSharpCode;
using UITournament.CSharpCode.FactoryMethod;
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


namespace UITournament
{
    public partial class MainWindow : Window
    {
        public Tournament tours;
        public static bool isFirstStart = true;
        protected List<Athlete> atlets;
        protected List<Trainer> trainers;
        protected List<Tournament> tournaments;
        protected int athleteSelected;

        //public Make theme = new MakeDarkTheme();
        public MainWindow()
        {
            InitializeComponent();


            //var addTheme = theme.MakeTheme();
            //string backgrounColour = addTheme.BackgrounColour;
            //string fontColour = addTheme.FontColour;
            

            atlets = new List<Athlete>();
            tournaments = new List<Tournament>();
            trainers =  new List<Trainer>();
            List<Athlete> tmp = (List<Athlete>)SaveReadToFile.Deserialize(@"..\..\atleti.bin");
            List<Tournament> tmpTour = (List<Tournament>)SaveReadToFile.Deserialize(@"..\..\tournaments.bin");
            List<Trainer> tmpTrainers = (List<Trainer>)SaveReadToFile.Deserialize(@"..\..\trainers.bin");

            if (tmp != null)
            {
                atlets = (List<Athlete>)SaveReadToFile.Deserialize(@"..\..\atleti.bin");

            }
            if (tmpTour != null)
            {
                tournaments = (List<Tournament>)SaveReadToFile.Deserialize(@"..\..\tournaments.bin");
            }
            if (tmpTrainers != null)
            {
                trainers = (List<Trainer>)SaveReadToFile.Deserialize(@"..\..\trainers.bin");
            }

            for (int i = 0; i < atlets.Count(); i++)
            {
                listViewAthlete.Items.Add(atlets[i]);
            }
            for (int i = 0; i < tournaments.Count(); i++)
            {
                listView1.Items.Add(tournaments[i]);
            }
            for (int i = 0; i < trainers.Count(); i++)
            {
                listViewTrainer.Items.Add(trainers[i]);
            }

            if (isFirstStart == true)
            {
                isFirstStart = false;

                ShowData();
            }
        }


        #region FirstTabItem

        private void Create_Tournament(object sender, RoutedEventArgs e)
        {
            Tournament.IsSelected = true;
        }
        private void Create_Athlete(object sender, RoutedEventArgs e)
        {
            Player.IsSelected = true;
        }
        private void Create_Trainer(object sender, RoutedEventArgs e)
        {
            Trainer.IsSelected = true;
        }
        private void Open_Tournament(object sender, RoutedEventArgs e)
        {
            EditTournament ed = new EditTournament();
            ed.Show();
        }
        public void Black(object sender, RoutedEventArgs e)
        {
            Make theme = new MakeDarkTheme();
            makeColor(theme);
        }
        private void White(object sender, RoutedEventArgs e)
        {
            Make theme = new MakeWhiteTheme();
            makeColor(theme);
        }
        private void Green(object sender, RoutedEventArgs e)
        {
            Make theme = new MakeBlueTheme();
            makeColor(theme);
        }

        public void makeColor(Make theme)
        {   
            var addTheme = theme.MakeTheme();
            var converter = new System.Windows.Media.BrushConverter();
            var backgrounColour = (Brush)converter.ConvertFromString(addTheme.BackgrounColour);
            var fontColour = (Brush)converter.ConvertFromString(addTheme.FontColour);
           
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! smenq cwetowete ....  raboti :)
            this.Background = backgrounColour;
            this.Foreground = fontColour;
            TabcontrolGeneral.Foreground = fontColour;
            
        }
        #endregion

        #region Second Tab Item Create Tournament
        private void ShowData()
        {
            // SaveReadToFile.Deserialize(tourss);
            //MyData md = new MyData();
            //foreach (var item in md.Load())
            //{
            //    listView1.Items.Add(item);
            //}
        }
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            tours = new Tournament(nameTournament.Text, nameTown.Text, DateTimeParsing.DateTimeParse(startDate.Text), DateTimeParsing.DateTimeParse(endDate.Text));

            tournaments.Add(tours);
            listView1.Items.Add(tours);

            //RefreshListView();
        }
        private void removeButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveCurrentContent();
            //MessageBox.ShowInformation(String.Format("The schedule has been successfully saved!", titleTextBox.Text));
            //ShowData();    
        }
        private void SaveCurrentContent()
        {
            //MyData md = new MyData();
            //md.Save(listView1.Items);
            ////SaveReadToFile.Serialize(listView1.Items);
            SaveReadToFile.Serialize(tournaments, @"..\..\tournaments.bin");
        }
        private void openButton_Click(object sender, RoutedEventArgs e)
        {
            Tournament operatedNode = (Tournament)listView1.SelectedItem; //new ListViewClass(value1, value2);
            EditTournament ed = new EditTournament(operatedNode.TournamentName, operatedNode.Town, operatedNode.StartDate, operatedNode.EndDate);
            ed.Show();
        }
        private void RefreshListView(string value1, string value2, DateTime value3, DateTime value4)
        {
            Tournament operatedNode = (Tournament)listView1.SelectedItem; //new ListViewClass(value1, value2);

            if (operatedNode != null) // && !stopRefreshControls
            {
                //setDataChanged(true);

                operatedNode.TournamentName = value1;
                operatedNode.Town = value2;
                operatedNode.StartDate = value3;
                operatedNode.EndDate = value4;
                listView1.Items.Refresh();
            }
        }
        void results_Click(object sender, RoutedEventArgs e)
        {
            //GridViewColumnHeader headerClicked = e.OriginalSource as GridViewColumnHeader;
            //ListSortDirection direction;

            //if (headerClicked != null)
            //{
            //    if (headerClicked != _lastHeaderClicked)
            //    {
            //        direction = ListSortDirection.Ascending;
            //    }

            //    else
            //    {
            //        if (_lastDirection == ListSortDirection.Ascending)
            //        {
            //            direction = ListSortDirection.Descending;
            //        }
            //        else
            //        {
            //            direction = ListSortDirection.Ascending;
            //        }
            //    }
            //    string header = headerClicked.Column.Header as string;
            //    Sort(header, direction);
            //    _lastHeaderClicked = headerClicked;
            //    _lastDirection = direction;
        }
        private void listView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //StringNode operatedNode = (StringNode)listView1.SelectedItem;
            //if (operatedNode != null)
            //{
            //    stopRefreshControls = true;
            //    dateTextBox.Text = operatedNode.Date;
            //    titleTextBox.Text = operatedNode.Title;
            //    descriptionTextBox.Text = operatedNode.Description;
            //    stopRefreshControls = false;
            //}
        } 
        #endregion

        #region Tab Item Creat Athlete
        private void addButton_ClickAthlete(object sender, RoutedEventArgs e)
        {
            //var factoryAthlete = new MakeAthlete();
            //var createFactoryAthlete = factoryAthlete.MakePerson(firstNameAthlete.Text, SecondNameAthlete.Text, int.Parse(uniqueNumberAthlete.Text), DateTimeParsing.DateTimeParse(dateOfBirthAthlete.Text));
            
            Athlete athlete = new Athlete(firstNameAthlete.Text, SecondNameAthlete.Text, int.Parse(uniqueNumberAthlete.Text), DateTimeParsing.DateTimeParse(dateOfBirthAthlete.Text));
            AgeCounter age =new AgeCounter(athlete.DateOfBirth, DateTime.Now);
            string athletAge = age.ToString();
            athlete.Age = athletAge;
            atlets.Add(athlete);
            listViewAthlete.Items.Add(athlete);
        }
        private void removeButton_ClickAthlete(object sender, RoutedEventArgs e)
        {
            atlets.RemoveAt(athleteSelected);
            listViewAthlete.Items.RemoveAt(athleteSelected);
           
        }

        private void saveButton_ClickAthlete(object sender, RoutedEventArgs e)
        {

            SaveReadToFile.Serialize(atlets, @"..\..\atleti.bin");
        }

        private void openButton_ClickAthlete(object sender, RoutedEventArgs e)
        {

        }
        private void listView1_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            athleteSelected = listViewAthlete.Items.CurrentPosition;
        }
        #endregion

        #region TAB Item Create Treinar
        private void addButton_ClickTrainer(object sender, RoutedEventArgs e)
        {
            Trainer trainer = new Trainer(firstNameTrainer.Text, SecondNameTrainer.Text);
            trainers.Add(trainer);
            listViewTrainer.Items.Add(trainer);
        }

        private void removeButton_ClickTrainer(object sender, RoutedEventArgs e)
        {

        }

        private void saveButton_ClickTrainer(object sender, RoutedEventArgs e)
        {
            SaveReadToFile.Serialize(trainers, @"..\..\trainers.bin");
        }

        private void openButton_ClickTrainer(object sender, RoutedEventArgs e)
        {

        } 
        #endregion


    }
}

#region Old Code Don't delete please
//private void Create_Tournament_1(object sender, RoutedEventArgs e)
//{
//    TоurnamentView ViewTournament1 = new TоurnamentView();
//    ViewTournament1.ShowDialog();
//}
//private void Create_Tournament_2(object sender, RoutedEventArgs e)
//{
//    TоurnamentView ViewTournament2 = new TоurnamentView();
//    ViewTournament2.ShowDialog();

//}
//private void Create_Tournament_3(object sender, RoutedEventArgs e)
//{
//    TоurnamentView ViewTournament3 = new TоurnamentView();
//    ViewTournament3.ShowDialog();
//} 
#endregion

#region refresh when typing
//private void dateTextBox_TextChanged(object sender, TextChangedEventArgs e)
//{
//    RefreshListView(dateTextBox.Text, titleTextBox.Text, descriptionTextBox.Text);
//}

//private void titleTextBox_TextChanged(object sender, TextChangedEventArgs e)
//{
//    RefreshListView(dateTextBox.Text, titleTextBox.Text, descriptionTextBox.Text);
//}

//private void descriptionTextBox_TextChanged(object sender, TextChangedEventArgs e)
//{
//    RefreshListView(dateTextBox.Text, titleTextBox.Text, descriptionTextBox.Text);
//} 
#endregion