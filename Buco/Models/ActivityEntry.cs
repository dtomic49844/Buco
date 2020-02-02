using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Buco.Models
{
    public class ActivityEntry
    {
        [Key]
        public int ActivityEntryId { get; set; }

        public DateTime ActivityTime { get; set; }

        [Required]
        [DisplayName("Activity duration")]
        [Range(0, 500, ErrorMessage = "Invalid duration input! Must be in range [0, 500]")]
        public int ActivityDuration { get; set; }

        [Required]
        [DisplayName("Pet")]
        public int PetId { get; set; }
        public virtual Pet Pet { get; set; }

        [Required]
        [DisplayName("Activity type")]
        public int ActivityTypeId { get; set; }
        public virtual ActivityType ActivityType { get; set; }
    }
}
