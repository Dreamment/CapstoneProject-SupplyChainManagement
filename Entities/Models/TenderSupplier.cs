using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Entities.Models
{
    public class TenderSupplier
    {
        [Required]
        public int TenderId { get; set; }

        [Required]
        public string SupplierName { get; set; }

        [AllowNull]
        public int? BidId { get; set; }

        public Tender Tender { get; set; }

        public Supplier Supplier { get; set; }

        public Bid Bid { get; set; }
    }
}
