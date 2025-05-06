using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class ActiveAcceptanceControl
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Active_Acceptance_Control_ID { get; set; }

        public int Acceptance_ID { get; set; }

        [MaxLength(40)]
        public string Barcode { get; set; }

        public int Invoice_Quantity { get; set; }

        public int Accepted_Quantity { get; set; }
    }

}
