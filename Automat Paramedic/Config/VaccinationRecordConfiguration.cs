using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Automat_Paramedic.Models;

namespace Automat_Paramedic.Config
{
    public class VaccinationRecordConfiguration : IEntityTypeConfiguration<VaccinationRecord>
    {
        public void Configure(EntityTypeBuilder<VaccinationRecord> builder)
        {
            builder.ToTable("VaccinationRecords");

            builder.HasKey(v => v.Id);

            builder.Property(v => v.PatientName)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(v => v.VaccineName)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(v => v.VaccinationDate)
                .IsRequired();

            builder.Property(v => v.NextVaccinationDate)
                .IsRequired();
        }
    }
}
