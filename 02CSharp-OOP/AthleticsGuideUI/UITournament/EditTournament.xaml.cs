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
using UITournament.CSharpCode;
using UITournament.Properties;
using UITournament.CSharpCode.FactoryMethod;

namespace UITournament
{
    /// <summary>
    /// Interaction logic for EditTournament.xaml
    /// </summary>
    public partial class EditTournament : Window
    {
        public List<AthleticDiscipline> disciplines;
        protected List<Athlete> athletesInTour = new List<Athlete>();
        protected AthleticDiscipline sprint100metresMen = new AthleticDiscipline();
        protected List<Athlete> DisciplineWithAthletes = new List<Athlete>();
        

        public EditTournament()
        {
            InitializeComponent();

            
        }
        public EditTournament(string tournamentName, string town, DateTime startDate, DateTime endDate)
            : this()
        {
            this.NameTournament.Text = tournamentName;
            this.DateStart.Text = startDate.ToShortDateString();
            this.DateEnd.Text = endDate.ToShortDateString();
            this.Town.Text = town;
        
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {

            Athlete athlete = new Athlete(firtsName.Text, lastname.Text, int.Parse(number.Text), DateTimeParsing.DateTimeParse(dateOfBirth.Text), team.Text, results.Text, finalResult.Text, record.Text, Sex.Male, null, Position.Text);

            ListAthlete.Items.Add(athlete);
            athletesInTour.Add(athlete);
            
            //DisciplineWithAthletes.Add(athlete);
            
           
            
        }

        private void SaveDiscipline_Click(object sender, RoutedEventArgs e)
        {
            SaveReadToFile.Serialize(athletesInTour, @"..\..\athletesInTour.bin");
        }

        private void endDate_Copy1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void sprint100metresMen_Click(object sender, RoutedEventArgs e)
        {
           
            sprint100metresMen = new AthleticDiscipline(Disciplines.Sprint100Metres, Sex.Male);
            this.Discipline.Text = Disciplines.Sprint100Metres.ToString();
            this.Gender.Text = Sex.Male.ToString();
            if (null != (List<Athlete>)SaveReadToFile.Deserialize(@"..\..\athletesInTour.bin"))
            {
                athletesInTour = (List<Athlete>)SaveReadToFile.Deserialize(@"..\..\athletesInTour.bin");
                for (int i = 0; i < athletesInTour.Count; i++)
                {
                    ListAthlete.Items.Add(athletesInTour[i]);
                }
            }
            

        }

        private void sprint200metresMen_Click(object sender, RoutedEventArgs e)
        {
            ListAthlete.Items.Clear();

            AthleticDiscipline sprint200metresMen = new AthleticDiscipline(Disciplines.Sprint200Metres, Sex.Male);
            this.Discipline.Text = Disciplines.Sprint200Metres.ToString();
            this.Gender.Text = Sex.Male.ToString();
        }

        private void sprint400metresMen_Click(object sender, RoutedEventArgs e)
        {
            ListAthlete.Items.Clear();
            AthleticDiscipline sprint400metresMen = new AthleticDiscipline(Disciplines.Sprint400Metres, Sex.Male);
            this.Discipline.Text = Disciplines.Sprint400Metres.ToString();
            this.Gender.Text = Sex.Male.ToString();
        }

        private void hurdles100metresMen_Click(object sender, RoutedEventArgs e)
        {
            ListAthlete.Items.Clear();
            AthleticDiscipline hurdles100metresMen = new AthleticDiscipline(Disciplines.Hurdles100Metres, Sex.Male);
            this.Discipline.Text = Disciplines.Hurdles100Metres.ToString();
            this.Gender.Text = Sex.Male.ToString();
        }

        private void hurdles400metresMen_Click(object sender, RoutedEventArgs e)
        {
            ListAthlete.Items.Clear();
            AthleticDiscipline hurdles400metresMen = new AthleticDiscipline(Disciplines.Hurdles400Metres, Sex.Male);
            this.Discipline.Text = Disciplines.Hurdles400Metres.ToString();
            this.Gender.Text = Sex.Male.ToString();
        }

        private void highJumpMen_Click(object sender, RoutedEventArgs e)
        {
            ListAthlete.Items.Clear();
            AthleticDiscipline highJumpMen = new AthleticDiscipline(Disciplines.HighJump, Sex.Male);
            this.Discipline.Text = Disciplines.HighJump.ToString();
            this.Gender.Text = Sex.Male.ToString();
        }

        private void longJumpMen_Click(object sender, RoutedEventArgs e)
        {
            ListAthlete.Items.Clear();
            AthleticDiscipline longJumpMen = new AthleticDiscipline(Disciplines.LongJump, Sex.Male);
            this.Discipline.Text = Disciplines.LongJump.ToString();
            this.Gender.Text = Sex.Male.ToString();
        }

        private void tripleJumpMen_Click(object sender, RoutedEventArgs e)
        {
            ListAthlete.Items.Clear();
            AthleticDiscipline tripleJumpMen = new AthleticDiscipline(Disciplines.TripleJump, Sex.Male);
            this.Discipline.Text = Disciplines.TripleJump.ToString();
            this.Gender.Text = Sex.Male.ToString();
        }

        private void poleVaultMen_Click(object sender, RoutedEventArgs e)
        {
            ListAthlete.Items.Clear();
            AthleticDiscipline poleVaultMen = new AthleticDiscipline(Disciplines.PoleVault, Sex.Male);
            this.Discipline.Text = Disciplines.PoleVault.ToString();
            this.Gender.Text = Sex.Male.ToString();
        }

        private void decathlonMen_Click(object sender, RoutedEventArgs e)
        {
            ListAthlete.Items.Clear();
            AthleticDiscipline decathlonMen = new AthleticDiscipline(Disciplines.Decathlon, Sex.Male);
            this.Discipline.Text = Disciplines.Decathlon.ToString();
            this.Gender.Text = Sex.Male.ToString();
        }

        private void sprint100metresWomen__Click(object sender, RoutedEventArgs e)
        {
            ListAthlete.Items.Clear();
            AthleticDiscipline sprint100metresWomen = new AthleticDiscipline(Disciplines.Sprint100Metres, Sex.Female);
            this.Discipline.Text = Disciplines.Sprint100Metres.ToString();
            this.Gender.Text = Sex.Female.ToString();
        }

        private void sprint200metresWomen__Click(object sender, RoutedEventArgs e)
        {
            ListAthlete.Items.Clear();
            AthleticDiscipline sprint200metresWomen = new AthleticDiscipline(Disciplines.Sprint200Metres, Sex.Female);
            this.Discipline.Text = Disciplines.Sprint200Metres.ToString();
            this.Gender.Text = Sex.Female.ToString();
        }

        private void sprint400metresWomen__Click(object sender, RoutedEventArgs e)
        {
            ListAthlete.Items.Clear();
            AthleticDiscipline sprint400metresWomen = new AthleticDiscipline(Disciplines.Sprint400Metres, Sex.Female);
            this.Discipline.Text = Disciplines.Sprint400Metres.ToString();
            this.Gender.Text = Sex.Female.ToString();
        }

        private void hurdles100metresWomen__Click(object sender, RoutedEventArgs e)
        {
            ListAthlete.Items.Clear();
            AthleticDiscipline hurdles100metresWomen = new AthleticDiscipline(Disciplines.Hurdles100Metres, Sex.Female);
            this.Discipline.Text = Disciplines.Hurdles100Metres.ToString();
            this.Gender.Text = Sex.Female.ToString();
        }

        private void hurdles400metresWomen__Click(object sender, RoutedEventArgs e)
        {
            ListAthlete.Items.Clear();
            AthleticDiscipline hurdles400metresWomen = new AthleticDiscipline(Disciplines.Hurdles400Metres, Sex.Female);
            this.Discipline.Text = Disciplines.Hurdles400Metres.ToString();
            this.Gender.Text = Sex.Female.ToString();
        }

        private void highJumpWomen__Click(object sender, RoutedEventArgs e)
        {
            ListAthlete.Items.Clear();
            AthleticDiscipline highJumpWomen = new AthleticDiscipline(Disciplines.HighJump, Sex.Female);
            this.Discipline.Text = Disciplines.HighJump.ToString();
            this.Gender.Text = Sex.Female.ToString();
        }

        private void longJumpWomen__Click(object sender, RoutedEventArgs e)
        {
            ListAthlete.Items.Clear();
            AthleticDiscipline longJumpWomen = new AthleticDiscipline(Disciplines.LongJump, Sex.Female);
            this.Discipline.Text = Disciplines.LongJump.ToString();
            this.Gender.Text = Sex.Female.ToString();
        }

        private void tripleJumpWomen__Click(object sender, RoutedEventArgs e)
        {
            ListAthlete.Items.Clear();
            AthleticDiscipline tripleJumpWomen = new AthleticDiscipline(Disciplines.TripleJump, Sex.Female);
            this.Discipline.Text = Disciplines.TripleJump.ToString();
            this.Gender.Text = Sex.Female.ToString();
        }

        private void poleVaultWomen__Click(object sender, RoutedEventArgs e)
        {
            ListAthlete.Items.Clear();
            AthleticDiscipline poleVaultWomen = new AthleticDiscipline(Disciplines.PoleVault, Sex.Female);
            this.Discipline.Text = Disciplines.PoleVault.ToString();
            this.Gender.Text = Sex.Female.ToString();
        }

        private void heptathlonWomen_Click(object sender, RoutedEventArgs e)
        {
            ListAthlete.Items.Clear();
            AthleticDiscipline heptathlonWomen = new AthleticDiscipline(Disciplines.Heptathlon, Sex.Female);
            this.Discipline.Text = Disciplines.Heptathlon.ToString();
            this.Gender.Text = Sex.Female.ToString();
        }

        private void Black(object sender, RoutedEventArgs e)
        {
            
        }

        private void White(object sender, RoutedEventArgs e)
        {

        }

        private void Green(object sender, RoutedEventArgs e)
        {

        }

        private void ListAthlete_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }



    }
}
