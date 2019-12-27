using System;
using DUR.Api.Entities.Default;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DUR.Api.Repo.Database.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasKey(e => e.IdGroup);
            builder.Property(e => e.IdGroup).ValueGeneratedOnAdd().IsRequired();

            builder.ToTable("Group");
        }
    }
}
