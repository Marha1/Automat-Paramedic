using Automat_Paramedic.Models;
using Automat_Paramedic.Primitives;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Automat_Paramedic.Repository
{
    public class MedicineRepository : BaseRepository<Medicine>
    {
        private readonly ApplicationContextFactory _contextFactory;

        public MedicineRepository()
        {
            _contextFactory = new ApplicationContextFactory();
        }

        public async Task<List<Medicine>> GetExpiredMedicinesAsync()
        {
            using var _context = _contextFactory.CreateDbContext();
            return await _context.Set<Medicine>()
                .Where(m => m.ExpirationDate <= DateTime.UtcNow)
                .ToListAsync();
        }

        public async Task<List<Medicine>> GetLowStockMedicinesAsync(int threshold = 10)
        {
            using var _context = _contextFactory.CreateDbContext();
            return await _context.Set<Medicine>()
                .Where(m => m.Quantity <= threshold)
                .ToListAsync();
        }

        public async Task<Medicine> GetByIdAsync(int id)
        {
            using var _context = _contextFactory.CreateDbContext();
            return await _context.Medicines.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddTransactionAsync(MedicineTransaction transaction)
        {
            using var _context = _contextFactory.CreateDbContext();
            await _context.Set<MedicineTransaction>().AddAsync(transaction);

            var medicine = await _context.Set<Medicine>().FindAsync(transaction.MedicineId);
            if (medicine == null)
                throw new Exception("Лекарство не найдено");

            if (transaction.Type == TransactionType.Incoming)
                medicine.Quantity += transaction.Quantity;
            else if (transaction.Type == TransactionType.Outgoing)
            {
                if (medicine.Quantity >= transaction.Quantity)
                    medicine.Quantity -= transaction.Quantity;
                else
                    throw new Exception("Недостаточно медикаментов на складе.");
            }

            await _context.SaveChangesAsync();
        }
    }
}
