using System.Collections.Generic;
using Buco.Models;
using Buco.ViewModels;

namespace Buco.Mappers
{
    public class MealEntryMapper : IMealEntryMapper
    {
        public IEnumerable<MealEntryViewModel> MapMealEntries(IEnumerable<MealEntry> mealEntries)
        {
            var mealEntriesViewModel = new HashSet<MealEntryViewModel>();
            foreach (var entry in mealEntries)
            {
                var mealEntry = MapMealEntry(entry);
                mealEntriesViewModel.Add(mealEntry);
            }
            return mealEntriesViewModel;
        }

        public MealEntryViewModel MapMealEntry(MealEntry mealEntry)
        {
            var mealEntryViewModel = new MealEntryViewModel
            {
                PetId = mealEntry.PetId,
                MealEntryId = mealEntry.MealEntryId,
                Calories = mealEntry.Calories,
                MealTime = mealEntry.MealTime
            };
            return mealEntryViewModel;
        }
    }
}
