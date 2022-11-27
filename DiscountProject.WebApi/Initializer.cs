using DiscountProject.Business.Interfaces;
using DiscountProject.Entities.Concrete;
using Microsoft.AspNetCore.Identity;

namespace DiscountProject.WebApi
{
    public class Initializer
    {
        public static async Task SeedData(IAppUserService appUserService, IInvoiceService invoiceService, IDiscountService discountService)
        {
            var users = await appUserService.GetAllAsync();

            if (!users.Any())
            {
                AppUser relatedUser = new()
                {
                    Name = "relatedUser",
                    SurName = "relatedUser",
                    Email = "relatedUser@hotmail.com",
                    IsActive = true,
                    IsRelatedStore = true,
                    IsWorkerStore = false,
                    CreatedDate = DateTime.Now
                };

                AppUser workerUser = new()
                {
                    Name = "workerUser",
                    SurName = "workerUser",
                    Email = "workerUser@hotmail.com",
                    IsActive = true,
                    IsRelatedStore = false,
                    IsWorkerStore = true,
                    CreatedDate = DateTime.Now.AddDays(-10)
                };

                AppUser createdDateUser = new()
                {
                    Name = "createdDateUser",
                    SurName = "createdDateUser",
                    Email = "createdDateUser@hotmail.com",
                    IsActive = true,
                    IsRelatedStore = false,
                    IsWorkerStore = false,
                    CreatedDate = DateTime.Now.AddDays(-1000)
                };

                AppUser user = new()
                {
                    Name = "user",
                    SurName = "user",
                    Email = "user@hotmail.com",
                    IsActive = true,
                    IsRelatedStore = false,
                    IsWorkerStore = false,
                    CreatedDate = DateTime.Now
                };

                await appUserService.AddAsync(relatedUser);
                await appUserService.AddAsync(workerUser);
                await appUserService.AddAsync(createdDateUser);
                await appUserService.AddAsync(user);

                Discount workerStoreDiscount = new()
                {
                    DiscountName = "WorkerStoreDiscount",
                    DiscountRate = 30
                };

                Discount relatedStoreDiscount = new()
                {
                    DiscountName = "RelatedStoreDiscount",
                    DiscountRate = 10
                };

                Discount createdDateDiscount = new()
                {
                    DiscountName = "CreatedDateDiscount",
                    DiscountRate = 5
                };

                Discount discount = new()
                {
                    DiscountName = "Discount",
                    DiscountRate = 5
                };

                await discountService.AddAsync(workerStoreDiscount);
                await discountService.AddAsync(relatedStoreDiscount);
                await discountService.AddAsync(createdDateDiscount);
                await discountService.AddAsync(discount);

                Invoice invoice1 = new()
                {
                    AppUserId = workerUser.Id,
                    DiscountId = null,
                    DiscountPrice = 0,
                    GrandTotal = 0,
                    InvoiceDate = DateTime.Now,
                    InvoiceNo = "Inv-1",
                    IsGrocery = false,
                    TotalPrice = 1000
                };

                Invoice invoice2 = new()
                {
                    AppUserId = workerUser.Id,
                    DiscountId = null,
                    DiscountPrice = 0,
                    GrandTotal = 0,
                    InvoiceDate = DateTime.Now,
                    InvoiceNo = "Inv-2",
                    IsGrocery = true,
                    TotalPrice = 2000
                };

                Invoice invoice3 = new()
                {
                    AppUserId = relatedUser.Id,
                    DiscountId = null,
                    DiscountPrice = 0,
                    GrandTotal = 0,
                    InvoiceDate = DateTime.Now,
                    InvoiceNo = "Inv-3",
                    IsGrocery = false,
                    TotalPrice = 3000
                };

                Invoice invoice4 = new()
                {
                    AppUserId = relatedUser.Id,
                    DiscountId = null,
                    DiscountPrice = 0,
                    GrandTotal = 0,
                    InvoiceDate = DateTime.Now,
                    InvoiceNo = "Inv-4",
                    IsGrocery = true,
                    TotalPrice = 4000
                };

                Invoice invoice5 = new()
                {
                    AppUserId = createdDateUser.Id,
                    DiscountId = null,
                    DiscountPrice = 0,
                    GrandTotal = 0,
                    InvoiceDate = DateTime.Now,
                    InvoiceNo = "Inv-5",
                    IsGrocery = false,
                    TotalPrice = 5000
                };

                Invoice invoice6 = new()
                {
                    AppUserId = createdDateUser.Id,
                    DiscountId = null,
                    DiscountPrice = 0,
                    GrandTotal = 0,
                    InvoiceDate = DateTime.Now,
                    InvoiceNo = "Inv-6",
                    IsGrocery = true,
                    TotalPrice = 6000
                };

                Invoice invoice7 = new()
                {
                    AppUserId = user.Id,
                    DiscountId = null,
                    DiscountPrice = 0,
                    GrandTotal = 0,
                    InvoiceDate = DateTime.Now,
                    InvoiceNo = "Inv-7",
                    IsGrocery = false,
                    TotalPrice = 7000
                };

                Invoice invoice8 = new()
                {
                    AppUserId = user.Id,
                    DiscountId = null,
                    DiscountPrice = 0,
                    GrandTotal = 0,
                    InvoiceDate = DateTime.Now,
                    InvoiceNo = "Inv-8",
                    IsGrocery = true,
                    TotalPrice = 8000
                };

                await invoiceService.AddAsync(invoice1);
                await invoiceService.AddAsync(invoice2);
                await invoiceService.AddAsync(invoice3);
                await invoiceService.AddAsync(invoice4);
                await invoiceService.AddAsync(invoice5);
                await invoiceService.AddAsync(invoice6);
                await invoiceService.AddAsync(invoice7);
                await invoiceService.AddAsync(invoice8);
            }

        }
    }
}
