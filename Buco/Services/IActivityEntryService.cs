using Buco.Models;
using Buco.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Buco.Services
{
    public interface IActivityEntryService
    {
        Task<IEnumerable<ActivityEntry>> GetActivityEntriesAsync(int petId);

        Task<IEnumerable<ActivityEntryPerDay>> FilterActivityEntriesAysnc(int petId, DateTime startDate, DateTime endDate);

        Task<ActivityEntry> ReadDetailsActivityEntryAsync(int activityEntryId);

        Task<ActivityEntry> GetLatestActivityEntryAsync(int petId);

        Task<bool> CreateActivityEntryAsync(ActivityEntry activityEntry);

        Task<bool> UpdateActivityEntryAsync(ActivityEntry activityEntryToUpdate);

        Task<bool> DeleteActivityEntryAsync(int activityEntryId);

        bool DailyActivityGoalReached(int petId);

        Task<SelectList> GetActivityTypesAsync();

        IEnumerable<ActivityEntry> GetAllActivityEntries();
    }
}
