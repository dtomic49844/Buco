using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Buco.Models
{
    public class MealEntry
    {
        [Key]
        public int MealEntryId { get; set; }

        public DateTime MealTime { get; set; }

        [Required]
        [DisplayName("Eaten calories")]
        [Range(10, 2000, ErrorMessage = "Invalid calorie input! Must be in range [10 - 2000]")]
        public int Calories { get; set; }

        [Required]
        [DisplayName("Pet")]
        public int PetId { get; set; }
        public virtual Pet Pet { get; set; }
    }
}
