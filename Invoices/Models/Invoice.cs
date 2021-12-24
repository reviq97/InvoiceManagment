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

        public List<Products> Stuff
        {
            get { return _stuff; }
            private set { _stuff = value; }
        }
        private Recipient _recipient;

        public Recipient Recipient
        {
            get { return _recipient; }
            set { _recipient = value; }
        }


        public Invoice(string invoiceId, int recipientId, DateTime dateTime, List<Products> stuff, Recipient recipient)
        {
            InvoiceId = invoiceId;
            RecipientId = recipientId;
            Date = dateTime;
            Stuff = stuff;
            Recipient = recipient;
        }

    }
}
