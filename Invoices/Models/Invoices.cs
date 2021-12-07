using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSB_PO.Invoices
{
    class Invoices
    {
        private int _invoiceId;

        public int InvoiceId
        {
            get { return _invoiceId; }
            private set { _invoiceId = value; }
        }
        private int _recipientId;

        public int RecipientId
        {
            get { return _recipientId; }
            private set { _recipientId = value; }
        }
        private DateTime dateTime;
        public DateTime Date
        {
            get { return dateTime; }
            private set { dateTime = value; }
        }
        private List<Products> _stuff;

        public List<Products> _Stuff
        {
            get { return _stuff; }
            private set { _stuff = value; }
        }
        private List<Recipient> _recipients;

        public List<Recipient> Recipient
        {
            get { return _recipients; }
            set { _recipients = value; }
        }


        public Invoices(int invoiceId, int recipientId, DateTime dateTime, List<Products> stuff, List<Recipient> recipients)
        {
            InvoiceId = invoiceId;
            RecipientId = recipientId;
            Date = dateTime;
            _Stuff = stuff;
            Recipient = _recipients;
        }

    }
}
