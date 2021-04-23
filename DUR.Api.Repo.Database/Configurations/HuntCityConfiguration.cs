using DUR.Api.Entities.Easter;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DUR.Api.Repo.Database.Configurations
{
    public class EasterCityConfiguration : IEntityTypeConfiguration<HuntCity>
    {
        public void Configure(EntityTypeBuilder<HuntCity> builder)
        {
            builder.HasKey(e => e.IdHuntCity);
            builder.Property(e => e.IdHuntCity).ValueGeneratedOnAdd().IsRequired();
            builder.Property(e => e.Deleted).HasDefaultValue(false);
            builder.Property(e => e.CreateDate).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            builder.Property(e => e.ModDate).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            builder.HasMany(e => e.Locations).WithOne(c => c.HuntCity).IsRequired();
        }
    }
}

