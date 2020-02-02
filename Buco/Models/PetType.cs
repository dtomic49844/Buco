using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Buco.Models
{
    public class PetType
    {
        public PetType()
        {
            Pets = new HashSet<Pet>();
        }

        [Key]
        public int PetTypeId { get; set; }
        public string PetTypeDesc { get; set; }

        /*Svaka vrsta ljubimca ima više pasmina */
        public virtual ICollection<Pet> Pets { get; set; }
    }
}
