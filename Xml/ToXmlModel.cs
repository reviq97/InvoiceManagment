using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WSB_PO.Invoices;

namespace WSB_PO.Xml
{
    public class ToXmlModel 
    {
        public ToXmlModel(string invoiceId, string hash, string dateTime, List<string> stuff, List<string> recipient)
        {
            InvoiceId = invoiceId;
            this.Hash = hash;
            Date = dateTime;
            Stuff = stuff;
            Recipient = recipient;
        }
        public string _invoiceId;

        public string InvoiceId
        {
            get { return _invoiceId; }
            set { _invoiceId = value; }
        }
        public string _hash;

        public string Hash
        {
            get { return _hash; }
            set { _hash = value; }
        }
        public string dateTime;
        public string Date
        {
            get { return dateTime; }
             set { dateTime = value; }
        }
        public List<string> _stuff = new List<string>();

        public List<string> Stuff
        {
            get { return _stuff; }
            set { _stuff = value; }
        }
        public List<string> _recipient = new List<string>();

        public List<string> Recipient
        {
            get { return _recipient; }
            set { _recipient = value; }
        }

        
        public ToXmlModel()
        {
            
        }
        
    }
}
