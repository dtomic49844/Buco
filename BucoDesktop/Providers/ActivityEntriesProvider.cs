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
    public class ActivityEntriesProvider
    {
        private readonly IActivityEntryService _activityEntryService;
        private readonly IPetService _petService;
        private readonly IActivityTypeService _activityTypeService;
        private readonly int PageSize;

        public ActivityEntriesProvider(ApplicationDbContext dataContext)
        {
            _activityEntryService = new ActivityEntryService(dataContext);
            _petService = new PetService(dataContext);
            _activityTypeService = new ActivityTypeService(dataContext);
            PageSize = Convert.ToInt32(ConfigurationManager.AppSettings["pageSize"]);
        }

        public IEnumerable<ActivityEntry> PopulateGrid(int page = 1)
        {
            return _activityEntryService.GetAllActivityEntries().Skip((page - 1) * PageSize).Take(PageSize).ToArray();
        }

        public async Task<bool> CreateActivityEntry(int minutes, int typeId, int petId)
        {
            var activityEntry = new ActivityEntry
            {
                ActivityDuration = minutes,
                ActivityTypeId = typeId,
                PetId = petId,
                ActivityTime = DateTime.Now
            };

            return await _activityEntryService.CreateActivityEntryAsync(activityEntry);
        }

        public async Task<bool> UpdateActivityEntry (int entryId, int minutes, int typeId, int petId)
        {
            var activityEntry = _activityEntryService.GetAllActivityEntries().Where(e => e.ActivityEntryId == entryId).FirstOrDefault();
            activityEntry.ActivityDuration = minutes;
            activityEntry.ActivityTypeId = typeId;
            activityEntry.PetId = petId;
            return await _activityEntryService.UpdateActivityEntryAsync(activityEntry);
        }

        public async Task<bool> DeleteActivityEntry(int entryId)
        {
            return await _activityEntryService.DeleteActivityEntryAsync(entryId);
        }

        public int GetTotalPages()
        {
            var totalItems = _activityEntryService.GetAllActivityEntries().Count();
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

        public IEnumerable<string> GetAllTypesDesc()
        {
            return _activityTypeService.GetAllActivityTypes().Select(t => t.ActivityTypeDesc).ToArray();
        }

        public IEnumerable<string> GetTypesDesc(string prefix)
        {
            return _activityTypeService.GetAllActivityTypes().Select(t => t.ActivityTypeDesc).Where(t => t.StartsWith(prefix)).ToArray();
        }

        public string GetTypeDesc(int typeId)
        {
            return _activityTypeService.GetAllActivityTypes().Where(t => t.ActivityTypeId == typeId).Select(t => t.ActivityTypeDesc).FirstOrDefault();
        }

        public int GetTypeId(string desc)
        {
            var id = _activityTypeService.GetAllActivityTypes().Where(t => t.ActivityTypeDesc == desc).Select(t => t.ActivityTypeId);
            if (id.Count() == 0)
            {
                return 0;
            }
            return id.FirstOrDefault();
        }
    }
}
