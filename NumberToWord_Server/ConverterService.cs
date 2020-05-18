using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace NumberToWord_Server
{
    /// <summary>
    /// The implementation of <see cref="IConverterService"/> interface
    /// </summary>
    public class ConverterService : IConverterService
    {
        ///<inheritdoc/>
        public string ConvertNumberToWords(double number)
        {
            var numberBeforeComma = (int)Math.Floor(number);

            var beforeCommaString = Util.NumberToWords(numberBeforeComma);
            var afterCommaString = Util.NumberToWord((int)(((decimal)number - numberBeforeComma) * 100), string.Empty);

            var beforeCommaWords = beforeCommaString.Equals("one")
                ? $"{beforeCommaString} dollar"
                : $"{beforeCommaString} dollars";

            var afterCommaWords = afterCommaString.Equals("one")
                ? $"{afterCommaString} cent"
                : $"{afterCommaString} cents";

            return
                $"{beforeCommaWords} {(afterCommaString.Equals(string.Empty) ? string.Empty : $"and {afterCommaWords}")}";
        }

        
    }
}
