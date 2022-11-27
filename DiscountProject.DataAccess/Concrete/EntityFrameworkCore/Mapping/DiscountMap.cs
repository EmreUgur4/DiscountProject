using DiscountProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DiscountProject.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class DiscountMap : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.HasMany(x => x.Invoices).WithOne(x => x.Discount).HasForeignKey(x => x.DiscountId)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
