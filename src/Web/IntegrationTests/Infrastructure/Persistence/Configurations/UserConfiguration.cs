using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeightControl.Domain.Entities;

namespace IntegrationTests.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", "dbo");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.HasIndex(x => x.Email).IsUnique();

            builder
                .HasMany(r => r.Roles)
                .WithMany(u => u.Users)
                .UsingEntity(j => j.ToTable("UserRoles"));
        }
    }
}
