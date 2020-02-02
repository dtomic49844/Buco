using Buco.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Buco.Services
{
    public interface IPetService
    {
        Task<IEnumerable<Pet>> GetPetsAsync(string userId);

        IEnumerable<Pet> GetAllPets();

        Task<Pet> ReadPetDetailsAsync(int petId);

        Task<SelectList> GetPetsSelectListAsync(string userId);

        Task<bool> CreatePetAsync(Pet pet, float weight);

        Task<bool> UpdatePetAsync(Pet petToUpdate);

        Task<bool> DeletePetAsync(int petId);

        float CalculateTargetWeight(Pet pet, float weight);

        int CalculateTargetActivity(Pet pet);

        int CalculateTargetCalories(Pet pet, float weight);

        Task<SelectList> GetPetTypesAsync();

        Task<ApplicationUser> GetPetUserAsync(string userId);

        Task<string> SavePhoto(IFormFile file, string fileName, string userId);
    }
}
