using Automat_Paramedic.Models;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Automat_Paramedic.Repository
{
    public class VaccinationRepository : BaseRepository<VaccinationRecord>
    {
        private readonly ApplicationContextFactory _contextFactory;

        public VaccinationRepository()
        {
            _contextFactory = new ApplicationContextFactory();
        }
        public async Task<List<VaccinationRecord>> GetUpcomingVaccinationsAsync(int daysBefore = 7)
        {
            using var _application = _contextFactory.CreateDbContext();
            var currentDate = DateTime.Now.ToUniversalTime();
            var targetDate = currentDate.AddDays(daysBefore);

            return await _application.Set<VaccinationRecord>()
                .Where(v => v.NextVaccinationDate >= currentDate && v.NextVaccinationDate <= targetDate)
                .ToListAsync();
        }
    }
}