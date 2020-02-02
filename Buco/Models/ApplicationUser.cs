using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel;

namespace Buco.Models
{
    public class ApplicationUser : IdentityUser
    {
        [DisplayName("Pets")]
        public virtual ICollection<Pet> Pets { get; set; }
    }
}
