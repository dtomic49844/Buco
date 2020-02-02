using System.Collections.Generic;

namespace Buco.ViewModels
{
    public class WeightEntriesViewModel
    {
        public WeightEntriesViewModel()
        {
            WeightEntries = new HashSet<WeightEntryViewModel>();
        }
        public IEnumerable<WeightEntryViewModel> WeightEntries { get; set; }
        public float WeightGoal { get; set; }
    }
}
