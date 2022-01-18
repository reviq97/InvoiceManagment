using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSB_PO.Invoices;
using WSB_PO.Invoices.Models;

namespace WSB_PO.ConvertModelss
{
    class ConvertingInvoices : Converting<Invoice>
    {
        public override List<Invoice> ConvertDataToList()
        {
            DbAccess db = new DbAccess();
            List<Invoice> list = new List<Invoice>();
            List<Product> products = new List<Product>();
            DataTable tmp = db.Query("SELECT * FROM Invoices");



            for (int i = 0; i < tmp.Rows.Count; i++)
            {
                Product prod = new Product(tmp.Rows[i]["Quantity"].ToString(), tmp.Rows[i]["PriceBrutto"].ToString(),
                    tmp.Rows[i]["Name"].ToString(), tmp.Rows[i]["VAT"].ToString());
                products.Add(prod);
                Recipient prn = new Recipient(tmp.Rows[i]["Name"].ToString());

                Invoice toList = new Invoice(

                    tmp.Rows[i]["InvNumber"].ToString(),
                    uint.Parse(tmp.Rows[i]["HashID"].ToString()),
                    tmp.Rows[i]["CreatedOn"].ToString(),
                    products,
                    prn
                    );
                list.Add(toList);
            }
            return list;
        }
        public override List<Invoice> ConvertDataToList(string queryToProduct, string queryToRecipient)
        {
            DbAccess db = new DbAccess();
            List<Invoice> list = new List<Invoice>();
            List<Product> products = new List<Product>();
            DataTable tmp = db.Query(queryToProduct);
            DataTable tmp2 = db.Query(queryToRecipient);
            Recipient prn2 = new Recipient();
            for (int i = 0; i < tmp2.Rows.Count; i++)
            {
               Recipient prn = new Recipient(
                    tmp2.Rows[i]["Id"].ToString(),
                    tmp2.Rows[i]["Name"].ToString(),
                    tmp2.Rows[i]["Company"].ToString(),
                    tmp2.Rows[i]["Address"].ToString(),
                    tmp2.Rows[i]["City"].ToString(),
                    tmp2.Rows[i]["Postcode"].ToString(),
                    tmp2.Rows[i]["Discount"].ToString(),
                    tmp2.Rows[i]["Nip"].ToString(),
                    tmp2.Rows[i]["Phone"].ToString(),
                    tmp2.Rows[i]["Email"].ToString(),
                    tmp2.Rows[i]["Category"].ToString(),
                    ""
                    );
                prn2 = prn;
                
            }
            for (int i = 0; i < tmp.Rows.Count; i++)
            {
                Product prod = new Product(
                    tmp.Rows[i]["Quantity"].ToString(),
                    tmp.Rows[i]["PriceBrutto"].ToString(),
                    tmp.Rows[i]["VAT"].ToString(),
                    tmp.Rows[i]["Sold"].ToString(),
                    tmp.Rows[i]["Comment"].ToString(),
                    tmp.Rows[i]["PriceNetto"].ToString()
                    );

                products.Add(prod);
                

                Invoice toList = new Invoice(

                    tmp.Rows[i]["InvNumber"].ToString(),
                    uint.Parse(tmp.Rows[i]["HashID"].ToString()),
                    tmp.Rows[i]["CreatedOn"].ToString(),
                    products,
                    prn2
                    );
                list.Add(toList);
            }
            return list;
        }
    }
}
