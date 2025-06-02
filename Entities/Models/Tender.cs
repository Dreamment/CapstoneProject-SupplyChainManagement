using Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Tender
    {
        public int TenderId { get; set; }

        public int CategoryId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ContractDetails { get; set; }

        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime Deadline { get; set; }

        public TenderStatus Status { get; set; }

        public TenderCategory Category { get; set; }

        public List<Bid> Bids { get; set; }

        public List<TenderSupplier> TenderSuppliers { get; set; }
    }
}
