using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITournament.CSharpCode.FactoryMethod;

namespace UITournament.CSharpCode
{
    [Serializable]
    public abstract class Person : IFormattable
    {
        private string firstName;
        private string lastName;

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (Validation.ValidatePersonName(value))
                {
                    firstName = value;
                }
                else
                {
                    throw new InvalidNameException("The entered name is not valid!\nAllowed symbols are: A-Z (case insensitive) and -, starting with letter.");
                }
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (Validation.ValidatePersonName(value))
                {
                    lastName = value;
                }
                else
                {
                    throw new InvalidNameException("The entered name is not valid!\nAllowed symbols are: A-Z (case insesitive) and -, starting with letter.");
                }
            }
        }

        protected Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public virtual string ToString(string format, IFormatProvider formatProvider)
        {
            StringBuilder result = new StringBuilder();
            result.Append(this.FirstName + " " + this.LastName + "\n");
            return result.ToString();
        }
    }
}
