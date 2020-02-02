using Buco.InfoModels;
using System.Collections.Generic;

namespace Buco.ViewModels
{
    public class MealEntriesPerDayViewModel
    {
        public MealEntriesPerDayViewModel()
        {
            MealEntries = new HashSet<MealEntryPerDay>();
        }

        public IEnumerable<MealEntryPerDay> MealEntries { get; set; }
        public int DailyCalorieGoal { get; set; }
    }
}
