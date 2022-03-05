using DUR.Api.Entities.Stuff;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DUR.Api.Repo.Database.Configurations;

public class ItemConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.HasKey(e => e.IdItem);
        builder.Property(e => e.IdItem).ValueGeneratedOnAdd().IsRequired();
        builder.Property(e => e.Deleted).HasDefaultValue(false);
        builder.Property(e => e.CreateDate).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
        builder.Property(e => e.ModDate).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();

        builder.HasOne(e => e.Location).WithMany(c => c.Items).OnDelete(DeleteBehavior.SetNull);
        builder.HasOne(e => e.Box).WithMany(c => c.Items);
    }
}