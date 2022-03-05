using DUR.Api.Entities.Stuff;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DUR.Api.Repo.Database.Configurations;

public class StorageLocationConfiguration : IEntityTypeConfiguration<StorageLocation>
{
    public void Configure(EntityTypeBuilder<StorageLocation> builder)
    {
        builder.HasKey(e => e.IdStorageLocation);
        builder.Property(e => e.IdStorageLocation).ValueGeneratedOnAdd().IsRequired();
        builder.Property(e => e.Deleted).HasDefaultValue(false);
        builder.Property(e => e.CreateDate).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
        builder.Property(e => e.ModDate).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
        builder.HasMany(c => c.Items).WithOne(e => e.Location);
        builder.HasMany(c => c.Boxes).WithOne(e => e.Location);
    }
}