using DiaView.WCF.Service.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Channels;
namespace DiaView.WCF.Service.Interface
{
    [ServiceContract]
    public interface RestfulApi
    {
        [OperationContract]
        [FaultContract(typeof(string))]
        RestfulData GetData(int id);
    }
}
