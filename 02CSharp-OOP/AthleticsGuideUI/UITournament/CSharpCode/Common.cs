using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITournament.CSharpCode
{
    class Common
    {
        public static string GetAge(Athlete athlete, Tournament tournament)
        {
            AgeCounter age = new AgeCounter(athlete.DateOfBirth, tournament.EndDate);
            return age.ToString();
        }
    }
}
