using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Buco.Models
{
    public class ActivityType
    {
        public ActivityType()
        {
            ActivityEntries = new HashSet<ActivityEntry>();
        }

        [Key]
        public int ActivityTypeId { get; set; }
        [Required]
        public string ActivityTypeDesc { get; set; }

        public virtual ICollection<ActivityEntry> ActivityEntries { get; set; }
    }
}
