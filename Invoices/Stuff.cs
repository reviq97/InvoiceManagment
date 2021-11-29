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
