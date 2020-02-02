using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Buco.Models
{
    public class WeightEntry
    {
        [Key]
        public int WeightEntryId { get; set; }

        public DateTime WeightTime { get; set; }

        [Required]
        [DisplayName("Mesured weight")]
        [Range(0, 300, ErrorMessage ="Inputed weight is invalid! Must be in range [0, 300]")]
        public float MesuredWeight { get; set; }

        [Required]
        [DisplayName("Pet")]
        public int PetId { get; set; }
        public virtual Pet Pet { get; set; }
    }
}
