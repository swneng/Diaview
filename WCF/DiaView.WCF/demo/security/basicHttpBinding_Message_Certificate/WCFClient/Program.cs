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

            //���ÿͻ���֤��
            gc.ClientCredentials.ClientCertificate.SetCertificate("CN=TestClient",
                StoreLocation.CurrentUser, StoreName.My);
            //ָ�������֤��
            gc.ClientCredentials.ServiceCertificate.SetDefaultCertificate("CN=win2008",
                StoreLocation.LocalMachine, StoreName.My);

            //����֤�����֤�����Ч��
            gc.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode =
                System.ServiceModel.Security.X509CertificateValidationMode.None;

            //ִ�д�����Get����
            string result = gc.Get(WindowsIdentity.GetCurrent().Name);
            Console.WriteLine(result);
            Console.ReadLine();
            gc.Close();
        }
    }
}
