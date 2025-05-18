using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class ActivePurchaseOrderList
    {
        public int ActivePurchaseOrderListId { get; set; }

        public string Purchase_Order_ID { get; set; }

        public string Barcode { get; set; }

        public int Quantity { get; set; }

        public int InvoicedQuantity { get; set; }
    }

}
