using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using NumberToWord_Server;

namespace NumberToWord_Host
{
    public class Program
    {
        static void Main(string[] args)
        {
            ServiceHost serviceHost = null;
            try
            {
                serviceHost = new ServiceHost(typeof(ConverterService));
                serviceHost.Open();

                Console.WriteLine("Service is started");
                Console.WriteLine("Press Any Key to Shutdown the service");
                Console.ReadKey();
                serviceHost.Close();
                serviceHost = null;
            }
            catch (Exception ex)
            {
                serviceHost = null;
                Console.WriteLine($"Service can not be started, Error : {ex.Message}");
                Console.ReadKey();
            }
        }
    }
}
