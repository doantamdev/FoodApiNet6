using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Configurations
{
    public class ProductsConfig : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().IsUnicode().HasMaxLength(255);
            builder.Property(x => x.Description).IsRequired().IsUnicode().HasMaxLength(500);
            builder.Property(x => x.Price).IsRequired().IsUnicode().HasMaxLength(500);
            builder.Property(x => x.IsDeleted).IsRequired().HasDefaultValue(false);
            builder.Property(x => x.TimeDeleted).IsRequired(false);
            builder.HasMany(x => x.ProductCategories).WithOne(x => x.Products).HasForeignKey(x => x.ProductID);
        }
    }
}
