using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automat_Paramedic.Models;

namespace Automat_Paramedic.Config
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        
            public void Configure(EntityTypeBuilder<User> builder)
            {
                builder.HasKey(b => b.Id);
                builder.Property(b => b.Login).IsRequired();
                builder.Property(b => b.password).IsRequired();
                
            }
        
    }
}
