namespace Minesweeper
{
    using System.Collections.Generic;
    using Minesweeper.Data;
    using Minesweeper.Interfaces;
    using Minesweeper.ReadWrite;

    public class Scoreboard
    {        
        public static void Save(List<IPlayer> players)
        {
            var seriazablePlayers = new List<SerializablePlayer>();

            foreach (var player in players)
            {
                seriazablePlayers.Add(new SerializablePlayer(player.Name, player.Score));
            }

            FileReadWrite.Serialize(seriazablePlayers, @"..\..\Scoreboard.bin");
        }

        public static List<IPlayer> Load()
        {
            var players = new List<IPlayer>();

            if (null != FileReadWrite.Deserialize(@"..\..\Scoreboard.bin"))
            {
                var seriazablePlayers = (List<SerializablePlayer>)FileReadWrite.Deserialize(@"..\..\Scoreboard.bin");

                foreach (var seriazablePlayer in seriazablePlayers)
                {
                    players.Add(new Player(seriazablePlayer.Name, seriazablePlayer.Score));
                }
            }

            return players;
        }
    }
}