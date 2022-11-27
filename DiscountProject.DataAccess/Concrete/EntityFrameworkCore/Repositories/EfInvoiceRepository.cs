using DiscountProject.DataAccess.Concrete.EntityFrameworkCore.Context;
using DiscountProject.DataAccess.Interfaces;
using DiscountProject.DTO.Dtos;
using DiscountProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountProject.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfInvoiceRepository : EfGenericRepository<Invoice>, IInvoiceDal
    {
        private readonly DatabaseContext _context;

        public EfInvoiceRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Invoice> GetInvoiceByInvoiceNoAsync(string invoiceNo)
        {
            return await _context.Invoices.Include(x => x.AppUser).Include(x => x.Discount).FirstOrDefaultAsync(x => x.InvoiceNo == invoiceNo);
        }
    }
}
