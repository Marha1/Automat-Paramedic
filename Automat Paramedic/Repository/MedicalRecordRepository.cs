using Automat_Paramedic.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Automat_Paramedic.Repository
{
    public class MedicalRecordRepository : BaseRepository<MedicalRecord>
    {
        private readonly ApplicationContextFactory _contextFactory;

        public MedicalRecordRepository()
        {
            _contextFactory = new ApplicationContextFactory();
        }

        public async Task<List<MedicalRecord>> GetByFilter(string searchText)
        {
            using var _context = _contextFactory.CreateDbContext();
            return await _context.MedicalRecords
                .Where(r => r.FullName.ToLower().Contains(searchText) ||
                            r.ChronicDiseases.ToLower().Contains(searchText) ||
                            r.Allergies.ToLower().Contains(searchText) ||
                            r.Vaccinations.ToLower().Contains(searchText))
                .ToListAsync();
        }
    }
}
