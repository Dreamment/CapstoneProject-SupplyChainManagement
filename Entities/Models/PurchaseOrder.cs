using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Purchase_Order")]
    public class PurchaseOrder
    {
        [Key]
        [MaxLength(80)]
        public string Purchase_Order_ID { get; set; }

        [MaxLength(150)]
        public string User_Name { get; set; }

        [MaxLength(240)]
        public string Supplier_Name { get; set; }

        [MaxLength(80)]
        public string Purchase_Order_Status { get; set; }

        public DateTime Last_Update { get; set; }

        public DateTime Order_Date { get; set; }

        public DateTime Expected_Delivery_Date { get; set; }

        public int Total_Quantity { get; set; }

        public int Invoice_Total { get; set; }

        public string Notes { get; set; }
    }

}
