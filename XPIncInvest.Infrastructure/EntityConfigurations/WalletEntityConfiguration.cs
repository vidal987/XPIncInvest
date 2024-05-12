

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XPIncInvest.BuildingBlocks.EntityConfigurations;
using XPIncInvest.Domain.Entities.WalletEntity;

namespace XPIncInvest.Infrastructure.EntityConfigurations
{
    public class WalletEntityConfiguration : BaseEntityTypeConfiguration<Wallet>
    {
        public override void Configure(EntityTypeBuilder<Wallet> builder)
        {

            builder.ToTable("Wallets");

            builder
                .HasMany(c => c.Stocks)
                .WithMany(c => c.Wallets)
                .UsingEntity(j => j.ToTable("WallerStock"));

            base.Configure(builder);
        }
    }
}
