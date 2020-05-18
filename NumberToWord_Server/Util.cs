using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToWord_Server
{
    internal static class Util
    {
        internal static string NumberToWords(int number)
        {
            if (number == 0)
                return "zero";

            var result = string.Empty;

            if (number / 1000000 > 0)
            {
                result += NumberToWords(number / 1000000) + " million ";
                number %= 1000000;
            }

            if (number / 1000 > 0)
            {
                result += NumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if (number / 100 > 0)
            {
                result += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            result = NumberToWord(number, result);

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        internal static string NumberToWord(int number, string str)
        {
            if (number == default(int)) return str;
            if (str != string.Empty)
            {
                str += " ";
            }

            var units = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            var tens = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

            if (number < 20)
            {
                str += units[number];
            }
            else
            {
                str += tens[number / 10];
                if ((number % 10) > 0)
                    str += "-" + units[number % 10];
            }
            return str;
        }
    }
}
