using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITournament.CSharpCode
{
    public class InvalidTournamentLocationException : ApplicationException
    {
        public InvalidTournamentLocationException(string message)
            : base(message)
        {

        }
        public InvalidTournamentLocationException(string message, Exception innEx)
            : base(message, innEx)
        {

        }
    }
}