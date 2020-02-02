using System;

namespace Buco.ViewModels
{
    public class MealEntryViewModel
    {
        public int MealEntryId { get; set; }
        public DateTime MealTime { get; set; }
        public int Calories { get; set; }

        public int PetId { get; set; }
    }
}
