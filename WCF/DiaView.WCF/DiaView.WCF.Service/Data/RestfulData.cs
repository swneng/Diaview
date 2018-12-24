using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DiaView.WCF.Service.Data
{
    [DataContract]
    public class RestfulData
    {
        [DataMember]
        public string Info
        {
            get;set;
        }
    }
}
