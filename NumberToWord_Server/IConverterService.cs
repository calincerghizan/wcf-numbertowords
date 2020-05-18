using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace NumberToWord_Server
{
    /// <summary>
    /// The <see cref="IConverterService"/> interface
    /// </summary>
    [ServiceContract]
    public interface IConverterService
    {
        /// <summary>
        /// Converts number to words
        /// </summary>
        /// <param name="number">The number to be converted</param>
        /// <returns>The number converted to words</returns>
        [OperationContract]
        string ConvertNumberToWords(double number);
    }
}
