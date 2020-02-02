using System;

namespace Buco.ViewModels
{
    public class WeightEntryViewModel
    {
        public int WeightEntryId { get; set; }
        public DateTime WeightTime { get; set; }
        public float MesuredWeight { get; set; }

        public int PetId { get; set; }
    }
}
