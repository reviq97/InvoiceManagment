using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSB_PO.Invoices
{
    public partial class Product
    {
        private string _name;  
        private string _check;              
        private string _quantity; 
        private string _desc;
        private string _tax;
        private string _price;
        

        public Product()
        {

        }
        public Product(string quantity, string check, string tax, string name, string desc, string price)
        {
            Quantity = quantity;
            Check = check;
            ProdName = name;
            Desc = desc;
            Price = price;
            Tax = tax;
        }
        public string Price
        {
            get { return _price; }
            private set { _price = value; }
        }

        public string Desc
        {
            get { return _desc; }
            private set { _desc = value; }
        }

        public string Tax
        {
            get { return _tax; }
            private set { _tax = value; }
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

        public string ProdName
        {
            get { return _name; }
             set { _name = value; }
        }
    }
}
