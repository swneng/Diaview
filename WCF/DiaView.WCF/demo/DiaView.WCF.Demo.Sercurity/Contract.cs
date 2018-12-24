using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Security.Principal;
using System.Threading;


namespace WCFService
{
    [ServiceContract(Namespace = "http://chnking.com")]
    public interface IGetIdentity
    {
        [OperationContract]
        string Get(string ClientIdentity);
    }
    public class GetIdentity : IGetIdentity
    {
        public string Get(string ClientIdentity)
        {
            IPrincipal myWindowsPrincipal = (IPrincipal)Thread.CurrentPrincipal;
            return ("Identity of server is'" + myWindowsPrincipal.Identity.Name +
                "'\n\rIdentity of client is '" + ClientIdentity + "'");
        }
    }


}
