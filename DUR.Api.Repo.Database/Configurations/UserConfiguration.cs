using DUR.Api.Entities.Admin;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DUR.Api.Repo.Database.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(e => e.IdUser);
        builder.Property(e => e.IdUser).ValueGeneratedOnAdd().IsRequired();
        builder.Property(e => e.Deleted).HasDefaultValue(false);
        builder.Property(e => e.CreateDate).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
        builder.Property(e => e.ModDate).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
    }
}