using Automat_Paramedic.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Automat_Paramedic.Repository
{
    public class AppointmentRepository : BaseRepository<Appointment>
    {
        private readonly ApplicationContextFactory _contextFactory;

        public AppointmentRepository()
        {
            _contextFactory = new ApplicationContextFactory();
        }

        public async Task<List<Appointment>> GetAllWithMedicineAsync()
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.Appointments
                .Include(a => a.Medicine)  // Подгружаем связанные Medicine
                .OrderBy(a => a.Date)      // Сортируем по дате
                .ToListAsync();
        }
        public async Task<Appointment?> GetByFullNameAndGroupAsync(string fullName, string group)
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.Appointments
                .Include(a => a.Medicine)
                .FirstOrDefaultAsync(a => a.FullName == fullName && a.Group == group);
        }
    }
}
