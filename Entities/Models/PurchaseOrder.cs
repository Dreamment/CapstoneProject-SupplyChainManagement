using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Purchase_Order")]
    public class PurchaseOrder
    {
        [Key]
        [MaxLength(80)]
        public string PurchaseOrderId { get; set; }

        [MaxLength(150)]
        public string Username { get; set; }

        [MaxLength(240)]
        public string SupplierName { get; set; }

        [MaxLength(80)]
        public string PurchaseOrderStatus { get; set; }

        public DateTime LastUpdate { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime ExpectedDeliveryDate { get; set; }

        public int TotalQuantity { get; set; }

        public int InvoiceTotal { get; set; }

        public string Notes { get; set; }
    }

}
