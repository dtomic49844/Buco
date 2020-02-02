using Buco.Models;
using Buco.ViewModels;
using System.Collections.Generic;

namespace Buco.Services
{
    public interface IPetMapper
    {
        IEnumerable<PetViewModel> MapPets(IEnumerable<Pet> pets);
        PetViewModel MapPet(Pet pet);
    }
}
