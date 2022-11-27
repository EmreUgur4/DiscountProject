using DiscountProject.Business.Interfaces;
using DiscountProject.Common.Enums;
using DiscountProject.DataAccess.Interfaces;
using DiscountProject.DTO.Dtos;
using DiscountProject.Entities.Concrete;

namespace DiscountProject.Business.Concrete
{
    public class DiscountManager : GenericManager<Discount>, IDiscountService
    {
        private readonly IGenericDal<Discount> _genericDal;

        public DiscountManager(IGenericDal<Discount> genericDal) : base(genericDal)
        {
            _genericDal = genericDal;
        }

        public async Task<Invoice> GetDiscountAsync(Invoice invoice)
        {
            if (invoice.AppUser.IsRelatedStore)
            {
                await SetGrandTotal(invoice, DiscountEnum.RelatedStoreDiscount, true);
            }
            else if (invoice.AppUser.IsWorkerStore)
            {
                await SetGrandTotal(invoice, DiscountEnum.WorkerStoreDiscount, true);
            }
            else if (invoice.AppUser.CreatedDate.AddDays(730) <= DateTime.Now)
            {
                await SetGrandTotal(invoice, DiscountEnum.CreatedDateDiscount, true);
            }
            else
            {
                await SetGrandTotal(invoice, DiscountEnum.CreatedDateDiscount, false);
            }

            return invoice;
        }

        private async Task SetGrandTotal(Invoice invoice, DiscountEnum discountEnum, bool isDiscount)
        {
            decimal newTotalPrice = 0;

            if (isDiscount)
            {
                if (!invoice.IsGrocery)
                {
                    var discount = await _genericDal.GetAsync(x => x.DiscountName == discountEnum.ToString());

                    if (discount is not null)
                    {
                        newTotalPrice = invoice.TotalPrice - (invoice.TotalPrice * discount.DiscountRate / 100);

                        invoice.DiscountId = discount.Id;
                        invoice.Discount = discount;
                    }
                }
            }
            
            var discount2 = await _genericDal.GetAsync(x => x.DiscountName == DiscountEnum.Discount.ToString());

            if(discount2 is not null)
            {
                invoice.GrandTotal = newTotalPrice != 0 ? newTotalPrice - (Convert.ToInt32(invoice.TotalPrice / 100) * 5) : invoice.TotalPrice - (Convert.ToInt32(invoice.TotalPrice / 100) * 5);
            }

            invoice.DiscountPrice = invoice.TotalPrice - invoice.GrandTotal;
        }
    }
}
