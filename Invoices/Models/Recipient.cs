using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSB_PO.Invoices
{
    public partial class Recipient
    {
        private static int _id = 0;
        private string _name;
        private string _company;
        private string _adress;
        private string _city;
        private string _postcode;
        private int _discount;
        private string _nip;
        private string _phone;
        private string _email;
        private string _category;

        public Recipient(string company, string name, string adress, 
                            string city, string postcode, int discount, string nip, 
                                string phone, string email, string category)
        {
            ++_id;
            Id = _id;
            Company = _company;
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
        public string Company
        {
            get { return _company; }
            set { _company = value; }
        }
        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }


        public string Nip
        {
            get { return _nip; }
            set { _nip = value; }
        }

        public int Discount
        {
            get { return _discount; }
            set { _discount = value; }
        }

        public string Postcode
        {
            get { return _postcode; }
            set { _postcode = value; }
        }

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        public string Adress
        {
            get { return _adress; }
            set { _adress = value; }
        }

        public string RName
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        

    }
}
