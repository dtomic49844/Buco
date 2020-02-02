namespace Buco.ViewModels
{
    public class LatestEntryViewModel
    {
        public int PetId { get; set; }
        public string PetName { get; set; }
        public WeightEntryViewModel LatestWeightEntry { get; set; }
        public MealEntryViewModel LatestMealEntry { get; set; }
        public ActivityEntryViewModel LatestActivityEntry { get; set; }
    }
}
