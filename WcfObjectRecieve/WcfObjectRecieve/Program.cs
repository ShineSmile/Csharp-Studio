using System;
using System.ServiceModel;

namespace WcfObjectRecieve
{
    internal static class Program
    {
        private static ServiceHost _host;

        static void Main(string[] args)
        {
            using (_host = new ServiceHost(typeof(WcfService)))
            {
                _host.Open();

                Console.WriteLine("Service startup!");
                Console.Read();

            }
        }
    }
}
