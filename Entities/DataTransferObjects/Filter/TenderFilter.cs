using Entities.Enums;

namespace Entities.DataTransferObjects.Filter
{
    public class TenderFilter(string title, List<int> categoryIds, List<BidStatus> bidStatuses, List<TenderStatus> tenderStatuses)
    {
        public string Title { get; set; } = title;
        public List<int> CategoryIds { get; set; } = categoryIds;
        public List<BidStatus> BidStatuses { get; set; } = bidStatuses;
        public List<TenderStatus> TenderStatuses { get; set; } = tenderStatuses;
    }
}
