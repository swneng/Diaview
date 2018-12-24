using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.IdentityModel.Tokens;
using System.Threading;
using System.Security.Principal;

namespace WCFService
{

    internal class MyServiceHost
    {
        internal static ServiceHost myServiceHost = null;

        internal static void Main()
        {
            BasicHttpBinding myBinding = new BasicHttpBinding();
            myBinding.Security.Mode = BasicHttpSecurityMode.Message;
            myBinding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.Certificate;

            Uri baseAddress = new Uri("http://win2008:8056/WCFService/");

            myServiceHost = new ServiceHost(typeof(GetIdentity), baseAddress);
            ServiceEndpoint myServiceEndpoint = myServiceHost.AddServiceEndpoint
                (typeof(IGetIdentity), myBinding, "GetIdentity");

            //设置服务端证书
            myServiceHost.Credentials.ServiceCertificate.SetCertificate("CN=win2008");
            //设置不验证客户端证书的有效性
            myServiceHost.Credentials.ClientCertificate.Authentication.CertificateValidationMode =
                System.ServiceModel.Security.X509CertificateValidationMode.None;

            ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
            behavior.HttpGetEnabled = true;
            behavior.HttpGetUrl = new Uri("http://win2008:8057/mex");
            myServiceHost.Description.Behaviors.Add(behavior);

            myServiceHost.Open();
            Console.WriteLine("Service started!");
            Console.ReadLine();
            myServiceHost.Close();
        }
    }

}

