using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSB_PO.Invoices.Models;

namespace WSB_PO.Invoices
{
    public partial class Recipient : Person
    {
        private string _id;
        private string _adress;
        private string _city;
        private string _postcode;
        private string _nip;
        private string _company;

        public Recipient(string name, string company, string adress,
                            string city, string postcode, string discount, string nip,
                                string phone, string email, string category) : base(name, phone, email, category, discount)
        {
            Adress = adress;
            City = city;
            Postcode = postcode;
            Nip = nip;
        }
        public Recipient(string id, string name, string company, string adress,
                            string city, string postcode, string discount, string nip,
                                string phone, string email, string category, string add) : base(name, phone, email, category, discount)
        {
            Id = id;
            Adress = adress;
            City = city;
            Postcode = postcode;
            Nip = nip;
            Company = company;
        }
        public Recipient(string name, string adress, string city, string postcode) : base(name)
        {
            Adress = adress;
            City = city;
            Postcode = postcode;
        }
        public Recipient()
        {

        }
        public Recipient(string name): base(name)
        {

        }
        public string Company
        {
            get { return _company; }
            private set { _company = value; }
        }
        public string Id
        {
            get { return _id; }
            private set { _id = value; }
        }
        public string Nip
        {
            get { return _nip; }
            private set { _nip = value; }
        }

        public string Postcode
        {
            get { return _postcode; }
            private set { _postcode = value; }
        }

        public string City
        {
            get { return _city; }
            private set { _city = value; }
        }

        public string Adress
        {
            get { return _adress; }
            private set { _adress = value; }
        }

        public override int GetHashCode()
        {
            //city * nip * postcode
            return (_city.GetHashCode() * _nip.GetHashCode() * _postcode.GetHashCode()) / 1000;
        }
    }
}
