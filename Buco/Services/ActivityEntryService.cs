using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buco.Data;
using Buco.Models;
using Buco.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Buco.Services
{
    public class ActivityEntryService : IActivityEntryService
    {
        private readonly ApplicationDbContext _dbContext;

        public ActivityEntryService(ApplicationDbContext dataContext)
        {
            _dbContext = dataContext;
        }

        public async Task<bool> CreateActivityEntryAsync(ActivityEntry activityEntry)
        {
            await _dbContext.ActivityEntries.AddAsync(activityEntry);
            var created = await _dbContext.SaveChangesAsync();
            return created > 0;
        }

        public bool DailyActivityGoalReached(int petId)
        {
            int currentDailyActivity = 0;
            var pet = _dbContext.Pets.Where(p => p.PetId == petId).SingleOrDefault();
            var entries = _dbContext.ActivityEntries.Where(e => e.PetId == petId)
                .Where(e => e.ActivityTime.Date == DateTime.Now.Date);
            foreach (var entry in entries)
            {
                currentDailyActivity += entry.ActivityDuration;
            }
            return currentDailyActivity >= pet.TargetActivity;
        }

        public async Task<bool> DeleteActivityEntryAsync(int activityEntryId)
        {
            var activityEntry = await _dbContext.ActivityEntries
                                                .SingleOrDefaultAsync(e => e.ActivityEntryId == activityEntryId);
            if (activityEntry == null)
            {
                return false;
            }
            _dbContext.Remove(activityEntry);
            var deleted = await _dbContext.SaveChangesAsync();
            return deleted > 0;
        }

        public async Task<IEnumerable<ActivityEntryPerDay>> FilterActivityEntriesAysnc(int petId, DateTime startDate, DateTime endDate)
        {
            var activityEntriesAwait = await GetActivityEntriesAsync(petId);
            var activityEntries = activityEntriesAwait.Where(e => e.ActivityTime.Date <= endDate.Date).Where(e => e.ActivityTime.Date >= startDate.Date);
            var entries = from entry in activityEntries
                          group entry by entry.ActivityTime.Date into dateGroup
                          select new ActivityEntryPerDay
                          {
                              Date = dateGroup.Key,
                              ActivitySum = dateGroup.Sum(s => s.ActivityDuration)
                          };
            return entries;
        }

        public async Task<IEnumerable<ActivityEntry>> GetActivityEntriesAsync(int petId)
        {
            return await _dbContext.ActivityEntries.Where(e => e.PetId == petId).ToArrayAsync();
        }

        public async Task<SelectList> GetActivityTypesAsync()
        {
            var activityTypes = await _dbContext.ActivityTypes.ToListAsync();
            var activityTypesSelectList = new SelectList(activityTypes, "ActivityTypeId", "ActivityTypeDesc");
            return activityTypesSelectList;
        }

        public IEnumerable<ActivityEntry> GetAllActivityEntries()
        {
            return _dbContext.ActivityEntries.ToArray();
        }

        public async Task<ActivityEntry> GetLatestActivityEntryAsync(int petId)
        {
            var activityEntries = await GetActivityEntriesAsync(petId);
            var latestEntry = activityEntries.OrderByDescending(e => e.ActivityTime).FirstOrDefault();
            return latestEntry;
        }

        public async Task<ActivityEntry> ReadDetailsActivityEntryAsync(int activityEntryId)
        {
            return await _dbContext.ActivityEntries.SingleOrDefaultAsync(e => e.ActivityEntryId == activityEntryId);
        }

        public async Task<bool> UpdateActivityEntryAsync(ActivityEntry activityEntryToUpdate)
        {
            _dbContext.ActivityEntries.Update(activityEntryToUpdate);
            var updated = await _dbContext.SaveChangesAsync();
            return updated > 0;
        }
    }
}
