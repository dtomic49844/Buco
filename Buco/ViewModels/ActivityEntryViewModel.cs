using System;

namespace Buco.ViewModels
{
    public class ActivityEntryViewModel
    {
        public int ActivityEntryId { get; set; }
        public DateTime ActivityTime { get; set; }
        public int ActivityDuration { get; set; }

        public int PetId { get; set; }
    }
}
