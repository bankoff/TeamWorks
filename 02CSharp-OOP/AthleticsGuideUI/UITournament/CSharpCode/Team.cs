using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITournament.CSharpCode
{
    [Serializable]
    public class Team
    {
        private string teamName;
        private string teamLocation;

        public string TeamLocation
        {
            get { return teamLocation; }
            set
            {
                if (Validation.ValidateTown(value))
                {
                    teamLocation = value;
                }
                else
                {
                    throw new InvalidTeamLocationException("The entered value is not valid!\nAllowed symbols: letters A-Z (case insensitive)!");
                }
            }
        }

        public string TeamName
        {
            get { return teamName; }
            set
            {
                if (Validation.ValidateTeamName(value))
                {
                    teamName = value;
                }
                else
                {
                    throw new InvalidTeamNameException("The entered team name is not valid!\n Allowed symbols: letters A-Z (case insensitive); digits (0-9); -; .;\nStart with letter!"); 
                }
            }
        }

        public Team(string teamName)
        {
            this.TeamName = teamName;
        }

        public Team(string teamName, string location)
            :this (teamName)
        {         
            this.TeamLocation = location;
        }

        public override string ToString()
        {
            return ("Team: " + this.TeamName + " - " + this.TeamLocation);
        }
    }
}
