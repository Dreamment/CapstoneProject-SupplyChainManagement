using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Active_Purchase_Order_List")]
    public class ActivePurchaseOrderList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Active_Purchase_Order_List_ID { get; set; }

        [MaxLength(80)]
        public string Purchase_Order_ID { get; set; }

        [MaxLength(40)]
        public string Barcode { get; set; }

        public int Quantity { get; set; }

        public int Invoiced_Quantity { get; set; }
    }

}
