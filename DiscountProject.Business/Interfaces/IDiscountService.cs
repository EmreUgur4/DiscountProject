using DiscountProject.Common.Models;
using DiscountProject.DTO.Dtos;
using DiscountProject.Entities.Concrete;

namespace DiscountProject.Business.Interfaces
{
    public interface IDiscountService : IGenericService<Discount>
    {
        Task<Invoice> GetDiscountAsync(Invoice invoice);
    }
}
