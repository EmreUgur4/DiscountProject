using DiscountProject.DTO.Interfaces;

namespace DiscountProject.DTO.Dtos
{
    public class AppUserListDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public bool IsWorkerStore { get; set; }
        public bool IsRelatedStore { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
