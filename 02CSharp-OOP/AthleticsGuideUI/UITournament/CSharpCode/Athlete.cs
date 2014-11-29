using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITournament.CSharpCode.FactoryMethod;

namespace UITournament.CSharpCode
{
    [Serializable]
    public class Athlete : Person, IComparable<Athlete>
    {
        private int uniqueNumber;
        private DateTime dateOfBirth;
        private Sex sex;
        private string team;
        private string results;
        private string finalResult;
        private string record;

        

       
        

        public int CompareTo(Athlete athl)
        {
            return this.UniqueNumber.CompareTo(athl.UniqueNumber);
        }

        public string Record
        {
            get { return record; }
            set { record = value; }
        }

        public string FinalResult
        {
            get { return finalResult; }
            set { finalResult = value; }
        }


        public string Results
        {
            get { return results; }
            set { results = value; }
        }


        public string Team
        {
            get { return team; }
            set { team = value; }
        }


        public Sex Sex
        {
            get { return sex; }
            set { sex = value; }
        }


        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }

        public string Age { get; set; }
        public string Position { get; set; }

        public int UniqueNumber
        {
            get { return uniqueNumber; }
            set
            {
                if (Validation.ValidateNumber(value.ToString()))
                {
                    uniqueNumber = value;
                }
                else
                {
                    throw new InvalidUniqueNumberException("The entered value is not valid! Allowed values: 0..9");
                }
            }
        }

        public Athlete(string firstName, string lastName, int uniqueNumber, DateTime dateOfBirth)
            : base(firstName, lastName)
        {
            this.UniqueNumber = uniqueNumber;
            this.DateOfBirth = dateOfBirth;
        }

        public Athlete(string firstName,
                        string lastName,
                        int uniqueNumber,
                        DateTime dateOfBirth,
                        string team,
                        string results,
                        string finalResult,
                        string record)
            : this(firstName, lastName, uniqueNumber, dateOfBirth)
        {
            this.Team = team;
            this.Results = results;
            this.FinalResult = finalResult;
            this.Record = record;
        }

        public Athlete(string firstName,
                        string lastName,
                        int uniqueNumber,
                        DateTime dateOfBirth,
                        string team,
                        string results,
                        string finalResult,
                        string record,
                        Sex sex,
                        string age,
                        string position)
            : this(firstName, lastName, uniqueNumber, dateOfBirth, team, results, finalResult, record)
        {
            this.Sex = sex;
            this.Age = age;
            this.Position = position;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("Athlete: " + this.FirstName + " " + this.LastName + "\n");
            return result.ToString();
        }


        //public override string ToString()
        //{
        //    StringBuilder result = new StringBuilder();
        //    result.Append("Athlete: " + this.FirstName + " " + this.LastName + "\n");
        //    result.Append("Gender: " + this.Gender + "\n");

        //    if (!(this.DateOfBirth == null || this.Trainer == null || this.Trainer.Team == null))
        //    {
        //        result.Append("Year of birth: " + this.DateOfBirth.Year + "\n");
        //        //result.AppendFormat("{0} years",(DateTime.Now.Year - this.DateOfBirth.Year).ToString()); just testing
        //        result.Append(this.Trainer.Team + "\n");
        //        result.Append(this.Trainer);
        //    }

        //    return result.ToString();
        //}

    }
}
