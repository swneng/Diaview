using System;
using System.Collections.Generic;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Text;
using System.Xml;

namespace DiaView.WCF.Framework.Explor
{
    public class WsdlExplorer
    {
        public static void  Export<T>(ServiceEndpoint endpoint,string Path)
        {
            WsdlExporter export = new WsdlExporter();
            export.ExportEndpoint(endpoint);
            export.ExportContract(endpoint.Contract);
            MetadataSet dataset = export.GetGeneratedMetadata();
            using (XmlWriter write = new XmlTextWriter(Path, Encoding.Default))
            {
                dataset.WriteTo(write);
            }
        }
       
    }
}
