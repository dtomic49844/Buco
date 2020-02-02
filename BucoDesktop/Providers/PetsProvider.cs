using Buco.Data;
using Buco.Models;
using Buco.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BucoDesktop.Providers
{
    public class PetsProvider
    {
        private readonly IPetService _petService;
        private readonly IAppUserService _appUserService;
        private readonly IPetTypeService _petTypeService;
        private readonly int PageSize;
        private readonly string PATH_BASE = "E:\\documents\\fnjer\\OO\\seminar\\Buco\\Buco\\Buco\\wwwroot\\images\\pets";

        public PetsProvider(ApplicationDbContext dataContext)
        {
            _petService = new PetService(dataContext);
            _appUserService = new AppUserService(dataContext);
            _petTypeService = new PetTypeService(dataContext);
            PageSize = Convert.ToInt32(ConfigurationManager.AppSettings["pageSize"]);
        }

        public IEnumerable<Pet> PopulateGrid(int page = 1)
        {
            return _petService.GetAllPets().Skip((page - 1) * PageSize).Take(PageSize).ToArray();
        }

        public async Task<bool> CreatePet(string name, string gender, string DOB, string photo, int activityLevel, int BCS, string spayed, string userId, int typeId, float weight)
        {
            string imageName;
            if (photo != "None")
            {
                imageName = photo.Split("\\").Last();
            }
            else
            {
                imageName = null;
            }

            bool isSpayed;
            if (spayed == "YES")
            {
                isSpayed = true;
            }
            else
            {
                isSpayed = false;
            }

            var pet = new Pet
            {
                PetName = name,
                Gender = gender,
                DOB = Convert.ToDateTime(DOB),
                Photo = imageName,
                ActivityLevel = activityLevel,
                BodyCondtionScore = BCS,
                Spayed = isSpayed,
                UserId = userId,
                PetTypeId = typeId,
            };

            if (imageName != null)
            {
                SavePhoto(photo);
            }

            return await _petService.CreatePetAsync(pet, weight);
        }

        public void SavePhoto(string pathName)
        {
            var imageName = pathName.Split("\\").Last();

            int bufferSize = 1024 * 1024;
            var outputFilePath = Path.Combine(PATH_BASE, imageName);

            using (FileStream fileStream = new FileStream(outputFilePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
            {
                FileStream fs = new FileStream(pathName, FileMode.Open, FileAccess.ReadWrite);
                fileStream.SetLength(fs.Length);
                int bytesRead = -1;
                byte[] bytes = new byte[bufferSize];

                while ((bytesRead = fs.Read(bytes, 0, bufferSize)) > 0)
                {
                    fileStream.Write(bytes, 0, bytesRead);
                }

            }
        }

        public async Task<bool> UpdatePet(int petId, string name, string gender, string DOB, string photo, 
            int activityLevel, int BCS, string spayed, string userId, int typeId, int targetActivity, 
            double targetWeight, int targetCalories)
        {
            bool isSpayed;
            if (spayed == "YES")
            {
                isSpayed = true;
            }
            else
            {
                isSpayed = false;
            }

            var pet = _petService.GetAllPets().Where(p => p.PetId == petId).FirstOrDefault();
            var oldFile = pet.Photo;

            pet.PetName = name;
            pet.Gender = gender;
            pet.DOB = Convert.ToDateTime(DOB);
            pet.Photo = photo;
            pet.ActivityLevel = activityLevel;
            pet.BodyCondtionScore = BCS;
            pet.Spayed = isSpayed;
            pet.UserId = userId;
            pet.PetTypeId = typeId;
            pet.TargetActivity = targetActivity;
            pet.TargetCalories = targetCalories;
            pet.TargetWeight = (float)targetWeight;

            if (pet.Photo != oldFile)
            {
                SavePhoto(photo);
            }

            return await _petService.UpdatePetAsync(pet);
        }

        public async Task<bool> DeletePet(int petId)
        {
            return await _petService.DeletePetAsync(petId);
        }

        public int GetTotalPages()
        {
            var totalItems = _petService.GetAllPets().Count();
            return (int)Math.Ceiling((decimal)totalItems / (PageSize));
        }

        // Metode za dohvaćanje podataka o tipovima ljubimca
        // Naziv tipa prema ID-ju
        public string GetTypeDesc(int typeId)
        {
            return _petTypeService.GetAllPetTypes().Where(t => t.PetTypeId == typeId).Select(t => t.PetTypeDesc).FirstOrDefault();
        }

        //ID tipa prema nazivu
        public int GetTypeId(string desc)
        {
            var type = _petTypeService.GetAllPetTypes().Where(t => t.PetTypeDesc == desc).SingleOrDefault();
            if (type == null)
            {
                return 0;
            }
            return type.PetTypeId;
        }

        // Popis svih opisa tipva ljubimca

        public IEnumerable<string> GetAllTypeDesc()
        {
            return _petTypeService.GetAllPetTypes().Select(t => t.PetTypeDesc);
        }

        // Metode za dohvaćanje podataka o korisnicima
        // E-mail korisnika prema ID-ju
        public string GetUserEmail(string userId)
        {
            return _appUserService.GetAllUsers().Where(u => u.Id == userId).Select(t => t.Email).FirstOrDefault();
        }

        // ID prema E-mailu
        public string GetUserId(string email)
        {
            var user = _appUserService.GetAllUsers().Where(u => u.Email == email).FirstOrDefault();
            if (user == null)
            {
                return "None";
            }
            else
            {
                return user.Id;
            }
        }

        // Popis svih e-mailova korisnika
        public IEnumerable<string> GetAllUSerEmail()
        {
            return _appUserService.GetAllUsers().Select(u => u.Email);
        }
    }
}
