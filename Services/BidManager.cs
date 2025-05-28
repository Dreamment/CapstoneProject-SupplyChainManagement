using AutoMapper;
using Entities.DataTransferObjects.Create;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class BidManager : IBidService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public BidManager(
            IRepositoryManager repositoryManager, 
            IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<bool> MakeABidAsync(CreateBidDTO createBidDTO, bool trackChanges)
        {
            var existingBid = await GetSpecificBidAsync(createBidDTO.TenderId, createBidDTO.SupplierName, trackChanges);
            if (existingBid is not null)
            {
                // Archive the old bid
                OldBid oldBidEntity = _mapper.Map<OldBid>(existingBid);
                await _repositoryManager.OldBid.CreateAsync(oldBidEntity);
                var originalBidId = existingBid.BidId;
                _mapper.Map(createBidDTO, existingBid);
                existingBid.BidId = originalBidId;
                await _repositoryManager.Bid.UpdateAsync(existingBid);
                await _repositoryManager.SaveAsync();
            }
            else
            {
                // Create a new bid
                var bid = _mapper.Map<Bid>(createBidDTO);
                await _repositoryManager.Bid.CreateAsync(bid);
                await _repositoryManager.SaveAsync();

                var createdBid = await _repositoryManager.Bid.FindByConditionAsync(
                    b => b.TenderId == createBidDTO.TenderId && b.SupplierName == createBidDTO.SupplierName,
                    trackChanges);

                if (createdBid is null)
                    return false;

                var tenderSupplier = await _repositoryManager.TenderSupplier.FindByConditionAsync(
                    ts => ts.TenderId == createBidDTO.TenderId && ts.SupplierName == createBidDTO.SupplierName,
                    trackChanges);

                tenderSupplier.BidId = createdBid.BidId;
                await _repositoryManager.TenderSupplier.UpdateAsync(tenderSupplier);
                await _repositoryManager.SaveAsync();
            }
            return true;
        }

        public async Task<IEnumerable<OldBid>> GetOldBidsAsync(int tenderId, string supplierName, bool trackChanges)
            => await _repositoryManager.OldBid.FindAllByConditionAsync(
                b => b.TenderId == tenderId && b.SupplierName == supplierName, trackChanges);

        public async Task<Bid> GetSpecificBidAsync(int tenderId, string supplierName, bool trackChanges)
            => await _repositoryManager.Bid.FindByConditionAsync(
                b => b.TenderId == tenderId && b.SupplierName == supplierName, trackChanges);
    }
}
