using Buco.Models;
using Buco.ViewModels;
using System;
using System.Collections.Generic;

namespace Buco.Services
{
    public class PetMapper : IPetMapper
    {
        public PetViewModel MapPet(Pet pet)
        {
            var petViewModel = new PetViewModel(pet);
            return petViewModel;
        }

        public IEnumerable<PetViewModel> MapPets(IEnumerable<Pet> pets)
        {
            var petsViewModel = new List<PetViewModel>();
            foreach (Pet pet in pets)
            {
                var petViewModel = new PetViewModel(pet);
                petsViewModel.Add(petViewModel);
            }
            return petsViewModel;
        }
    }
}
