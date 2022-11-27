using DiscountProject.Common.Models;
using DiscountProject.DTO.Dtos;
using DiscountProject.Entities.Concrete;

namespace DiscountProject.Business.Interfaces
{
    public interface IInvoiceService : IGenericService<Invoice>
    {
        Task<Response<Invoice>> GetDiscountAsync(string invoiceNo);
    }
}
