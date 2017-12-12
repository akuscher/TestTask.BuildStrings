using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathServiceHost
{
    using System;
    using System.ServiceModel;


    namespace MathServiceHost
    {
        class Program
        {
            static void Main(string[] args)
            {
                ServiceHost serviceHost = null;

                try
                {
                    serviceHost = new ServiceHost(typeof(ParseLib.StringService));
                    serviceHost.Open();
                    Console.WriteLine("Service is started");
                    if (serviceHost != null)
                    {
                        Console.WriteLine("Press Any Key to Shutdown the service");
                        Console.ReadKey();
                        serviceHost.Close();
                        serviceHost = null;
                    }
                }
                catch (Exception ex)
                {
                    serviceHost = null;
                    Console.WriteLine("Service can not be started, Error :" + ex.Message);
                    Console.ReadKey();
                }

            }
        }
    }
}
