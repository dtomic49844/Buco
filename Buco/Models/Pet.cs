using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Buco.Models
{
    public class Pet
    {
        public Pet()
        {
            MealEntries = new HashSet<MealEntry>();
            WeightEntries = new HashSet<WeightEntry>();
            ActivityEntries = new HashSet<ActivityEntry>();
        }

        [Key]
        public int PetId { get; set; }

        [Required]
        [DisplayName("Pet name")]
        [MaxLength(100, ErrorMessage = "Name is too long.")]
        public string PetName { get; set; }

        [Required]
        [DisplayName("Gender")]
        [MaxLength(50, ErrorMessage = "Gender is too long.")]
        public string Gender { get; set; }

        [Required]
        [DisplayName("DOB")]
        public DateTime DOB { get; set; }

        public string Photo { get; set; }

        [Required]
        [Range(1, 3, ErrorMessage = "Invalid activity level input")]
        public int ActivityLevel { get; set; }

        [Required]
        [DisplayName("Body condition score")]
        [Range(1, 9, ErrorMessage = "Invalid BCS input")]
        public int BodyCondtionScore { get; set; }

        [Required]
        [DisplayName("Spayed")]
        public bool Spayed { get; set; }

        [DisplayName("Daily activity goal")]
        [Range(0, 500, ErrorMessage = "Activity goal is invalid! Must be in range {0, 500}")]
        public int TargetActivity { get; set; }

        [DisplayName("Daily calorie goal")]
        [Range(0, 3000, ErrorMessage = "Daily calorie goal is invalid! Must be in range {0, 3000}")]
        public int TargetCalories { get; set; }

        [DisplayName("Weight goal")]
        [Range(0, 200, ErrorMessage = "Weight goal is invalid! Must be in range {0, 200}")]
        public float TargetWeight { get; set; }

        /*Strani ključ na vlasnika ljubimca */
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        /*Strani ključ na pasminu ljubimca */

        [Required]
        [DisplayName("Pet type")]
        public int PetTypeId { get; set; }
        public virtual PetType PetType { get; set; }

        public virtual ICollection<MealEntry> MealEntries { get; set; }

        public virtual ICollection<WeightEntry> WeightEntries { get; set; }

        public virtual ICollection<ActivityEntry> ActivityEntries { get; set; }
    }
}
