using System;
using DUR.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DUR.Api.Repo.Database.Configurations
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasKey(e => e.IdAppointment);
            builder.Property(e => e.IdAppointment).ValueGeneratedOnAdd().IsRequired();
            builder.Property(e => e.Deleted).HasDefaultValue(false);
            builder.Property(e => e.CreateDate).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            builder.Property(e => e.ModDate).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            builder.HasOne(e => e.Group).WithMany(b => b.Appointments).HasForeignKey(e => e.GroupId);
        }
    }
}
