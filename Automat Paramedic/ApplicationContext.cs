using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automat_Paramedic.Models;
using Microsoft.EntityFrameworkCore;


namespace Automat_Paramedic
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<MedicineTransaction> MedicineTransaction { get; set; }
        public DbSet<Appointment> Appointments { get; set; }


                public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(@"host=localhost;port=5432;database=med;username=postgres;password=053352287");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Config.UserConfig());
            modelBuilder.ApplyConfiguration(new Config.MedicalRecordConfiguration());
            modelBuilder.ApplyConfiguration(new Config.MedicineTransactionConfiguration());
            modelBuilder.ApplyConfiguration(new Config.MedicineConfiguration());
            modelBuilder.ApplyConfiguration(new Config.AppointmentConfiguration());

        }

    }
}
