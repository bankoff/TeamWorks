using SpaceAcademy.DBModels;
using SpaceAcademy;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using SpaceAcademy.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace SpaceAcademy.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class QuestionPage : Page
    {
        private const string dbName = "QuestionsWithAnswers.db";

        private int points;

        public List<QuestionsWithAnswers> questions { get; set; }

        public QuestionPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Create Db if not exist
            bool dbExists = await CheckDbAsync(dbName);
            if (!dbExists)
            {
                await CreateDatabaseAsync();
                await AddQuestionsAsync();
            }

            // Get Articles
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(dbName);
            var query = conn.Table<QuestionsWithAnswers>();
            questions = await query.ToListAsync();

            // Show users
            var getQuestionNumber = GameViewModel.rand.Next(questions.Count);
            var question = questions[getQuestionNumber];
            questions.Clear();
            questions.Add(question);
            QuestionList.ItemsSource = questions;
        }

        private void Button_Click_Answer_One(object sender, RoutedEventArgs e)
        {
            if(questions[0].RightAnswer == 1)
            {
                this.Frame.Navigate(typeof(GamePage));
            }
            else
            {
                this.Frame.Navigate(typeof(GameOverPage), points);
            }
        }

        private void Button_Click_Answer_Two(object sender, RoutedEventArgs e)
        {
            if (questions[0].RightAnswer == 2)
            {
                this.Frame.Navigate(typeof(GamePage));
            }
            else
            {
                this.Frame.Navigate(typeof(GameOverPage), points);
            }
        }

        private void Button_Click_Answer_Three(object sender, RoutedEventArgs e)
        {
            if (questions[0].RightAnswer == 3)
            {
                this.Frame.Navigate(typeof(GamePage));
            }
            else
            {
                this.Frame.Navigate(typeof(GameOverPage), points);
            }
        }

        #region SQLite utils
        private async Task<bool> CheckDbAsync(string dbName)
        {
            bool dbExist = true;

            try
            {
                StorageFile sf = await ApplicationData.Current.LocalFolder.GetFileAsync(dbName);
            }
            catch (Exception)
            {
                dbExist = false;
            }

            return dbExist;
        }

        private async Task CreateDatabaseAsync()
        {
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(dbName);
            await conn.CreateTableAsync<QuestionsWithAnswers>();
        }

        private async Task AddQuestionsAsync()
        {
            // Create a Articles list
            var list = new List<QuestionsWithAnswers>()
            {
                new QuestionsWithAnswers()
                {
                    Question = "What is the closest planet to the Sun?",
                    AnswerOne = "Titan",
                    AnswerTwo = "Mercury",
                    AnswerThree = "Mars",
                    RightAnswer = 2
                },
                new QuestionsWithAnswers()
                {
                    Question = "Who was the first person to walk on the moon?",
                    AnswerOne = "Valentina Tereshkova",
                    AnswerTwo = "Michael Foale",
                    AnswerThree = "Neil Armstrong",
                    RightAnswer = 3
                },
                new QuestionsWithAnswers()
                {
                    Question = "Olympus Mons is a large volcanic mountain on which planet?",
                    AnswerOne = "Mars",
                    AnswerTwo = "Jupiter",
                    AnswerThree = "Saturn",
                    RightAnswer = 1
                },
                new QuestionsWithAnswers()
                {
                    Question = "What is the name of Saturn’s largest moon?",
                    AnswerOne = "Titan",
                    AnswerTwo = "Mercury",
                    AnswerThree = "Sputnik",
                    RightAnswer = 1
                },
                new QuestionsWithAnswers()
                {
                    Question = "What is the name of the first satellite sent into space?",
                    AnswerOne = "Titan",
                    AnswerTwo = "Sputnik",
                    AnswerThree = "Vostock 1",
                    RightAnswer = 2
                },
                new QuestionsWithAnswers()
                {
                    Question = "What planet is famous for its big red spot on it?",
                    AnswerOne = "Mars",
                    AnswerTwo = "Mercury",
                    AnswerThree = "Jupiter",
                    RightAnswer = 3
                },
                new QuestionsWithAnswers()
                {
                    Question = "What is the name of the 2nd biggest planet in our solar system?",
                    AnswerOne = "Neptune",
                    AnswerTwo = "Mars",
                    AnswerThree = "Saturn",
                    RightAnswer = 3
                },
                new QuestionsWithAnswers()
                {
                    Question = "Ganymede is a moon of which planet?",
                    AnswerOne = "Jupiter",
                    AnswerTwo = "Mercury",
                    AnswerThree = "Neptune",
                    RightAnswer = 1
                },
                new QuestionsWithAnswers()
                {
                    Question = "What planet is famous for the beautiful rings that surround it?",
                    AnswerOne = "Jupiter",
                    AnswerTwo = "Saturn",
                    AnswerThree = "Mars",
                    RightAnswer = 2
                }
            };

            // Add rows to the Article Table
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(dbName);
            await conn.InsertAllAsync(list);
        }

        private async Task SearchQuestionByTitleAsync(string title)
        {
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(dbName);

            AsyncTableQuery<QuestionsWithAnswers> query = conn.Table<QuestionsWithAnswers>().Where(x => x.Question.Contains(title));
            List<QuestionsWithAnswers> result = await query.ToListAsync();
            foreach (var question in result)
            {
                // ...
            }

            var allQuestions = await conn.QueryAsync<QuestionsWithAnswers>("SELECT * FROM Articles");
            foreach (var question in allQuestions)
            {
                // ...
            }

            var otherQuestions = await conn.QueryAsync<QuestionsWithAnswers>(
                "SELECT Content FROM Articles WHERE Title = ?", new object[] { "Hackers, Creed" });
            foreach (var question in otherQuestions)
            {
                // ...
            }
        }

        private async Task UpdateQuestionTitleAsync(string oldTitle, string newTitle)
        {
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(dbName);

            // Retrieve Article
            var question = await conn.Table<QuestionsWithAnswers>()
                .Where(x => x.Question == oldTitle).FirstOrDefaultAsync();
            if (question != null)
            {
                // Modify Article
                question.Question = newTitle;

                // Update record
                await conn.UpdateAsync(question);
            }
        }

        private async Task DeleteQuestionAsync(string name)
        {
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(dbName);

            // Retrieve Article
            var article = await conn.Table<QuestionsWithAnswers>().Where(x => x.Question == name).FirstOrDefaultAsync();
            if (article != null)
            {
                // Delete record
                await conn.DeleteAsync(article);
            }
        }

        private async Task DropTableAsync(string name)
        {
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(dbName);
            await conn.DropTableAsync<QuestionsWithAnswers>();
        }

        #endregion SQLite utils
    }
}
