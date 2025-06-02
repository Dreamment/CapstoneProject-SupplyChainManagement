using Entities.Models;

namespace Entities.DataTransferObjects.Home
{
    public class AdminHomeGetTendersDTO
    {
        public List<Tender> LastBidedTenders { get; set; } = [];
        public List<Bid> LastBids { get; set; } = [];
    }
}
