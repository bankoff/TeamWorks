using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITournament.CSharpCode
{
    public class InvalidNameException : ApplicationException
    {
        public InvalidNameException(string message)
            : base(message)
        {

        }
        public InvalidNameException(string message, Exception innEx)
            : base(message, innEx)
        {

        }
    }
}