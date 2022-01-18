using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSB_PO.Invoices
{
    public partial class Invoice
    {
        private string _invoiceId;

        public string InvoiceId
        {
            get { return _invoiceId; }
            private set { _invoiceId = value; }
        }
        private uint _hash;

        public uint Hash
        {
            get { return _hash; }
            private set { _hash = value; }
        }
        private string dateTime;
        public string Date
        {
            get { return dateTime; }
            private set { dateTime = value; }
        }
        private List<Product> _stuff;

        public List<Product> Stuff
        {
            get { return _stuff; }
            private set { _stuff = value; }
        }
        private Recipient _recipient;

        public Recipient Recipient
        {
            get { return _recipient; }
            private set { _recipient = value; }
        }

        public Invoice()
        {

        }
        public Invoice(string invoiceId, uint hash, string dateTime, List<Product> stuff, Recipient recipient)
        {
            InvoiceId = invoiceId;
            this.Hash = hash;
            Date = dateTime;
            Stuff = stuff;
            Recipient = recipient;
        }
        public override string ToString()
        {
            return $"InvoiceID: {InvoiceId}, HashID: {Hash}";
        }
    }
}
