using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITournament.CSharpCode
{
    public class DateTimeParsing
    {
        public static DateTime DateTimeParse(string datetime)
        {
            string[] datetimeSplitted = datetime.Split('.', '/', ',', ' ');
            DateTime result = new DateTime(int.Parse(datetimeSplitted[2]), int.Parse(datetimeSplitted[1]), int.Parse(datetimeSplitted[0]));
            return result;
        }
    }
}