using Entities.Models;

namespace Entities.DataTransferObjects.Home
{
    public class SupplierHomeGetTendersDTO
    {
        public List<Tender> NotBiddedTenders { get; set; } = [];
        public List<Tender> AcceptedBidTenders { get; set; } = [];
        public List<Tender> RejectedBidTenders { get; set; } = [];
    }
}
