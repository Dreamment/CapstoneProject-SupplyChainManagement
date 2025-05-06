using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Invoice")]
    public class Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Invoice_ID { get; set; }

        [MaxLength(80)]
        public string Invoice_Number { get; set; }

        [MaxLength(80)]
        public string Purchase_Order_ID { get; set; }

        [MaxLength(150)]
        public string Warehouse_Name { get; set; }

        [MaxLength(40)]
        public string Gate_Name { get; set; }

        [MaxLength(80)]
        public string Invoice_Status { get; set; }

        public int Invoice_Total { get; set; }

        public DateTime Invoice_Date { get; set; }

        public DateTime Delivery_Date { get; set; }
    }

}
