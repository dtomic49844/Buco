using Buco.Models;
using Buco.ViewModels;
using System.Collections.Generic;

namespace Buco.Mappers
{
    public interface IMealEntryMapper
    {
        IEnumerable<MealEntryViewModel> MapMealEntries(IEnumerable<MealEntry> mealEntries);
        MealEntryViewModel MapMealEntry(MealEntry mealEntry);
    }
}
