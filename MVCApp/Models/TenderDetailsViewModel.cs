using Entities.Models;

namespace MVCApp.Models
{
    public class TenderDetailsViewModel(Tender tender, Bid? bid = null)
    {
        public Tender Tender { get; set; } = tender;
        public Bid? Bid { get; set; } = bid;
    }
}
