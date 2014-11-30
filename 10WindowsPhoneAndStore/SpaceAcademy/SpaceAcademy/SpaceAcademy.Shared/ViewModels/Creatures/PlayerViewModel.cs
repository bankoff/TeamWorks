using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceAcademy.ViewModels.Creatures
{
    public class PlayerViewModel: GameObjectViewModel
    {
        private const double DefaultBallSpeed = 10;

        private const string DefaultImageSource = "../Images/ufo_gray_red_blue.png";

        public PlayerViewModel(double size, double left, double top)
            : this(size, left, top, DefaultBallSpeed, DefaultImageSource)
        {
        }
        public PlayerViewModel(double size, double left, double top, double speed, string imageSource)
            :base(size,left,top,imageSource)
        {
            this.Speed = speed;
        }

        public double Speed { get; set; }
    }
}