using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSB_PO.Invoices;

namespace WSB_PO.ConvertModelss
{
    internal class Converting<T>
    {
        public virtual List<T> ConvertDataToList()
        {

            return new List<T>();
        }
        public virtual List<T> ConvertDataToList(string query)
        {

            return new List<T>();
        }
        public virtual List<T> ConvertDataToList(string query, string queryTwo)
        {

            return new List<T>();
        }
    }
}
