using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace HiTechLibrary.Validation
{
    public static class Validator
    {
        public static bool IsValidId(string input, int length)
        {
            if (!Regex.IsMatch(input, @"^\d{"+length+"}$"))
            {
                return false;
            }
            return true;
        }

        public static bool IsValidString(string input)
        {
            foreach (char i in input)
            {
                if (!Char.IsWhiteSpace(i) && !Char.IsLetter(i))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsEmpty(string input)
        {
            if (input == "")
            {
                return true;
            }
            return false;
        }
        public static bool IsValidDate(string input)
        {
            if (!Regex.IsMatch(input, @"^(0[1-9]|1[0-2])/(0[1-9]|[1-2][0-9]|3[0-1])/(20[0-2][0-9])$"))
            {
                return false;
            }
            return true;
        }

        public static bool IsValidEmail(string input)
        {
            if (!Regex.IsMatch(input, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
            {
                return false;
            }
            return true; 
        }

        public static bool IsValidPostalCode(string input)
        {
            if(!Regex.IsMatch(input, @"^[A-Z]{1}\d{1}[A-Z]{1}[- ]{0,1}\d{1}[A-Z]{1}\d{1}$"))
            {
                return false;
            }
            return true;
        }

        public static bool IsValidNumber(string input)
        {
            foreach (char i in input)
            {
                if (!Char.IsDigit(i))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsValidYear(string input)
        {
            if (!Regex.IsMatch(input, @"^(18|19|20)\d{2}$"))
            {
                return false;
            }
            return true;
        }
    }
}
