using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITournament.CSharpCode
{
    [Serializable]
    public class AthleticDiscipline
    {
        public Enum Discipline { get; set; }
        public Enum Gender { get; set; }
        public List<Athlete> DisciplineWithAthletes { get; set; }
        public AthleticDiscipline()
        {

        }

        public AthleticDiscipline(Enum discipline, Enum gender)
            :this()
        {
            this.Discipline = discipline;
            this.Gender = gender;
            
        }

        public AthleticDiscipline(Enum discipline, Enum gender, List<Athlete> disciplineWithAthletes)
            :this(discipline,gender)
        {
            this.DisciplineWithAthletes = disciplineWithAthletes;
        }
    }
}
