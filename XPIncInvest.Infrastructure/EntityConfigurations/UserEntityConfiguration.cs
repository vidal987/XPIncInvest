using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XPIncInvest.BuildingBlocks.EntityConfigurations;
using XPIncInvest.Domain.Entities.UserEntity;

namespace XPIncInvest.Infrastructure.EntityConfigurations
{
    public class UserEntityConfiguration : BaseEntityTypeConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasAlternateKey(x => x.Email);

            builder
                .Property(c => c.Name)
                .HasMaxLength(60)
                .IsRequired();

            builder
                .Property(c => c.Email)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(c => c.Role)
                .IsRequired();

            base.Configure(builder);
        }
    }
}
