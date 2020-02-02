using Buco.Data;
using Buco.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Buco.Services
{
    public class PetService : IPetService
    {
        private readonly ApplicationDbContext _dbContext;

        private readonly int CALORIE_BASE = 30;
        private readonly int CALORIE_CONST = 744;
        private readonly float SPAYED_CONST = 0.7f;

        private readonly int ACTIVITY_BASE = 15;
        private readonly float ACTIVITY_CONST = (25/6f);

        private readonly float[] BCS_CONST = { 1.8f, 1.5f, 1.3f, 1f, 1f, 0.8f, 0.7f, 0.6f, 0.5f };

        private readonly string PATH_BASE = "E:\\documents\\fnjer\\OO\\seminar\\Buco\\Buco\\Buco\\wwwroot\\images\\pets";

        public PetService(ApplicationDbContext dataContext)
        {
            _dbContext = dataContext;
        }

        public async Task<IEnumerable<Pet>> GetPetsAsync(string userId)
        {
            return await _dbContext.Pets.Where(p => p.UserId == userId)
                .Include(d => d.User)
                .Include(d => d.PetType)
                .Include(d => d.ActivityEntries)
                .Include(d => d.MealEntries)
                .Include(d => d.WeightEntries)
                .ToArrayAsync();
        }

        public async Task<Pet> ReadPetDetailsAsync(int petId)
        {
            return await _dbContext.Pets
                .Include(d => d.PetType)
                .SingleOrDefaultAsync(p => p.PetId == petId);
        }

        public async Task<bool> CreatePetAsync(Pet pet, float weight)
        {
            var user = await GetPetUserAsync(pet.UserId);
            pet.User = user;

            pet.TargetActivity = CalculateTargetActivity(pet);
            pet.TargetCalories = CalculateTargetCalories(pet, weight);
            pet.TargetWeight = CalculateTargetWeight(pet, weight);

            await _dbContext.Pets.AddAsync(pet);
            var created = await _dbContext.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> UpdatePetAsync(Pet petToUpdate)
        {
            _dbContext.Pets.Update(petToUpdate);
            var updated = await _dbContext.SaveChangesAsync();
            return updated > 0;
        }

        public async Task<bool> DeletePetAsync (int petId)
        {
            var pet = await _dbContext.Pets.SingleOrDefaultAsync(p => p.PetId == petId);
            if (pet == null)
            {
                return false;
            }
            _dbContext.Pets.Remove(pet);
            var deleted = await _dbContext.SaveChangesAsync();
            return deleted > 0;
        }

        public float CalculateTargetWeight(Pet pet, float weight)
        {
            var index = pet.BodyCondtionScore - 1;
            return weight * BCS_CONST[index];
        }

        public int CalculateTargetActivity(Pet pet)
        {
            var minutes = ACTIVITY_BASE + ACTIVITY_CONST * pet.ActivityLevel * pet.BodyCondtionScore;
            return Convert.ToInt32(Math.Round(minutes));
        }

        public int CalculateTargetCalories(Pet pet, float weight)
        {
            var calories = CALORIE_BASE * weight + ((CALORIE_CONST * pet.ActivityLevel) / pet.BodyCondtionScore);
            if (pet.Spayed)
            {
                calories = calories * SPAYED_CONST;
            }
            return Convert.ToInt32(Math.Round(calories));
        }

        public async Task<SelectList> GetPetsSelectListAsync(string userId)
        {
            var pets = await GetPetsAsync(userId);
            var petsSelectList = new SelectList(pets, "PetId", "PetName");
            return petsSelectList;
        }

        public async Task<SelectList> GetPetTypesAsync()
        {
            var petTypes = await _dbContext.PetTypes.ToListAsync();
            var petTypesSelectList = new SelectList(petTypes, "PetTypeId", "PetTypeDesc");
            return petTypesSelectList;
        }

        public async Task<ApplicationUser> GetPetUserAsync(string userId)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<string> SavePhoto(IFormFile file, string fileName, string userId)
        {
            var path = Path.Combine(PATH_BASE, fileName);

            using (var stream = File.Create(path))
            {
                await file.CopyToAsync(stream);
            }
            return path;
        }

        public IEnumerable<Pet> GetAllPets()
        {
            return  _dbContext.Pets.AsEnumerable();
        }
    }
}
