namespace Game.Tests.DataTests
{
    using System;
    using Minesweeper.Interfaces;

    public class RandomGeneratorForTesting : IRandomGenerator
    {
        private int numberToReturn;

        public RandomGeneratorForTesting(int numberToReturn)
        {
            this.numberToReturn = numberToReturn;
        }

        public int GenerateRandomNumber(int minValue, int maxValue)
        {
            if (this.numberToReturn < minValue || this.numberToReturn > maxValue)
            {
                throw new ArgumentException("The returned number is not in the appropriate range.");
            }

            return this.numberToReturn;
        }
    }
}
