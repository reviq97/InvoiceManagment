using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSB_PO.ConvertModelss;
using WSB_PO.Invoices;

namespace WSB_PO
{
    class ConvertingProd : Converting<Product>
    {
        public override List<Product> ConvertDataToList()
        {
            DbAccess db = new DbAccess();
            List<Product> list = new List<Product>();
            var data = db.GetProducts();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                Product tmp = new Product
                (
                    data.Rows[i]["Quantity"].ToString(),
                    data.Rows[i]["Price"].ToString(),
                    data.Rows[i]["Name"].ToString(),
                    data.Rows[i]["Tax"].ToString()

                );
                list.Add(tmp);
            }
            return list;
        }
        public override List<Product> ConvertDataToList(string query)
        {
            DbAccess db = new DbAccess();
            List<Product> list = new List<Product>();
            var data = db.Query(query);

            for (int i = 0; i < data.Rows.Count; i++)
            {
                Product tmp = new Product
                (
                    data.Rows[i]["Quantity"].ToString(),
                    data.Rows[i]["Price"].ToString(),
                    data.Rows[i]["Name"].ToString(),
                    data.Rows[i]["Tax"].ToString()

                );
                list.Add(tmp);
            }
            return list;
        }
    }
}
