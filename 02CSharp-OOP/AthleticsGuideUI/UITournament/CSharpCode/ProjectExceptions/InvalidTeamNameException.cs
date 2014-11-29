using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITournament.CSharpCode
{
    public class InvalidTeamNameException : ApplicationException
    {
        public InvalidTeamNameException(string message)
            : base(message)
        {

        }

        public InvalidTeamNameException(string message, Exception innEx)
            : base(message, innEx)
        {

        }
    }
}