namespace Minesweeper
{
    using System;
    using Interfaces;

    public class RandomGenerator : IRandomGenerator
    {
        private Random random;
    
        public RandomGenerator()
        {
            this.random = new Random();
        }

        public int GenerateRandomNumber(int minValue, int maxValue)
        {
            var number = this.random.Next(minValue, maxValue);
            return number;
        }
    }
}
