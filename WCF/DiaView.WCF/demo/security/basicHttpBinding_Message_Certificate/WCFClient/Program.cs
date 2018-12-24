using System;
using System.ServiceModel;
using System.Collections.Generic;
using System.Text;
using WCFClient.ServiceReference1;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;
using System.Security.Principal;
using System.ServiceModel.Configuration;
using System.Security.Cryptography.X509Certificates;

namespace WCFClient
{
    class Program
    {
        static void Main(string[] args)
        {
            BasicHttpBinding myBinding = new BasicHttpBinding();
            myBinding.Security.Mode = BasicHttpSecurityMode.Message;
            myBinding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.Certificate;

            EndpointAddress ea = new EndpointAddress("http://win2008:8055/WCFService/GetIdentity");

            GetIdentityClient gc = new GetIdentityClient(myBinding, ea);

            //设置客户端证书
            gc.ClientCredentials.ClientCertificate.SetCertificate("CN=TestClient",
                StoreLocation.CurrentUser, StoreName.My);
            //指定服务端证书
            gc.ClientCredentials.ServiceCertificate.SetDefaultCertificate("CN=win2008",
                StoreLocation.LocalMachine, StoreName.My);

            //不验证服务端证书的有效性
            gc.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode =
                System.ServiceModel.Security.X509CertificateValidationMode.None;

            //执行代理类Get方法
            string result = gc.Get(WindowsIdentity.GetCurrent().Name);
            Console.WriteLine(result);
            Console.ReadLine();
            gc.Close();
        }
    }
}
