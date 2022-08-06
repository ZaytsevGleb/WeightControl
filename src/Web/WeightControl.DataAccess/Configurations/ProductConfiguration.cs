using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using WeightControl.Domain.Entities;

namespace WeightControl.DataAccess.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products", "dbo");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.HasAlternateKey(x => x.Name);
        }
    }
}
