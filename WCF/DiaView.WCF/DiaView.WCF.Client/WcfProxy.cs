using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DiaView.WCF.Client
{
    public class WcfProxy<T>
    {
        public T Chanel
        {
            get;set;
        }
        public WcfProxy(string serviceName)
        {
            ChannelFactory<T> factory = new ChannelFactory<T>(serviceName);
            factory.Credentials.UserName
            Chanel = factory.CreateChannel();
        }
    }
}
