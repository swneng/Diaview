using System;
using System.ServiceModel;
using System.Collections.Generic;
using System.Text;
using WCFClient.ServiceReference1;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;
using System.Security.Principal;
namespace WCFClient
{
    class Program
    {
        static void Main(string[] args)
        {

            BasicHttpBinding myBinding = new BasicHttpBinding();
            myBinding.Security.Mode = BasicHttpSecurityMode.None;

            EndpointAddress ea = new EndpointAddress("http://localhost:8056/WCFService/GetIdentity");

            GetIdentityClient gc = new GetIdentityClient(myBinding, ea);

            //执行代理类Get方法
            string result = gc.Get(WindowsIdentity.GetCurrent().Name);
            Console.WriteLine(result);
            Console.ReadLine();



        }
    }
}
