using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITournament.CSharpCode
{
    [Serializable]
    public class Tournament
    {
        private string tournamentName;
        private string town;
        private DateTime startDate;
        private DateTime endDate;

        public DateTime EndDate
        {
            // TODO: implement validation - done
            get { return endDate; }
            set
            {
                try
                {
                    if (Validation.ValidateEndDate(startDate, value))
                    {
                        endDate = value;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception ex)
                {
                    throw new ArgumentOutOfRangeException("The entered date is not valid! It should be equal or greater than " + StartDate.ToShortDateString(), ex);
                }
            }
        }

        public DateTime StartDate
        {
            // TODO: implement validation
            get { return startDate; }
            set { startDate = value; }
        }

        public string TournamentName
        {
            get { return tournamentName; }
            set
            {
                try
                {
                    if (Validation.ValidateTournamentName(value))
                    {
                        tournamentName = value;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception ex)
                {
                    throw new InvalidTournamentNameException("The entered value is not valid!\n Allowed symbols: letters A-Z (case insensitive), digits 0-9, -, ',', \" \"!", ex);
                }
            }
        }
        public string Town
        {
            get { return town; }
            set
            {
                try
                {
                    if (Validation.ValidateTown(value))
                    {
                        town = value;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception ex)
                {
                    throw new InvalidTournamentLocationException("The entered value is not valid!\nAllowed symbols: letters A-Z (case insensitive)!", ex);
                }
            }
        }


        public Tournament(string tournamentName, string town, DateTime startDate, DateTime endDate)
        {
            this.TournamentName = tournamentName;
            this.Town = town;
            this.StartDate = startDate;
            this.EndDate = endDate;
        }
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(this.TournamentName);
            output.AppendLine(this.Town);
            output.AppendLine(this.StartDate.ToString());
            output.AppendLine(this.EndDate.ToString());
            return output.ToString();
        }
    }
}