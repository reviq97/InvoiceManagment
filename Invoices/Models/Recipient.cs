using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSB_PO.Invoices
{
    public partial class Recipient
    {
        private string _name;
        private string _adress;
        private string _city;
        private string _postcode;
        private int _discount;
        private string _nip;
        private string _phone;
        private string _email;
        private string _category;

        public Recipient( string name, string adress, 
                            string city, string postcode, int discount, string nip, 
                                string phone, string email, string category)
        {
            RName = name;
            Adress = adress;
            City = city;
            Postcode = postcode;
            Discount = discount;
            Nip = nip;
            Phone = phone;
            Email = email;
            Category = category;
        }
        public Recipient(string name, string adress, string city, string postcode)
        {
            RName = name;
            Adress = adress;
            City = city;
            Postcode = postcode;
        }
        public Recipient()
        {

        }
        public string Category
        {
            get { return _category; }
            private set { _category = value; }
        }

        public string Email
        {
            get { return _email; }
            private set { _email = value; }
        }

        public string Phone
        {
            get { return _phone; }
            private set { _phone = value; }
        }


        public string Nip
        {
            get { return _nip; }
            private set { _nip = value; }
        }

        public int Discount
        {
            get { return _discount; }
            private set { _discount = value; }
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

        public string RName
        {
            get { return _name; }
            private set { _name = value; }
        }
        public override int GetHashCode()
        {
            //phone * nip * postcode
            return _phone.GetHashCode() * _nip.GetHashCode() * _postcode.GetHashCode();
        }
    }
}
