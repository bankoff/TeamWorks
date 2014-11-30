using Parse;
using SpaceAcademy.DBModels;
using SpaceAcademy.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;  

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace SpaceAcademy.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GameOverPage : Page
    {
        private GameScore gameScore;

        public GameOverPage()
        {
            this.InitializeComponent();

            gameScore = new GameScore();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }



        private void TextBlock_Loaded(object sender, RoutedEventArgs e)
        {
            // Get TextBlock reference.
            var block = sender as TextBlock;
            // Set text.
            block.Text = "Your score is " + GameViewModel.Points;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(3 <= playerName.Text.Length && playerName.Text.Length <= 12)
            {
                gameScore.PlayerName = playerName.Text;
                gameScore.Score = GameViewModel.Points;
                SaveScore();
                GameViewModel.Points = 0;
                Frame nextFrame = Window.Current.Content as Frame;
                nextFrame.Navigate(typeof(MainPage));
            }
            else
            {
                MessageBoxDisplay();
            }
        }

        private async void SaveScore()
        {
            await gameScore.SaveAsync();
        }

        private async void MessageBoxDisplay()
        {
            //Creating instance for the MessageDialog Class  
            //and passing the message in it's Constructor  
            MessageDialog msgbox = new MessageDialog("Your Name must be between 3 and 12 characters");
            //Calling the Show method of MessageDialog class  
            //which will show the MessageBox  
            await msgbox.ShowAsync();
        }
    }
}
