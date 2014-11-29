using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITournament.CSharpCode
{
    public class InvalidUniqueNumberException : ApplicationException
    {
        public InvalidUniqueNumberException(string message)
            : base(message)
        {

        }

        public InvalidUniqueNumberException(string message, Exception innEx)
            : base(message, innEx)
        {

        }
    }
}