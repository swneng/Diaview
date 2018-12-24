using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using DiaView.WCF.Service.Service;

namespace DiaView.WCF.Service
{
    public class Program
    {
        public static void Main()
        {
            using (ServiceHost host = new ServiceHost(typeof(RestfulService)))
            {
                host.Open();
                Console.Read();
            }
        }
    }
}
