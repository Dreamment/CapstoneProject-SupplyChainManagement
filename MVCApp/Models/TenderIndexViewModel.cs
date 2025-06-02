using Entities.DataTransferObjects.Filter;
using Entities.Enums;
using Entities.Models;

namespace MVCApp.Models
{
    public class TenderIndexViewModel ( 
        IEnumerable<Tender> tenders, 
        IEnumerable<TenderSupplier> tenderSupplier, 
        TenderFilter tenderFilter, 
        IEnumerable<TenderCategory> tenderCategories,
        int currentPage = 1,
        int totalPages = 1,
        TenderSortOrder sortOrder = TenderSortOrder.Id,
        int pageSize = 15)
    {
        public IEnumerable<Tender> Tenders { get; set; } = tenders;
        public IEnumerable<TenderSupplier> TenderSupplier { get; set; } = tenderSupplier;
        public TenderFilter TenderFilter { get; set; } = tenderFilter;
        public IEnumerable<TenderCategory> TenderCategories { get; set; } = tenderCategories;
        public int CurrentPage { get; set; } = currentPage;
        public int TotalPages { get; set; } = totalPages;
        public TenderSortOrder SortOrder { get; set; } = sortOrder;
        public int PageSize { get; set; } = pageSize;
    }
}
