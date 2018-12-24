using DiaView.WCF.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DiaView.WCF.Client
{
    public class Pramgram
    {
        public static void Main()
        {
          WcfProxy<RestfulApi> proxy = new WcfProxy<RestfulApi>("ConfigurationNameRestful");
            try
            {
                proxy.Chanel.GetData(1);
            }
            catch(FaultException ex)
            {

            }
        }
    }
}
