using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITournament.CSharpCode
{
    public class InvalidTournamentNameException : ApplicationException
    {
        public InvalidTournamentNameException(string message)
            : base(message)
        {

        }

        public InvalidTournamentNameException(string message, Exception innEx)
            : base(message, innEx)
        {

        }
    }
}