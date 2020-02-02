using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buco.Data;
using Buco.Models;
using Microsoft.EntityFrameworkCore;

namespace Buco.Services
{
    public class WeightEntryService : IWeightEntryService
    {
        private readonly ApplicationDbContext _dbContext;

        public WeightEntryService(ApplicationDbContext dataContext)
        {
            _dbContext = dataContext;
        }

        public async Task<bool> CreateWeightEntryAsync(WeightEntry weightEntry)
        {
            await _dbContext.WeightEntries.AddAsync(weightEntry);
            var created = await _dbContext.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> DeleteWeightEntryAsync(int weightEntryId)
        {
            var weightEntry = await _dbContext.WeightEntries
                                    .SingleOrDefaultAsync(e => e.WeightEntryId == weightEntryId);
            if (weightEntry == null)
            {
                return false;
            }
            _dbContext.Remove(weightEntry);
            var deleted = await _dbContext.SaveChangesAsync();
            return deleted > 0;
        }

        public async Task<IEnumerable<WeightEntry>> FilterWeightEntriesAsync(int petId, DateTime startDate, DateTime endDate)
        {
            var weightEntriesAwait = await GetWeightEntriesAsync(petId);
            var weightEntries = weightEntriesAwait.Where(e => e.WeightTime.Date <= endDate.Date).Where(e => e.WeightTime.Date >= startDate.Date);
            return weightEntries;
        }

        public async Task<WeightEntry> GetLatestWeightEntryAsync(int petId)
        {
            var weightEntries = await GetWeightEntriesAsync(petId);
            var latestEntry = weightEntries.OrderByDescending(e => e.WeightTime).FirstOrDefault();
            return latestEntry;
        }

        public IEnumerable<WeightEntry> GetWeightEntries()
        {
            return _dbContext.WeightEntries.ToList();
        }

        public async Task<IEnumerable<WeightEntry>> GetWeightEntriesAsync(int petId)
        {
            return await _dbContext.WeightEntries.Where(e => e.PetId == petId).ToArrayAsync();
        }

        public async Task<WeightEntry> ReadWeightEntryDetailsAsync(int weightEntryId)
        {
            return await _dbContext.WeightEntries.SingleOrDefaultAsync(e => e.WeightEntryId == weightEntryId);
        }

        public async Task<bool> UpdateWeightEntryAsync(WeightEntry weightEntryToUpdate)
        {
            _dbContext.WeightEntries.Update(weightEntryToUpdate);
            var updated = await _dbContext.SaveChangesAsync();
            return updated > 0;
        }

        public bool WeightGoalReached(WeightEntry weightEntry)
        {
            var pet = _dbContext.Pets.Where(p => p.PetId == weightEntry.PetId).SingleOrDefault();
            return Math.Round(weightEntry.MesuredWeight) <= Math.Round(pet.TargetWeight);
        }
    }
}
