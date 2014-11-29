using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITournament.CSharpCode
{
    public class InvalidTeamLocationException : ApplicationException
    {
        public InvalidTeamLocationException(string message)
            : base(message)
        {

        }
        public InvalidTeamLocationException(string message, Exception innEx)
            : base(message, innEx)
        {

        }
    }
}

