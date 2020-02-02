using Buco.Data;
using Buco.Models;
using Buco.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace BucoDesktop.Providers
{
    public class WeightEntriesProvider
    {
        private readonly IWeightEntryService _weightEntryService;
        private readonly IPetService _petService;
        private int PageSize;

        public WeightEntriesProvider(ApplicationDbContext dataContext)
        {
            _weightEntryService = new WeightEntryService(dataContext);
            _petService = new PetService(dataContext);
            PageSize = Convert.ToInt32(ConfigurationManager.AppSettings["pageSize"]);
        }

        public IEnumerable<WeightEntry> PopulateGrid(int page = 1)
        {
            return _weightEntryService.GetWeightEntries().Skip((page - 1) * PageSize).Take(PageSize).ToArray();
        }

        public async Task<bool> CreateWeightEntry(double weight, int petId)
        {
            var weightEntry = new WeightEntry
            {
                MesuredWeight = (float)weight,
                PetId = petId,
                WeightTime = DateTime.Now
            };

            return await _weightEntryService.CreateWeightEntryAsync(weightEntry);
        }

        public async Task<bool> UpdateWeightEntry(int entryId, double weight, int petId)
        {
            var weightEntry = _weightEntryService.GetWeightEntries().Where(e => e.WeightEntryId == entryId).First();
            weightEntry.MesuredWeight = (float)weight;
            weightEntry.PetId = petId;
            return await _weightEntryService.UpdateWeightEntryAsync(weightEntry);
        }

        public async Task<bool> DeleteWeightEntry(int entryId)
        {
            return await _weightEntryService.DeleteWeightEntryAsync(entryId);
        }

        public int GetTotalPages()
        {
            var totalItems = _weightEntryService.GetWeightEntries().Count();
            return (int)Math.Ceiling((decimal)totalItems / (PageSize));
        }

        public IEnumerable<PetSelectList> GetPetSelectList()
        {
            var selectList = new List<PetSelectList>();
            var pets = _petService.GetAllPets().ToList();
            foreach (var pet in pets)
            {
                var selectPet = new PetSelectList
                {
                    PetId = pet.PetId,
                    PetName = pet.PetName
                };
                selectList.Add(selectPet);
            }
            return selectList;
        }

        public int GetPet (string petName)
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
    }

    public class PetSelectList
    {
        public int PetId { get; set; }
        public string PetName { get; set; }
    }
}
