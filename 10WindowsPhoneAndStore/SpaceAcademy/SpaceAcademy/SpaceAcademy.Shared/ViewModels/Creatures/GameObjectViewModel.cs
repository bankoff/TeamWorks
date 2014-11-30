using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceAcademy.ViewModels.Creatures
{
    public class GameObjectViewModel : ViewModelBase
    {
        private double top;
        private double left;

        private const double DefaultGameObjectSize = 30;
        private double size;

        public GameObjectViewModel(double top, double left, string imageSource)
            : this(DefaultGameObjectSize, top, left, imageSource)
        {
        }

        public GameObjectViewModel(double size, double left, double top, string imageSource)
        {
            this.ImageSource = imageSource;
            this.Size = size;
            this.Position = new PositionViewModel(left, top);

            this.IsAlive = true;
        }

        public PositionViewModel Position { get; set; }
        public string ImageSource { get; set; }

        public double Size
        {
            get
            {
                return this.size;
            }
            set
            {
                this.size = value;
                this.RaisePropertyChanged(() => this.Size);
            }
        }

        public bool IsAlive { get; set; }

        public virtual bool IsOver(GameObjectViewModel other)
        {
            var min = this.Position.Y;
            var max = this.Position.Y + this.Size;

            var left1 = other.Position.Y;
            var left2 = other.Position.Y + other.Size;

            bool isOverHorizontally = (min <= left1 && left1 <= max) || (min <= left2 && left2 <= max);

            if (!isOverHorizontally)
            {
                return false;
            }

            min = this.Position.X + 10;
            max = this.Position.X + this.Size - 10;
            var top1 = other.Position.X;
            var top2 = other.Position.X + other.Size;
            bool isOverVertically = (min <= top1 && top1 <= max) || (min <= top2 && top2 <= max);

            return isOverVertically;
        }
    }
}
