namespace Minesweeper.ReadWrite
{
    using System;

    [Serializable]
    public class SerializablePlayer
    {
        private string name;
        private int score;

        public SerializablePlayer(string name, int score)
        {
            this.Name = name;
            this.Score = score;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Invalid name of the player.");
                }

                this.name = value;
            }
        }

        public int Score
        {
            get
            {
                return this.score;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid score of the player. Score must be positive number.");
                }

                this.score = value;
            }
        }
    }
}
