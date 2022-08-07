using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeightControl.Domain.Entities;

namespace WeightControl.DataAccess.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products", "dbo");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(250);
            //test
            /* builder.HasIndex(x => x.Name).IsUnique();
               builder.Property(x => x.Type).IsRequired();
               builder.Property(x => x.Unit).IsRequired();*/
        }
    }
}
