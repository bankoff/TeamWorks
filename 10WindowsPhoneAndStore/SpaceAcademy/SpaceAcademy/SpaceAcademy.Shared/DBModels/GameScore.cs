using Parse;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceAcademy.DBModels
{
    [ParseClassName("GameScore")]
    public class GameScore : ParseObject
    {
        [ParseFieldName("playerName")]
        public string PlayerName
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }

        [ParseFieldName("score")]
        public int Score
        {
            get { return GetProperty<int>(); }
            set { SetProperty<int>(value); }
        }
    }
}
