using GalaSoft.MvvmLight;
using SpaceAcademy.Pages;
using SpaceAcademy.ViewModels.Creatures;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace SpaceAcademy.ViewModels
{
    public class GameViewModel : ViewModelBase
    {
        private const int GameTimerIntervalInMilliseconds = 30;
        private const int MaxAsteroidsCount = 10;

        public static readonly Random rand = new Random();

        private double width;
        private double height;
        private bool shouldGoToQuestion;

        private ObservableCollection<GameObjectViewModel> gameObjects;
        private ObservableCollection<AsteroidViewModel> asteroids;

        public DispatcherTimer GameTimer { get; set; }

        public PlayerViewModel Player { get; set; }

        public static int Points { get; set; }

        public GameViewModel(double width, double height)
        {
            this.Width = width;
            this.Height = height;
            this.GameTimer = new DispatcherTimer();
            this.GameTimer.Tick += this.GameTimerTick;
            this.GameTimer.Interval = TimeSpan.FromMilliseconds(GameTimerIntervalInMilliseconds);

            this.Player = new PlayerViewModel(0, 0, 0);
            this.Asteroids = new ObservableCollection<AsteroidViewModel>();
            this.GameObjects = new ObservableCollection<GameObjectViewModel>();

            shouldGoToQuestion = false;
            this.StartGame();
        }

        private void GameTimerTick(object sender, object e)
        {
            //move asteroids
            bool shouldGenerateAsteroid = false;

            foreach (var asteroid in this.Asteroids)
            {
                var deltaTop = rand.Next(6) - 3;
                if (0 <= asteroid.Position.Y + deltaTop && asteroid.Position.Y + deltaTop <= this.Width - 30)
                {
                    asteroid.Position.Y += deltaTop;
                }
                asteroid.Position.X += 3;
                if (this.Height < asteroid.Position.X + 30)
                {
                    asteroid.IsAlive = false;
                    shouldGenerateAsteroid = true;
                }

                if (this.Player.IsOver(asteroid))
                {
                    asteroid.IsAlive = false;
                    shouldGoToQuestion = true;
                }
            }


            //remove destroyed game objects
            var gameObjectsToRemove = this.gameObjects.Where(go => !go.IsAlive).ToList();
            this.RemoveGameObjects(gameObjectsToRemove);

            if (shouldGenerateAsteroid && !shouldGoToQuestion)
            {
                this.GenerateNewEnemies();
            }

            if (shouldGoToQuestion)
            {
                GoToQuestion();
            }
        }

        private void GoToQuestion()
        {
            this.GameTimer.Stop();
            var gameObjectsToRemove = this.asteroids.Where(go => true).ToList();
            this.RemoveGameObjects(gameObjectsToRemove);
            Frame nextFrame = Window.Current.Content as Frame;
            nextFrame.Navigate(typeof(QuestionPage));
        }

        private void GenerateNewEnemies()
        {
            while (this.asteroids.Count < MaxAsteroidsCount)
            {
                var asteroid = this.AddAsteroidAtRandomPosition();
                this.asteroids.Add(asteroid);
                this.gameObjects.Add(asteroid);
            }
        }

        private void RemoveGameObjects(IEnumerable<GameObjectViewModel> gameObjectsToRemove)
        {
            if (!gameObjectsToRemove.Any())
            {
                return;
            }
            foreach (var gameObject in gameObjectsToRemove)
            {
                this.gameObjects.Remove(gameObject);
                if (gameObject is AsteroidViewModel)
                {
                    this.asteroids.Remove((AsteroidViewModel)gameObject);
                    Points += 10;
                }
            }
        }

        private void StartGame()
        {
            if(Points == null)
            {
                Points = 0;
            }

            this.Player = new PlayerViewModel(50, 150, 300);

            this.gameObjects.Clear();
            this.gameObjects.Add(this.Player);

            this.asteroids.Clear();

            var asteroidsCount = MaxAsteroidsCount;
            var asteroidIndex = 0;
            var timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += (snd, args) =>
            {
                if (asteroidIndex >= asteroidsCount - 1)
                {
                    timer.Stop();
                }
                var asteroid = this.AddAsteroidAtRandomPosition();
                this.asteroids.Add(asteroid);
                this.gameObjects.Add(asteroid);
                asteroidIndex++;
            };
            timer.Start();
            if (this.GameTimer.IsEnabled)
            {
                this.GameTimer.Stop();
            }
            this.GameTimer.Start();
        }

        public IEnumerable<GameObjectViewModel> GameObjects
        {
            get
            {
                return this.gameObjects;
            }
            set
            {
                if (this.gameObjects == null)
                {
                    this.gameObjects = new ObservableCollection<GameObjectViewModel>();
                }
                this.gameObjects.Clear();
                this.gameObjects.AddRange(value);
            }
        }

        public IEnumerable<AsteroidViewModel> Asteroids
        {
            get
            {
                return this.asteroids;
            }
            set
            {
                if (this.asteroids == null)
                {
                    this.asteroids = new ObservableCollection<AsteroidViewModel>();
                }
                this.asteroids.Clear();
                this.asteroids.AddRange(value);
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                this.width = value;
                this.RaisePropertyChanged(() => this.Width);
            }
        }
        public double Height
        {
            get
            {
                return this.height;
            }
            set
            {
                this.height = value;
                this.RaisePropertyChanged(() => this.Height);
            }
        }

        private bool InRange(double value, double min, double max)
        {
            return (min <= value && value <= max);
        }

        public void MovePlayerWithDelta(double dx, double dy)
        {
            var x = Player.Position.X + Player.Speed * dx;
            var y = Player.Position.Y + Player.Speed * dy;

            if (this.InRange(x, 0, this.Height - Player.Size))
            {
                Player.Position.X = x;
            }

            if (this.InRange(y, 0, this.Width - Player.Size))
            {
                Player.Position.Y = y;
            }
        }

        public AsteroidViewModel AddAsteroidAtRandomPosition()
        {
            var top = 0;
            var left = rand.Next(0, (int)this.Width - 30);
            var enemy = new AsteroidViewModel(top, left);

            return enemy;
        }
    }
}
