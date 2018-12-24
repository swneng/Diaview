using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace WCFService
{

internal class MyServiceHost
{
    internal static ServiceHost myServiceHost = null;

    internal static void Main()
    {
        //设置BasicHttpBinding绑定
        BasicHttpBinding myBinding = new BasicHttpBinding();
        //安全模式None
        myBinding.Security.Mode = BasicHttpSecurityMode.None;

        Uri baseAddress = new Uri("http://localhost:8056/WCFService/");

        myServiceHost = new ServiceHost(typeof(GetIdentity), baseAddress);
        ServiceEndpoint myServiceEndpoint = myServiceHost.AddServiceEndpoint(typeof(IGetIdentity), myBinding, "GetIdentity");

        ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
        behavior.HttpGetEnabled = true;
        behavior.HttpGetUrl = new Uri("http://localhost:8057/mex");
        myServiceHost.Description.Behaviors.Add(behavior);

        myServiceHost.Open();
        Console.WriteLine("Service started!");
        Console.ReadLine();
        myServiceHost.Close();
    }
}
}

