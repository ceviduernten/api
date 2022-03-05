using DUR.Api.Entities.Easter;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DUR.Api.Repo.Database.Configurations;

public class EasterLocationConfiguration : IEntityTypeConfiguration<HuntLocation>
{
    public void Configure(EntityTypeBuilder<HuntLocation> builder)
    {
        builder.HasKey(e => e.IdHuntLocation);
        builder.Property(e => e.IdHuntLocation).ValueGeneratedOnAdd().IsRequired();
        builder.Property(e => e.Deleted).HasDefaultValue(false);
        builder.Property(e => e.CreateDate).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
        builder.Property(e => e.ModDate).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
        builder.HasOne(e => e.HuntCity).WithMany(c => c.Locations).IsRequired();
    }
}