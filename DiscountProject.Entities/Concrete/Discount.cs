using DiscountProject.Entities.Interfaces;

namespace DiscountProject.Entities.Concrete
{
    public class Discount : ITable
    {
        public int Id { get; set; }
        public string DiscountName { get; set; }
        public int DiscountRate { get; set; }

        public List<Invoice> Invoices { get; set; }
    }
}
