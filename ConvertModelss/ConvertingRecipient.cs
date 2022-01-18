using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSB_PO.Invoices;

namespace WSB_PO.ConvertModelss
{
    class ConvertingRecipient : Converting<Recipient>
    {
        public override List<Recipient> ConvertDataToList()
        {
            DbAccess db = new DbAccess();
            List<Recipient> stuf = new List<Recipient>();

            var data = db.Query("Select * from Recipient");

            for (int i = 0; i < data.Rows.Count; i++)
            {

                Recipient tmp = new Recipient(
                    data.Rows[i]["Id"].ToString(),
                    data.Rows[i]["Name"].ToString(),
                    data.Rows[i]["Company"].ToString(),
                    data.Rows[i]["Address"].ToString(),
                    data.Rows[i]["City"].ToString(),
                    data.Rows[i]["Postcode"].ToString(),
                    data.Rows[i]["Discount"].ToString(),
                    data.Rows[i]["Nip"].ToString(),
                    data.Rows[i]["Phone"].ToString(),
                    data.Rows[i]["Email"].ToString(),
                    data.Rows[i]["Category"].ToString(),
                    ""
                    );

                stuf.Add(tmp);

            }
            return stuf;
        }
        public override List<Recipient> ConvertDataToList(string query)
        {
            DbAccess db = new DbAccess();
            List<Recipient> stuf = new List<Recipient>();

            var data = db.Query(query);

            for (int i = 0; i < data.Rows.Count; i++)
            {

                Recipient tmp = new Recipient(
                    data.Rows[i]["Id"].ToString(),
                    data.Rows[i]["Name"].ToString(),
                    data.Rows[i]["Company"].ToString(),
                    data.Rows[i]["Address"].ToString(),
                    data.Rows[i]["City"].ToString(),
                    data.Rows[i]["Postcode"].ToString(),
                    data.Rows[i]["Discount"].ToString(),
                    data.Rows[i]["Nip"].ToString(),
                    data.Rows[i]["Phone"].ToString(),
                    data.Rows[i]["Email"].ToString(),
                    data.Rows[i]["Category"].ToString(),
                    ""
                    );

                stuf.Add(tmp);

            }
            return stuf;
        }
    }
}
