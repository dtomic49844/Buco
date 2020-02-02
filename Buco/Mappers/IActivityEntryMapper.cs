using Buco.Models;
using Buco.ViewModels;
using System.Collections.Generic;

namespace Buco.Mappers
{
    public interface IActivityEntryMapper
    {
        IEnumerable<ActivityEntryViewModel> MapActivityEntries(IEnumerable<ActivityEntry> activityEntries);
        ActivityEntryViewModel MapActivityEntry(ActivityEntry activityEntry);
    }
}
