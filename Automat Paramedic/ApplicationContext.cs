using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automat_Paramedic.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Automat_Paramedic
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<MedicineTransaction> MedicineTransaction { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<VaccinationRecord> VaccinationRecords { get; set; }



        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Указываем путь к папке проекта
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            string connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Config.UserConfig());
            modelBuilder.ApplyConfiguration(new Config.MedicalRecordConfiguration());
            modelBuilder.ApplyConfiguration(new Config.MedicineTransactionConfiguration());
            modelBuilder.ApplyConfiguration(new Config.MedicineConfiguration());
            modelBuilder.ApplyConfiguration(new Config.AppointmentConfiguration());
            modelBuilder.ApplyConfiguration(new Config.VaccinationRecordConfiguration());

        }

    }
}
