﻿using Automat_Paramedic.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Automat_Paramedic.Repository
{
    public class ApplicationContextFactory
    {
        public ApplicationContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory()) // Указываем путь к папке проекта
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .Build();

            string connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseNpgsql(connectionString);
            return new ApplicationContext(optionsBuilder.Options);
        }
    }
}
