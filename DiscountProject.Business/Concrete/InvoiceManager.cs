using DiscountProject.Business.Interfaces;
using DiscountProject.Common.Models;
using DiscountProject.DataAccess.Interfaces;
using DiscountProject.DTO.Dtos;
using DiscountProject.Entities.Concrete;

namespace DiscountProject.Business.Concrete
{
    public class InvoiceManager : GenericManager<Invoice>, IInvoiceService
    {
        private readonly IGenericDal<Invoice> _genericDal;
        private readonly IInvoiceDal _invoiceDal;
        private readonly IDiscountService _discountService;

        public InvoiceManager(IGenericDal<Invoice> genericDal, IInvoiceDal invoiceDal, IDiscountService discountService) : base(genericDal)
        {
            _genericDal = genericDal;
            _invoiceDal = invoiceDal;
            _discountService = discountService;
        }

        public async Task<Response<Invoice>> GetDiscountAsync(string invoiceNo)
        {
            var invoice = await _invoiceDal.GetInvoiceByInvoiceNoAsync(invoiceNo);

            if(invoice is null)
            {
                return Response<Invoice>.Fail($"Invoice No: '{invoiceNo}' not found");
            }

            if (invoice.DiscountId.HasValue)
            {
                return Response<Invoice>.Success(invoice);
            }

            invoice = await _discountService.GetDiscountAsync(invoice);
            
            if(invoice.GrandTotal == 0)
            {
                return Response<Invoice>.Fail("Invoice doesn't include discount");
            }

            await _genericDal.UpdateAsync(invoice);

            return Response<Invoice>.Success(invoice);
        }
    }
}
