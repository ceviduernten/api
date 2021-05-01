using DUR.Api.Entities.Stuff;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DUR.Api.Repo.Database.Configurations
{
    public class BoxConfiguration : IEntityTypeConfiguration<Box>
    {
        public void Configure(EntityTypeBuilder<Box> builder)
        {
            builder.HasKey(e => e.IdBox);
            builder.Property(e => e.IdBox).ValueGeneratedOnAdd().IsRequired();
            builder.Property(e => e.Deleted).HasDefaultValue(false);
            builder.Property(e => e.CreateDate).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            builder.Property(e => e.ModDate).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            builder.HasMany(c => c.Items).WithOne(e => e.Box);
            builder.HasOne(e => e.Location).WithMany(c => c.Boxes).IsRequired();
        }
    }
}