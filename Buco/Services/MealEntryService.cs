using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buco.Data;
using Buco.Models;
using Buco.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Buco.Services
{
    public class MealEntryService : IMealEntryService
    {
        private readonly ApplicationDbContext _dbContext;

        public MealEntryService(ApplicationDbContext dataContext)
        {
            _dbContext = dataContext;
        }

        public async Task<bool> CreateMealEntryAsync(MealEntry mealEntry)
        {
            await _dbContext.MealEntries.AddAsync(mealEntry);
            var created = await _dbContext.SaveChangesAsync();
            return created > 0;
        }

        public bool DailyMealGoalReached(int petId)
        {
            int currentMealIntake = 0;
            var pet = _dbContext.Pets.Where(p => p.PetId == petId).SingleOrDefault();
            var mealEntries = _dbContext.MealEntries.Where(e => e.PetId == petId)
                .Where(e => e.MealTime.Date == DateTime.Now.Date);
            foreach (var entry in mealEntries)
            {
                currentMealIntake += entry.Calories;
            }
            return currentMealIntake >= pet.TargetCalories;
        }

        public async Task<bool> DeleteMealEntryAsync(int mealEntryId)
        {
            var mealEntry = await _dbContext.MealEntries
                                  .SingleOrDefaultAsync(e => e.MealEntryId == mealEntryId);
            if (mealEntry == null)
            {
                return false;
            }
            _dbContext.Remove(mealEntry);
            var deleted = await _dbContext.SaveChangesAsync();
            return deleted > 0;
        }

        public async Task<IEnumerable<MealEntryPerDay>> FilterMealEntriesAsync(int petId, DateTime startDate, DateTime endDate)
        {
            var mealEntriesAwait = await GetMealEntriesAsync(petId);
            var mealEntries = mealEntriesAwait.Where(e => e.MealTime.Date <= endDate.Date).Where(e => e.MealTime.Date >= startDate.Date);
            var entries = from entry in mealEntries group entry by entry.MealTime.Date into dateGroup
                          select new MealEntryPerDay
                          {
                              Date = dateGroup.Key,
                              CalorieSum = dateGroup.Sum(s => s.Calories)
                          };
            return entries;
        }

        public IEnumerable<MealEntry> GetAllMealEntries()
        {
            return _dbContext.MealEntries.ToList();
        }

        public async Task<MealEntry> GetLatestMealEntryAsync(int petId)
        {
            var mealEntries = await GetMealEntriesAsync(petId);
            var latestEntry = mealEntries.OrderByDescending(e => e.MealTime).FirstOrDefault();
            return latestEntry;
        }

        public async Task<IEnumerable<MealEntry>> GetMealEntriesAsync(int petId)
        {
            return await _dbContext.MealEntries.Where(e => e.PetId == petId).ToArrayAsync();
        }

        public async Task<MealEntry> ReadMealEntryDetailsAsync(int mealEntryId)
        {
            return await _dbContext.MealEntries.SingleOrDefaultAsync(e => e.MealEntryId == mealEntryId);
        }

        public async Task<bool> UpdateMealEntryAsync(MealEntry mealEntryToUpdate)
        {
            _dbContext.MealEntries.Update(mealEntryToUpdate);
            var updated = await _dbContext.SaveChangesAsync();
            return updated > 0;
        }
    }
}
