using AutoMapper;
using Entities.DataTransferObjects.Create;
using Entities.Enums;
using Entities.Models;

namespace MVCApp.Infrastructure.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBidDTO, Bid>()
                .ForMember(dest => dest.BidId, opt => opt.Ignore())
                .ForMember(dest => dest.TenderId, opt => opt.MapFrom(src => src.TenderId))
                .ForMember(dest => dest.SupplierName, opt => opt.MapFrom(src => src.SupplierName))
                .ForMember(dest => dest.SubmittedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => BidStatus.Pending));

            CreateMap<Bid, OldBid>()
                .ForMember(dest => dest.OldBidId, opt => opt.Ignore())
                .ForMember(dest => dest.TenderId, opt => opt.MapFrom(src => src.TenderId))
                .ForMember(dest => dest.SupplierName, opt => opt.MapFrom(src => src.SupplierName))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount))
                .ForMember(dest => dest.OldStatus, opt => opt.MapFrom(src => src.Status));
        }
    }
}
