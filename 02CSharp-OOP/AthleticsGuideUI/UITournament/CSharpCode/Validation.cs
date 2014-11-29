using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UITournament.CSharpCode
{
    public class Validation
    {
        public static bool ValidatePersonName(string name)
        {
            Regex rgxName = new Regex(@"^[A-z]+[A-z|-][A-z]+$");
            if (rgxName.IsMatch(name))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool ValidateNumber(string number)
        {
            Regex rgxNumber = new Regex(@"^[0-9]{1,6}$");
            if (rgxNumber.IsMatch(number))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool ValidateTeamName(string name)
        {
            Regex rgxName = new Regex(@"^[A-z][A-z0-9-.]+$");
            if (rgxName.IsMatch(name))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool ValidateTown(string location)
        {
            Regex rgxLocation = new Regex(@"^[A-z][A-z]+$");
            if (rgxLocation.IsMatch(location))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool ValidateTournamentName(string name)
        {
            string[] nameAsArr = name.Split(' ', '-', ',', '\"');
            string patternNumber = @"^[0-9]+$";
            string patternName = @"^[A-z]+$";
            string emptyPattern = "";

            Regex nameValid = new Regex(patternName);
            Regex numberValid = new Regex(patternNumber);
            bool res = false;

            foreach (var item in nameAsArr)
            {
                if (nameValid.IsMatch(item) || numberValid.IsMatch(item) || emptyPattern == item)
                {
                    res = true;
                }
                else
                {
                    return false;
                }
            }
            return res;
        }

        //public static bool ValidateStartDate(DateTime date)
        //{
        //    if (date.CompareTo(DateTime.Today) >= 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        public static bool ValidateEndDate(DateTime startDate, DateTime endDate)
        {
            if (startDate.CompareTo(endDate) <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
