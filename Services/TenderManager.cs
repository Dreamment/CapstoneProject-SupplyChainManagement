using Entities.DataTransferObjects.Filter;
using Entities.DataTransferObjects.Home;
using Entities.Enums;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class TenderManager : ITenderService
    {
        private readonly IRepositoryManager _repositoryManager;

        public TenderManager(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<Tender>> GetAllTenders(bool trackChanges)
            => await _repositoryManager.Tender.FindAllAsync(trackChanges);

        public async Task<Tender> GetTenderById(int id, bool trackChanges)
            => await _repositoryManager.Tender.FindByConditionAsync(
                t => t.TenderId == id, trackChanges);

        public async Task<(IEnumerable<Tender>, IEnumerable<TenderSupplier>)> GetUserTenders(User user, bool trackChanges)
        {
            var supplier = await _repositoryManager.Supplier.FindByConditionWithDetailsAsync(
                s => s.Username == user.UserName,
                trackChanges,
                s => s.TenderSuppliers);

            if (supplier == null || supplier.TenderSuppliers.Count == 0)
                return (new List<Tender>(), new List<TenderSupplier>());

            List<Tender> tenders = [];

            foreach (var tenderSupplier in supplier.TenderSuppliers)
            {
                var tender = await _repositoryManager.Tender.FindByConditionWithDetailsAsync(
                    t => t.TenderId == tenderSupplier.TenderId,
                    trackChanges,
                    t => t.Bids);
                if (tender != null)
                {
                    tenders.Add(tender);
                }
            }

            List<TenderSupplier> tenderSuppliers = [];

            foreach (var tenderSupplier in supplier.TenderSuppliers)
            {
                tenderSuppliers.Add(await _repositoryManager.TenderSupplier.FindByConditionWithDetailsAsync(
                    ts => ts.TenderId == tenderSupplier.TenderId && ts.SupplierName == supplier.SupplierName,
                    trackChanges,
                    ts => ts.Bid));
            }

            return (tenders, tenderSuppliers);
        }

        public async Task<Tender?> GetUserSpecificTender(Supplier supplier, int tenderId, bool trackChanges)
        {
            var tenderSupplier = await _repositoryManager.TenderSupplier.FindByConditionAsync(
                ts => ts.SupplierName == supplier.SupplierName && ts.TenderId == tenderId, trackChanges);
            if (tenderSupplier == null)
                return null;
            return await _repositoryManager.Tender.FindByConditionWithDetailsAsync(
                t => t.TenderId == tenderId, trackChanges, t => t.Bids);
        }

        public async Task<(IEnumerable<Tender>, IEnumerable<TenderSupplier>)> GetUserTendersFiltered(User user, TenderFilter filter, bool trackChanges)
        {
            var supplier = await _repositoryManager.Supplier.FindByConditionWithDetailsAsync(
                s => s.Username == user.UserName,
                trackChanges,
                s => s.TenderSuppliers);

            if (supplier == null || supplier.TenderSuppliers.Count == 0)
                return (new List<Tender>(), new List<TenderSupplier>());

            List<Tender> tenders = [];

            foreach (var tenderSupplier in supplier.TenderSuppliers)
            {
                if ( tenderSupplier.BidId != null)
                    tenderSupplier.Bid = await _repositoryManager.Bid.FindByConditionAsync(
                        b => b.BidId == tenderSupplier.BidId,
                        trackChanges);

                var tender = await _repositoryManager.Tender.FindByConditionWithDetailsAsync(
                    t => t.TenderId == tenderSupplier.TenderId,
                    trackChanges,
                    t => t.Bids);
                if (tender != null)
                {
                    tenders.Add(tender);
                }
            }

            List<Tender> filteredTenders = [.. tenders.Where(t =>
                (string.IsNullOrEmpty(filter.Title) || t.Title.Contains(filter.Title, StringComparison.OrdinalIgnoreCase)) &&
                (filter.CategoryIds.Count == 0 || filter.CategoryIds.Contains(t.CategoryId)) &&
                (filter.TenderStatuses.Count == 0 || filter.TenderStatuses.Contains(t.Status)) &&
                (
                    filter.BidStatuses.Count == 0 ||
                    (
                        supplier.TenderSuppliers
                            .FirstOrDefault(ts => ts.TenderId == t.TenderId)?
                            .Bid is Bid bid && filter.BidStatuses.Contains(bid.Status)
                    )
                )
            )];

            List<TenderSupplier> tenderSuppliers = [];

            foreach (var tenderSupplier in supplier.TenderSuppliers)
            {
                if (!filteredTenders.Any(t => t.TenderId == tenderSupplier.TenderId))
                    continue;

                tenderSuppliers.Add(await _repositoryManager.TenderSupplier.FindByConditionWithDetailsAsync(
                    ts => ts.TenderId == tenderSupplier.TenderId && ts.SupplierName == supplier.SupplierName,
                    trackChanges,
                    ts => ts.Bid));
            }

            return (filteredTenders, tenderSuppliers);
        }

        public async Task<(IEnumerable<Tender> Tenders, IEnumerable<TenderSupplier> TenderSuppliers, int TotalCount)> GetUserTendersFilteredPaged(
            User user, TenderFilter filter, int page, int pageSize, bool trackChanges)
        {
            var supplier = await _repositoryManager.Supplier.FindByConditionWithDetailsAsync(
                s => s.Username == user.UserName,
                trackChanges,
                s => s.TenderSuppliers);

            if (supplier == null || supplier.TenderSuppliers.Count == 0)
                return (new List<Tender>(), new List<TenderSupplier>(), 0);

            var allTenderIds = supplier.TenderSuppliers.Select(ts => ts.TenderId).ToList();

            var allTenders = new List<Tender>();
            foreach (var tenderId in allTenderIds)
            {
                var tender = await _repositoryManager.Tender.FindByConditionWithDetailsAsync(
                    t => t.TenderId == tenderId,
                    trackChanges,
                    t => t.Bids);
                if (tender != null)
                    allTenders.Add(tender);
            }

            var filteredTenders = allTenders.Where(t =>
                (string.IsNullOrEmpty(filter.Title) || t.Title.Contains(filter.Title, StringComparison.OrdinalIgnoreCase)) &&
                (filter.CategoryIds.Count == 0 || filter.CategoryIds.Contains(t.CategoryId)) &&
                (filter.TenderStatuses.Count == 0 || filter.TenderStatuses.Contains(t.Status)) &&
                (
                    filter.BidStatuses.Count == 0 ||
                    (
                        supplier.TenderSuppliers
                            .FirstOrDefault(ts => ts.TenderId == t.TenderId)?
                            .Bid is Bid bid && filter.BidStatuses.Contains(bid.Status)
                    )
                )
            ).ToList();

            int totalCount = filteredTenders.Count;

            var pagedTenders = filteredTenders
                .OrderByDescending(t => t.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var pagedTenderSuppliers = new List<TenderSupplier>();
            foreach (var tender in pagedTenders)
            {
                var tenderSupplier = await _repositoryManager.TenderSupplier.FindByConditionWithDetailsAsync(
                    ts => ts.TenderId == tender.TenderId && ts.SupplierName == supplier.SupplierName,
                    trackChanges,
                    ts => ts.Bid);
                if (tenderSupplier != null)
                    pagedTenderSuppliers.Add(tenderSupplier);
            }

            return (pagedTenders, pagedTenderSuppliers, totalCount);
        }

        public async Task<(IEnumerable<Tender> Tenders, IEnumerable<TenderSupplier> TenderSuppliers, int TotalCount)> 
            GetUserTendersFilteredSortedPaged(User user, TenderFilter filter, int page, int pageSize, TenderSortOrder tenderSortOrder, bool trackChanges)
        {
            var supplier = await _repositoryManager.Supplier.FindByConditionWithDetailsAsync(
                s => s.Username == user.UserName,
                trackChanges,
                s => s.TenderSuppliers);

            if (supplier == null || supplier.TenderSuppliers.Count == 0)
                return (Enumerable.Empty<Tender>(), Enumerable.Empty<TenderSupplier>(), 0);

            var allTenderIds = supplier.TenderSuppliers.Select(ts => ts.TenderId).ToList();

            var allTenders = (await _repositoryManager.Tender.FindAllByConditionWithDetailsAsync(
                t => allTenderIds.Contains(t.TenderId),
                trackChanges,
                t => t.Bids)).ToList();

            var supplierTenderSuppliers = await _repositoryManager.TenderSupplier.FindAllByConditionWithDetailsAsync(
                ts => ts.SupplierName == supplier.SupplierName,
                trackChanges,
                ts => ts.Bid);

            supplier.TenderSuppliers = [.. supplierTenderSuppliers];

            var tenderSupplierDict = supplier.TenderSuppliers.ToDictionary(ts => ts.TenderId);

            var filteredTenders = allTenders.Where(t =>
                (string.IsNullOrEmpty(filter.Title) || t.Title.Contains(filter.Title, StringComparison.OrdinalIgnoreCase)) &&
                (filter.CategoryIds.Count == 0 || filter.CategoryIds.Contains(t.CategoryId)) &&
                (filter.TenderStatuses.Count == 0 || filter.TenderStatuses.Contains(t.Status)) &&
                (
                    filter.BidStatuses.Count == 0 ||
                    (
                        tenderSupplierDict.TryGetValue(t.TenderId, out var ts) &&
                        ts.Bid is Bid bid && filter.BidStatuses.Contains(bid.Status)
                    )
                )
            );

            if (filter.BidStatuses.Contains(BidStatus.NotBidded))
            {
                var notBiddedTenders = allTenders.Where(t => 
                    (string.IsNullOrEmpty(filter.Title) || t.Title.Contains(filter.Title, StringComparison.OrdinalIgnoreCase)) &&
                    (filter.CategoryIds.Count == 0 || filter.CategoryIds.Contains(t.CategoryId)) &&
                    (filter.TenderStatuses.Count == 0 || filter.TenderStatuses.Contains(t.Status)) && 
                    (!tenderSupplierDict.ContainsKey(t.TenderId) || tenderSupplierDict[t.TenderId].Bid == null));
                filteredTenders = filteredTenders.Concat(notBiddedTenders).DistinctBy(t => t.TenderId);
            }

            filteredTenders = tenderSortOrder switch
            {
                TenderSortOrder.Id => filteredTenders.OrderBy(t => t.TenderId),
                TenderSortOrder.CreatedAtAsc => filteredTenders.OrderBy(t => t.CreatedAt),
                TenderSortOrder.CreatedAtDesc => filteredTenders.OrderByDescending(t => t.CreatedAt),
                TenderSortOrder.DeadlineAsc => filteredTenders.OrderBy(t => t.Deadline),
                TenderSortOrder.DeadlineDesc => filteredTenders.OrderByDescending(t => t.Deadline),
                TenderSortOrder.TitleAsc => filteredTenders.OrderBy(t => t.Title),
                TenderSortOrder.TitleDesc => filteredTenders.OrderByDescending(t => t.Title),
                _ => filteredTenders
            };

            int totalCount = filteredTenders.Count();

            var pagedTenders = filteredTenders
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var pagedTenderIds = pagedTenders.Select(t => t.TenderId).ToList();
            var pagedTenderSuppliers = (await _repositoryManager.TenderSupplier.FindAllByConditionWithDetailsAsync(
                ts => pagedTenderIds.Contains(ts.TenderId) && ts.SupplierName == supplier.SupplierName,
                trackChanges,
                ts => ts.Bid)).ToList();

            return (pagedTenders, pagedTenderSuppliers, totalCount);
        }

        public async Task<SupplierHomeGetTendersDTO> GetSupplierHomeGetTendersDTO(User user, int tenderCount, bool trackChanges)
        {
            SupplierHomeGetTendersDTO supplierHomeGetTendersDTO = new();

            Supplier supplier = await _repositoryManager.Supplier.FindByConditionWithDetailsAsync(
                s => s.Username == user.UserName, trackChanges,
                s => s.TenderSuppliers);

            List<Tender> tenders = [.. await _repositoryManager.Tender.FindAllByConditionWithDetailsAsync(
                t => supplier.TenderSuppliers.Select(ts => ts.TenderId).Contains(t.TenderId),
                trackChanges,
                t => t.Bids)];

            var notBiddedTenders = tenders.Where(t => !supplier.TenderSuppliers.Any(ts => ts.TenderId == t.TenderId && ts.Bid != null)).ToList();
            var acceptedBidTenders = tenders.Where(t => supplier.TenderSuppliers.Any(ts => ts.TenderId == t.TenderId && ts.Bid?.Status == BidStatus.Accepted)).ToList();
            var rejectedBidTenders = tenders.Where(t => supplier.TenderSuppliers.Any(ts => ts.TenderId == t.TenderId && ts.Bid?.Status == BidStatus.Rejected)).ToList();

            supplierHomeGetTendersDTO.NotBiddedTenders = [.. notBiddedTenders
                    .Where(t => t.Status == TenderStatus.Open)
                    .OrderBy(t => t.Deadline)
                    .ThenByDescending(t => t.CreatedAt)
                    .Take(tenderCount)];
            supplierHomeGetTendersDTO.AcceptedBidTenders = [.. acceptedBidTenders
                .OrderByDescending(t => t.Bids
                    .Where(b => b.Status == BidStatus.Accepted && b.SupplierName == supplier.SupplierName)
                    .Select(b => b.SubmittedAt).FirstOrDefault())
                .Take(tenderCount)];
            supplierHomeGetTendersDTO.RejectedBidTenders = [.. rejectedBidTenders
                .OrderByDescending(t => t.Bids
                    .Where(b => b.Status == BidStatus.Rejected && b.SupplierName == supplier.SupplierName)
                    .Select(b => b.SubmittedAt).FirstOrDefault())
                .Take(tenderCount)];


            return supplierHomeGetTendersDTO;
        }

        public async Task<AdminHomeGetTendersDTO> GetAdminHomeTenders()
        {
            AdminHomeGetTendersDTO adminHomeGetTendersDTO = new();
            List<Tender> allTenders = [.. await _repositoryManager.Tender.FindAllByConditionWithDetailsAsync(
                t => t.Bids.Any(),
                true,
                t => t.Bids, 
                t=> t.TenderSuppliers)];

            List<Tender> openTenders = [.. allTenders.Where(t => t.Status == TenderStatus.Open)];

            adminHomeGetTendersDTO.LastBids = [.. allTenders
                .SelectMany(t => t.Bids)
                .Where(b => b.Status == BidStatus.Pending)
                .OrderByDescending(b => b.SubmittedAt)
                .Take(10)];

            adminHomeGetTendersDTO.LastBidedTenders = [.. adminHomeGetTendersDTO.LastBids
                .Select(b => allTenders.FirstOrDefault(t => t.TenderId == b.TenderId))
                .Where(t => t != null)
                .DistinctBy(t => t.TenderId)];
            return adminHomeGetTendersDTO;
        }
    }
}
