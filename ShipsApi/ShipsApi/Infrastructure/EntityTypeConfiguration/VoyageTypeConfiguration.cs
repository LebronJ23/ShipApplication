using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShipsApi.Entities;

namespace ShipsApi.Infrastructure.EntityTypeConfiguration
{
    public class VoyageTypeConfiguration : IEntityTypeConfiguration<Voyage>
    {
        public void Configure(EntityTypeBuilder<Voyage> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Weight).IsRequired();
            builder.Property(e => e.Arrival).IsRequired();
            builder.Property(e => e.Sailed).IsRequired();
            builder.Property(e => e.ShipId).IsRequired();
            builder.Property(e => e.ProductId).IsRequired();
        }
    }
}
