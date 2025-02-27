using Automat_Paramedic.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automat_Paramedic.Config
{
    public class MedicineConfiguration : IEntityTypeConfiguration<Medicine>
    {
        public void Configure(EntityTypeBuilder<Medicine> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Name)
                .IsRequired();

            builder.Property(m => m.Quantity)
                .IsRequired();

            builder.Property(m => m.ExpirationDate)
                .IsRequired();

            builder.Property(m => m.Description)
                .IsRequired(false);
        }
    }

}
