using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Bids")]
    public class Bid
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BidID { get; set; }

        [Required]
        public int TenderID { get; set; }

        [Required]
        public int SupplierID { get; set; }

        [Required]
        [Column(TypeName = "decimal(15,2)")]
        public decimal Amount { get; set; }

        [Required]
        public DateTime SubmittedAt { get; set; }

        public bool IsAccepted { get; set; }

        public Tender Tender { get; set; }

        public Supplier Supplier { get; set; }
    }

}
