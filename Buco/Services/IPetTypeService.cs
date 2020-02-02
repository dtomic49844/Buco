using Buco.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Buco.Services
{
    public interface IPetTypeService
    {
        IEnumerable<PetType> GetAllPetTypes();

        Task<PetType> GetPetType(int petTypeId);

        Task<bool> CreatePetType(PetType petType);

        Task<bool> UpdatePetType(PetType petType);

        Task<bool> DeletePetType(int petTypeId);
    }
}
