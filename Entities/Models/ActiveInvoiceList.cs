using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Active_Invoice_List")]
    public class ActiveInvoiceList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Active_Invoice_List_ID { get; set; }

        public int Invoice_ID { get; set; }

        [MaxLength(40)]
        public string Barcode { get; set; }

        public int Quantity { get; set; }
    }

}
