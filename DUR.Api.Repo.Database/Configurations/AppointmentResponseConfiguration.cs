using DUR.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DUR.Api.Repo.Database.Configurations
{
    public class AppointmentResponseConfiguration : IEntityTypeConfiguration<AppointmentResponse>
    {
        public void Configure(EntityTypeBuilder<AppointmentResponse> builder)
        {
            builder.HasKey(e => e.IdAppointmentResponse);
            builder.Property(e => e.IdAppointmentResponse).ValueGeneratedOnAdd().IsRequired();
            builder.Property(e => e.Deleted).HasDefaultValue(false);
            builder.Property(e => e.CreateDate).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            builder.Property(e => e.ModDate).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            builder.HasOne(e => e.Appointment).WithMany(b => b.Responses).HasForeignKey(e => e.AppointmentId);
        }
    }
}