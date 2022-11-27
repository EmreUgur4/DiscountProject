using DiscountProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DiscountProject.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class InvoiceMap : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.InvoiceNo).HasMaxLength(100).IsRequired();
            builder.HasIndex(x => x.InvoiceNo);
            builder.Property(x => x.TotalPrice).HasColumnType("decimal(18,2)");
            builder.Property(x => x.DiscountPrice).HasColumnType("decimal(18,2)");
            builder.Property(x => x.GrandTotal).HasColumnType("decimal(18,2)");
        }
    }
}
