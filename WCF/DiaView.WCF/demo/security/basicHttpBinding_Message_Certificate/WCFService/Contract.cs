using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Security.Principal;
using System.Threading;
using System.Security.Permissions;


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
    //[PrincipalPermission(SecurityAction.Demand, Role = "manager")]
    public string Get(string ClientIdentity)
    {
        IPrincipal myWindowsPrincipal = (IPrincipal)Thread.CurrentPrincipal;
        return ("Identity of server is'" + ServiceSecurityContext.Current.PrimaryIdentity.Name +
            "'\n\rIdentity of client is '" + ClientIdentity + "'");
    }
}


}
