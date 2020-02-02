using Buco.Models;
using System;

namespace Buco.ViewModels
{
    public class PetViewModel
    {
        public PetViewModel(Pet pet)
        {
            PetId = pet.PetId;
            PetName = pet.PetName;
            Gender = pet.Gender;
            DOB = pet.DOB;
            Photo = pet.Photo;
            ActivityLevel = pet.ActivityLevel;
            BodyConditionScore = pet.BodyCondtionScore;
            Spayed = pet.Spayed;
            TargetActivity = pet.TargetActivity;
            TargetCalories = pet.TargetCalories;
            TargetWeight = pet.TargetWeight;
        }

        public int PetId { get; set; }
        public string PetName { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string Photo { get; set; }
        public int ActivityLevel { get; set; }
        public int BodyConditionScore { get; set; }
        public bool Spayed { get; set; }
        public string PetType { get; set; }
        public int TargetActivity { get; set; }
        public int TargetCalories { get; set; }
        public float TargetWeight { get; set; }
    }
}
