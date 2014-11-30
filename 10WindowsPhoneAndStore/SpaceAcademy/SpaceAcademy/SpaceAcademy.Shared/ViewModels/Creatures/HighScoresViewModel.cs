using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Parse;
using SpaceAcademy.DBModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SpaceAcademy.ViewModels.Creatures
{
    public class HighScoresViewModel : ViewModelBase
    {
        private ObservableCollection<GameScoreViewModel> gameScores;
        private ICommand refreshCommand;

        public IEnumerable<GameScoreViewModel> GameScores
        {
            get
            {
                if (this.gameScores == null)
                {
                    this.GameScores = new ObservableCollection<GameScoreViewModel>();
                }
                return this.gameScores;
            }
            set
            {
                if (this.gameScores == null)
                {
                    this.gameScores = new ObservableCollection<GameScoreViewModel>();
                }
                this.gameScores.Clear();
                foreach (var item in value)
                {
                    this.gameScores.Add(item);
                }
            }
        }

        public ICommand Refresh
        {
            get
            {
                if (this.refreshCommand == null)
                {
                    this.refreshCommand = new RelayCommand(this.PerformRefresh);
                }
                return this.refreshCommand;
            }
        }

        private void PerformRefresh()
        {
            this.LoadGameScores();
        }

        public HighScoresViewModel()
        {
            this.LoadGameScores();
        }

        public async Task LoadGameScores()
        {
            var gameScores = await new ParseQuery<GameScore>()
                .FindAsync(CancellationToken.None);

            this.GameScores = gameScores.AsQueryable()
                .Select(GameScoreViewModel.FromModel);
        }
    }
}
