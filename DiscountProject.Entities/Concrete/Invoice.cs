using DiscountProject.Entities.Interfaces;

namespace DiscountProject.Entities.Concrete
{
    public class Invoice : ITable
    {
        public int Id { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public bool IsGrocery { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal DiscountPrice { get; set; }
        public decimal GrandTotal { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int? DiscountId { get; set; }
        public Discount? Discount { get; set; }
    }
}
