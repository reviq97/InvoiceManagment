using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSB_PO.Interfaces
{
    interface IModifyForm
    {
        void AddProductInvoice(object sender, EventArgs e);
        void DeleteProductInvoice(object sender, EventArgs e);
    }
}
