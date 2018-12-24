using DiaView.WCF.Service.Data;
using DiaView.WCF.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DiaView.WCF.Service.Service
{
    [ServiceBehavior(AddressFilterMode = AddressFilterMode.Any,ConfigurationName = "ConfigurationNameRestful",IncludeExceptionDetailInFaults =true)]
 
    public class RestfulService : RestfulApi
    {
       [OperationBehavior()]
        public RestfulData GetData(int id)
        {
            return new RestfulData() { Info = "this is demo info" };
        }
    }
}
