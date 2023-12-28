using Core.Models; 
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CategoryConfig : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Category");
        builder.HasKey(x => x.ID);
        builder.Property(x => x.ID).UseIdentityColumn();
        builder.Property(x => x.Name).IsRequired().IsUnicode().HasMaxLength(255);
        builder.Property(x => x.Description).IsRequired().IsUnicode().HasMaxLength(500);
        builder.HasMany(x => x.ProductCategories).WithOne(x => x.Category);
        builder.Property(x => x.IsDeleted).IsRequired().HasDefaultValue(false);
        builder.Property(x => x.TimeDeleted).IsRequired(false);
    }
}
