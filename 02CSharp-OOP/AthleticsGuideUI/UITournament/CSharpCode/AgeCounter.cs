using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UITournament;

namespace UITournament.CSharpCode
{
    public struct AgeCounter
    {
        public DateTime BirthDate { get; set; }
        public DateTime EndDate { get; set; }

        public AgeCounter(DateTime birthDate, DateTime endDate)
            : this()
        {
            this.BirthDate = birthDate;
            this.EndDate = endDate;
        }

        public override string ToString()
        {
            int age = 0;
            age = this.EndDate.Year - this.BirthDate.Year;
            if (this.EndDate.DayOfYear < this.BirthDate.DayOfYear)
                age = age - 1;

            return age.ToString();
        }
    }
}
