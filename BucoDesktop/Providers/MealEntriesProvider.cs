using Buco.Data;
using Buco.Models;
using Buco.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BucoDesktop.Providers
{
    public class MealEntriesProvider
    {
        private readonly IMealEntryService _mealEntryService;
        private readonly IPetService _petService;
        private readonly int PageSize;

        public MealEntriesProvider(ApplicationDbContext dataContext)
        {
            _mealEntryService = new MealEntryService(dataContext);
            _petService = new PetService(dataContext);
            PageSize = Convert.ToInt32(ConfigurationManager.AppSettings["pageSize"]);
        }

        public IEnumerable<MealEntry> PopulateGrid(int page = 1)
        {
            return _mealEntryService.GetAllMealEntries().Skip((page - 1) * PageSize).Take(PageSize).ToArray();
        }

        public async Task<bool> CreateMealEnty(int calories, int petId)
        {
            var mealEntry = new MealEntry
            {
                Calories = calories,
                MealTime = DateTime.Now,
                PetId = petId
            };

            return await _mealEntryService.CreateMealEntryAsync(mealEntry);
        }

        public async Task<bool> UpdateMealEntry(int entryId, int calories, int petId)
        {
            var mealEntry = _mealEntryService.GetAllMealEntries().Where(e => e.MealEntryId == entryId).FirstOrDefault();
            mealEntry.PetId = petId;
            mealEntry.Calories = calories;
            return await _mealEntryService.UpdateMealEntryAsync(mealEntry);
        }

        public async Task<bool> DeleteMealEntry(int entryId)
        {
            return await _mealEntryService.DeleteMealEntryAsync(entryId);
        }

        public int GetTotalPages()
        {
            var totalItems = _mealEntryService.GetAllMealEntries().Count();
            return (int)Math.Ceiling((decimal)totalItems / (PageSize));
        }

        public int GetPet(string petName)
        {
            var pet = _petService.GetAllPets().Where(p => p.PetName == petName).FirstOrDefault();
            if (pet == null)
            {
                return 0;
            }
            return pet.PetId;
        }

        public IEnumerable<string> GetPetNames(string prefix)
        {
            var petList = new List<string>();
            var pets = _petService.GetAllPets().Where(p => p.PetName.StartsWith(prefix));
            foreach (var pet in pets)
            {
                petList.Add(pet.PetName);
            };
            return petList;

        }

        public string GetPetName(int petId)
        {
            var pet = _petService.GetAllPets().Where(p => p.PetId == petId).FirstOrDefault();
            return pet.PetName;
        }

        public IEnumerable<string> GetAllPetNames()
        {
            return _petService.GetAllPets().Select(p => p.PetName).ToArray();
        }
    }
}
