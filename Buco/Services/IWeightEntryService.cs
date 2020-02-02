using Buco.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Buco.Services
{
    public interface IWeightEntryService
    {
        Task<IEnumerable<WeightEntry>> GetWeightEntriesAsync(int petId);

        Task<IEnumerable<WeightEntry>> FilterWeightEntriesAsync(int petId, DateTime startDate, DateTime endDate);

        Task<WeightEntry> ReadWeightEntryDetailsAsync(int weightEntryId);

        Task<WeightEntry> GetLatestWeightEntryAsync(int petId);

        Task<bool> CreateWeightEntryAsync(WeightEntry weightEntry);

        Task<bool> UpdateWeightEntryAsync(WeightEntry weightEntryToUpdate);

        Task<bool> DeleteWeightEntryAsync(int weightEntryId);

        bool WeightGoalReached(WeightEntry weightEntry);

        IEnumerable<WeightEntry> GetWeightEntries();
    }
}
