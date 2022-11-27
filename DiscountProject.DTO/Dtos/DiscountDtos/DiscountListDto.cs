using DiscountProject.DTO.Interfaces;

namespace DiscountProject.DTO.Dtos
{
    public class DiscountListDto : IDto
    {
        public int Id { get; set; }
        public string DiscountName { get; set; }
        public int DiscountRate { get; set; }
    }
}
