using AutoMapper;
using Entities.DataTransferObjects.Create;
using Entities.Models;
using Repositories.Contratcs;
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

        public async Task<bool> CreateBidAsync(CreateBidDTO createBidDTO, bool trackChanges)
        {
            var bid = _mapper.Map<Bid>(createBidDTO);
            await _repositoryManager.Bid.CreateAsync(bid);
            await _repositoryManager.SaveAsync();

            var createdBid = await _repositoryManager.Bid.FindByConditionAsync(
                b => b.TenderID == createBidDTO.TenderId && b.Supplier_Name == createBidDTO.SupplierName, 
                trackChanges);

            if (createdBid is null)
                return false;

            var tenderSupplier = await _repositoryManager.TenderSupplier.FindByConditionAsync(
                ts => ts.TenderId == createBidDTO.TenderId && ts.SupplierName == createBidDTO.SupplierName, 
                trackChanges);

            tenderSupplier.BidId = createdBid.BidID;
            await _repositoryManager.TenderSupplier.UpdateAsync(tenderSupplier);
            await _repositoryManager.SaveAsync();

            var deneme = await _repositoryManager.TenderSupplier.FindByConditionAsync(
                ts => ts.TenderId == createBidDTO.TenderId && ts.SupplierName == createBidDTO.SupplierName, 
                trackChanges);

            return true;
        }
    }
}
