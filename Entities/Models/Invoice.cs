using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }

        public string InvoiceNumber { get; set; }

        public string PurchaseOrderId { get; set; }

        public string WarehouseName { get; set; }

        public string GateName { get; set; }

        public string InvoiceStatus { get; set; }

        public int InvoiceTotal { get; set; }

        public DateTime InvoiceDate { get; set; }

        public DateTime DeliveryDate { get; set; }
    }

}
