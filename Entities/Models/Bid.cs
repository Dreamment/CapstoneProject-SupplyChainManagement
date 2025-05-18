using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Bid
    {
        public int BidId { get; set; }

        public int TenderId { get; set; }

        [Required]
        [MaxLength(240)]
        public string SupplierName { get; set; }

        [Required]
        [Column(TypeName = "decimal(15,2)")]
        public decimal Amount { get; set; }

        [Required]
        public DateTime SubmittedAt { get; set; }

        public bool IsAccepted { get; set; }

        public Tender Tender { get; set; }

        public Supplier Supplier { get; set; }

        public TenderSupplier TenderSupplier { get; set; }
    }

}
