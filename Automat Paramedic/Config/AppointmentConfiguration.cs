using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Automat_Paramedic.Models;

namespace Automat_Paramedic.Config
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable("Appointments");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.FullName)
                .IsRequired();
            builder.Property(a => a.Group)
                .IsRequired();

            builder.Property(a => a.Date)
                .IsRequired();

            builder.Property(a => a.Symptoms)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(a => a.Treatment)
                .HasMaxLength(1000)
                .IsRequired();

            builder.Property(a => a.Recommendations)
                .HasMaxLength(1000)
                .IsRequired(false);

            // Связь с Medicine
            builder.HasOne(a => a.Medicine)
                .WithMany() 
                .HasForeignKey(a => a.MedicineId);
        }
    }
}
