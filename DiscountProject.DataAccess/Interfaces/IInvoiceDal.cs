using DiscountProject.DTO.Dtos;
using DiscountProject.Entities.Concrete;

namespace DiscountProject.DataAccess.Interfaces
{
    public interface IInvoiceDal : IGenericDal<Invoice>
    {
        Task<Invoice> GetInvoiceByInvoiceNoAsync(string invoiceNo);
    }
}
