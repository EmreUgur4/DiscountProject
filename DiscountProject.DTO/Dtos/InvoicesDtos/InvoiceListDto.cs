using DiscountProject.DTO.Interfaces;

namespace DiscountProject.DTO.Dtos
{
    public class InvoiceListDto : IDto
    {
        public int Id { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public bool IsGrocery { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal DiscountPrice { get; set; }
        public decimal GrandTotal { get; set; }

        public int AppUserId { get; set; }
        public AppUserListDto AppUser { get; set; }

        public int? DiscountId { get; set; }
        public DiscountListDto Discount { get; set; }
    }
}
