using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSB_PO.Invoices.Models
{
    public partial class Person
    {
        private string _nameAndSur;

        public string NameAndSur
        {
            get { return _nameAndSur; }
            private set { _nameAndSur = value; }
        }
        private string _phone;

        public string Phone
        {
            get { return _phone; }
            private set { _phone = value; }
        }
        private string _mail;

        public string Mail
        {
            get { return _mail; }
            private set { _mail = value; }
        }
        private string _category;

        public string Category
        {
            get { return _category; }
            private set { _category = value; }
        }
        private string _discount;

        public string Discount
        {
            get { return _discount; }
            private set { _discount = value; }
        }


        public Person(string nameAndSurname, string phone, string mail, string category, string discount)
        {
            NameAndSur = nameAndSurname;
            Phone = phone;
            Mail = mail;
            Category = category;
            Discount = discount;
        }
    }
}
