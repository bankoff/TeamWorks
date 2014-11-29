using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITournament.CSharpCode.FactoryMethod;

namespace UITournament.CSharpCode
{
    [Serializable]
    public class Trainer : Person
    {
        private Team team;

        public Team Team
        {
            get { return team; }
            set { team = value; }
        }

        public Trainer(string firstName, string lastName)
            : base(firstName, lastName)
        {
        }

        public Trainer(string firstName, string lastName, Team team)
            : this(firstName, lastName)
        {
            this.Team = team;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("Trainer: " + this.FirstName + " " + this.LastName + "\n");
            return result.ToString();
        }
    }
}
