using AutoMapper;
using Entities.DataTransferObjects.Create;
using Entities.Models;

namespace MVCApp.Infrastructre.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBidDTO, Bid>()
                .ForMember(dest => dest.BidID, opt => opt.Ignore())
                .ForMember(dest => dest.TenderID, opt => opt.MapFrom(src => src.TenderId))
                .ForMember(dest => dest.Supplier_Name, opt => opt.MapFrom(src => src.SupplierName))
                .ForMember(dest => dest.SubmittedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.IsAccepted, opt => opt.MapFrom(src => false));
        }
    }
}
