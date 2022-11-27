using AutoMapper;
using DiscountProject.DTO.Dtos;
using DiscountProject.Entities.Concrete;

namespace DiscountProject.WebApi.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            #region Invoice - InvoiceDto
            CreateMap<Invoice, InvoiceListDto>().ReverseMap();
            #endregion

            #region Discount - DiscountDto
            CreateMap<Discount, DiscountListDto>().ReverseMap();
            #endregion

            #region AppUser - AppUserDto
            CreateMap<AppUser, AppUserListDto>().ReverseMap();
            #endregion
        }
    }
}
