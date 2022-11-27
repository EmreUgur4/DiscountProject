using DiscountProject.Entities.Interfaces;

namespace DiscountProject.Entities.Concrete
{
    public class AppUser : ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public bool IsWorkerStore { get; set; }
        public bool IsRelatedStore { get; set; }
        public DateTime CreatedDate { get; set; }

        public List<Invoice> Invoices { get; set; }
    }
}
