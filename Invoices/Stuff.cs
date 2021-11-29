using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSB_PO.Invoices
{
    class Stuff
    {
        private string _id;
        private string _name;
        private string _price;
        private string _quantity;

        public string Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }


        public string Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public Stuff(string id, string name)
        {
            Id = id;
            Name = name;
        }

    }
}
