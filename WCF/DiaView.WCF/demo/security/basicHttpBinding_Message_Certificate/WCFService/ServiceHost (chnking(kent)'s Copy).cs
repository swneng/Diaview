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
            NetTcpBinding myBinding = new NetTcpBinding();
            myBinding.Security.Mode = SecurityMode.Message;
            myBinding.Security.Message.ClientCredentialType = MessageCredentialType.UserName;

            Uri baseAddress = new Uri("net.tcp://localhost:8056/WCFService/");

            myServiceHost = new ServiceHost(typeof(GetIdentity), baseAddress);
            ServiceEndpoint myServiceEndpoint = myServiceHost.AddServiceEndpoint
                (typeof(IGetIdentity), myBinding, "GetIdentity");

            //设置服务端证书
            myServiceHost.Credentials.ServiceCertificate.SetCertificate("CN=JINJZ2008, L=1720207907, OU=SharePoint, O=Microsoft");

            //设置客户端username在服务端验证模式为Custom
            myServiceHost.Credentials.UserNameAuthentication.UserNamePasswordValidationMode =
                System.ServiceModel.Security.UserNamePasswordValidationMode.Custom;
            myServiceHost.Credentials.UserNameAuthentication.CustomUserNamePasswordValidator = new customUserNamePasswordValidator();

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
    public class customUserNamePasswordValidator : System.IdentityModel.Selectors.UserNamePasswordValidator
    {
        public override void Validate(string username, string password)
        {
            if (username == "chnking" && password == "jjz666")
            {
                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity("chnking", "Custom"), new string[] { "rrr", "ttt" });
            }
            else
            {
                throw (new SecurityTokenException("用户名或密码无效！"));
            }
        }
    }
}

