using Parse;
using SpaceAcademy.DBModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SpaceAcademy.ViewModels.Creatures
{
    public class GameScoreViewModel
    {
        public static Expression<Func<GameScore, GameScoreViewModel>> FromModel
        {
            get
            {
                return model =>
                    new GameScoreViewModel()
                    {
                        PlayerName = model.PlayerName,
                        Score = model.Score
                    };
            }
        }

        public string PlayerName { get; set; }
        public int Score { get; set; }
    }
}
