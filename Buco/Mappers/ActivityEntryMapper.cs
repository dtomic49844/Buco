using System.Collections.Generic;
using Buco.Models;
using Buco.ViewModels;

namespace Buco.Mappers
{
    public class ActivityEntryMapper : IActivityEntryMapper
    {
        public IEnumerable<ActivityEntryViewModel> MapActivityEntries(IEnumerable<ActivityEntry> activityEntries)
        {
            var activityEntriesViewModel = new HashSet<ActivityEntryViewModel>();
            foreach (var activityEntry in activityEntries)
            {
                var entry = MapActivityEntry(activityEntry);
                activityEntriesViewModel.Add(entry);
            }
            return activityEntriesViewModel;
        }

        public ActivityEntryViewModel MapActivityEntry(ActivityEntry activityEntry)
        {
            var activityEntryViewModel = new ActivityEntryViewModel
            {
                ActivityEntryId = activityEntry.ActivityEntryId,
                ActivityTime = activityEntry.ActivityTime,
                ActivityDuration = activityEntry.ActivityDuration,
                PetId = activityEntry.PetId
            };
            return activityEntryViewModel;
        }
    }
}
