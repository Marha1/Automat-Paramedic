using Automat_Paramedic.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Automat_Paramedic.Config
{
    public class MedicineTransactionConfiguration : IEntityTypeConfiguration<MedicineTransaction>
    {
        public void Configure(EntityTypeBuilder<MedicineTransaction> builder)
        {
            builder.HasKey(mt => mt.Id);

            builder.Property(mt => mt.Quantity)
                .IsRequired();

            builder.Property(mt => mt.TransactionDate)
                .IsRequired();

            builder.Property(mt => mt.Type)
                .IsRequired();

            builder.Property(mt => mt.Notes)
                .IsRequired(false);

            // Настраиваем связь с Medicine
            builder.HasOne(mt => mt.Medicine)
                .WithMany(m => m.Transactions) // Указываем, что у Medicine может быть много транзакций
                .HasForeignKey(mt => mt.MedicineId);
        }
    }
}
