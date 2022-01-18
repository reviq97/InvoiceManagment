using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WSB_PO.Xml
{
    [Serializable]
    public class XmlToSerialize
    {
        public List<ToXmlModel> invoicesToXml = new List<ToXmlModel>();

        public void Serialize(List<ToXmlModel> invoice)
        {
            invoicesToXml.AddRange(invoice);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ToXmlModel>));

            using (Stream stream = new FileStream("invoice.xml", FileMode.Create, FileAccess.Write))
            {
                xmlSerializer.Serialize(stream, invoicesToXml);
            }
        }
        public XmlToSerialize()
        {

        }
    }
}
