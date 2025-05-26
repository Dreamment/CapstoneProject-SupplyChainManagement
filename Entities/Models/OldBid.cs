using Entities.Enums;

namespace Entities.Models
{
    public class OldBid
    {

        public int OldBidId { get; set; }

        public int TenderId { get; set; }

        public string SupplierName { get; set; }

        public decimal Amount { get; set; }

        public BidStatus OldStatus { get; set; }
    }
}
