using System.Collections.Generic;

namespace Buco.ViewModels
{
    public class ActivityEntriesPerDayViewModel
    {
        public ActivityEntriesPerDayViewModel()
        {
            ActivityEntries = new HashSet<ActivityEntryPerDay>();
        }

        public IEnumerable<ActivityEntryPerDay> ActivityEntries { get; set; }
        public int ActivityGoal { get; set; }
    }
}
