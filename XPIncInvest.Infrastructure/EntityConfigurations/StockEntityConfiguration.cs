using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XPIncInvest.BuildingBlocks.EntityConfigurations;
using XPIncInvest.Domain.Entities.StockEntity;

namespace XPIncInvest.Infrastructure.EntityConfigurations
{
    public class StockEntityConfiguration : BaseEntityTypeConfiguration<Stock>
    {
        public override void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.ToTable("Stocks");

            builder.HasAlternateKey(x => x.Name);

            builder
                .Property(c => c.Name)
                .HasMaxLength(60)
                .IsRequired();

            builder
                .Property(c => c.Quantity)
                .IsRequired();

            builder
                .Property(c => c.DueDate)
                .IsRequired();

            builder
                .Property(c => c.Price)
                .IsRequired();

            builder
                .Property(c => c.Category)
                .IsRequired();

            builder
                .Property(c => c.IsActived)
                .IsRequired();


            base.Configure(builder);
        }
    }
}
