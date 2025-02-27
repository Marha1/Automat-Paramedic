using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Automat_Paramedic.Models;


namespace Automat_Paramedic.Config
{
    public class MedicalRecordConfiguration : IEntityTypeConfiguration<MedicalRecord>
    {
        public void Configure(EntityTypeBuilder<MedicalRecord> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.FullName).IsRequired();
            builder.Property(b => b.DateOfBirth).IsRequired();
            builder.Property(b => b.ChronicDiseases).IsRequired(false);
            builder.Property(b => b.Allergies).IsRequired(false);
            builder.Property(b => b.Vaccinations).IsRequired(false);
        }
    }
}
