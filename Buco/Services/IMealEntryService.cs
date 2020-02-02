using Buco.Models;
using Buco.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Buco.Services
{
    public interface IMealEntryService
    {
        Task<IEnumerable<MealEntry>> GetMealEntriesAsync(int petId);

        Task<IEnumerable<MealEntryPerDay>> FilterMealEntriesAsync(int petId, DateTime startDate, DateTime endDate);

        Task<MealEntry> ReadMealEntryDetailsAsync(int mealEntryId);

        Task<MealEntry> GetLatestMealEntryAsync(int petId);

        Task<bool> CreateMealEntryAsync(MealEntry mealEntry);

        Task<bool> UpdateMealEntryAsync(MealEntry mealEntryToUpdate);

        Task<bool> DeleteMealEntryAsync(int mealEntryId);

        bool DailyMealGoalReached(int petId);

        IEnumerable<MealEntry> GetAllMealEntries();
    }
}
