using Buco.Data;
using Buco.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Buco.Services
{
    public class PetTypeService : IPetTypeService
    {
        private readonly ApplicationDbContext _dbContext;

        public PetTypeService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CreatePetType(PetType petType)
        {
            await _dbContext.PetTypes.AddAsync(petType);
            var created = await _dbContext.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> DeletePetType(int petTypeId)
        {
            var petType = await _dbContext.PetTypes.SingleOrDefaultAsync(t => t.PetTypeId == petTypeId);
            if (petType.PetTypeId != petTypeId)
            {
                return false;
            }
            _dbContext.Remove(petType);
            var deleted = await _dbContext.SaveChangesAsync();
            return deleted > 0;
        }

        public IEnumerable<PetType> GetAllPetTypes()
        {
            return _dbContext.PetTypes.AsEnumerable();
        }

        public async Task<PetType> GetPetType(int petTypeId)
        {
            return await _dbContext.PetTypes.SingleOrDefaultAsync(t => t.PetTypeId == petTypeId);
        }

        public async Task<bool> UpdatePetType(PetType petType)
        {
            _dbContext.PetTypes.Update(petType);
            var updated = await _dbContext.SaveChangesAsync();
            return updated > 0;
        }
    }
}
