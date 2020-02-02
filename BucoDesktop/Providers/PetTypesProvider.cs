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
    public class PetTypesProvider
    {
        private readonly IPetTypeService _petTypeService;
        private readonly int PageSize;

        public PetTypesProvider(ApplicationDbContext dataContext)
        {
            _petTypeService = new PetTypeService(dataContext);
            PageSize = Convert.ToInt32(ConfigurationManager.AppSettings["pageSize"]);
        }

        public IEnumerable<PetType> PopulateGrid(int page = 1)
        {
            return _petTypeService.GetAllPetTypes().Skip((page - 1) * PageSize).Take(PageSize).ToArray();
        }

        public async Task<bool> CreatePetType(PetType petType)
        {
            return await _petTypeService.CreatePetType(petType);
        }

        public async Task<bool> UpdatePetType(int petTypeId, string petTypeDesc)
        {
            var petType = await _petTypeService.GetPetType(petTypeId);
            petType.PetTypeDesc = petTypeDesc;
            return await _petTypeService.UpdatePetType(petType);
        }

        public async Task<bool> DeletePetType(int petTypeId)
        {
            return await _petTypeService.DeletePetType(petTypeId);
        }

        public int GetTotalPages()
        {
            var totalItems = _petTypeService.GetAllPetTypes().Count();
            return (int)Math.Ceiling((decimal)totalItems / (PageSize));
        }
    }
}
