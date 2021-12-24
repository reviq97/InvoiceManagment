using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSB_PO.Invoices
{
    public partial class Products
    {
        private string _name;  
        private string _check;              
        private string _quantity; 
        private string _describe;
        private string _tax;
        private string _price;
        

        public Products()
        {

        }
        public Products(string quantity, string check, string tax, string names, string desc, string price)
        {
            Quantity = quantity;
            Check = check;
            Product = names;
            Describe = desc;
            Price = price;
            Tax = tax;
        }
        public string Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public string Describe
        {
            get { return _describe; }
            set { _describe = value; }
        }

        public string Tax
        {
            get { return _tax; }
            set { _tax = value; }
        }

        public string Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }


        public string Check
        {
            get { return _check; }
            set { _check = value; }
        }

        public string Product
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}
