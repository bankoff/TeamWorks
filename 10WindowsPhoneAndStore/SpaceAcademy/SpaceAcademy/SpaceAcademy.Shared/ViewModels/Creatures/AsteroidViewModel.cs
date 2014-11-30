using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceAcademy.ViewModels.Creatures
{
    public class AsteroidViewModel: GameObjectViewModel
    {
        private const string AsteroidImageSource = "../Images/asteroid.jpg";
        private const double DefaultGameObjectSize = 40;
        public AsteroidViewModel(double left, double top)
            : base(DefaultGameObjectSize, left, top, AsteroidImageSource)
        {
        }
    }
}
