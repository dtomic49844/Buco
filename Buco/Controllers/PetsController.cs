using System.Linq;
using System.Threading.Tasks;
using Buco.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Buco.InfoModels;
using Microsoft.Extensions.Options;
using Buco.ViewModels;
using Buco.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Globalization;
using System.Threading;

namespace Buco.Controllers
{
    public class PetsController : Controller
    {

        private readonly IPetService _petService;
        private readonly IPetMapper _petMapper;
        private readonly AppSettings appData;

        public PetsController(IPetService petService, IPetMapper petMapper,
            IOptionsSnapshot<AppSettings> options)
        {
            _petService = petService;
            _petMapper = petMapper;
            appData = options.Value;
            CultureInfo nonInvariantCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = nonInvariantCulture;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id = 1, bool deleted = false, 
            bool updated = false, bool error = false)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (User.Identity.IsAuthenticated)
            {
                var page = id;
                var pageSize = appData.PageSize;
                var pets = _petMapper.MapPets(await _petService.GetPetsAsync(userId));
                var count = pets.Count();

                var pagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = count
                };

                if (page > pagingInfo.TotalPages && pagingInfo.TotalPages != 0)
                {
                    return RedirectToAction("Index", "Pets",
                        new { page = pagingInfo.TotalPages, deleted });
                }

                var petsSkipped = pets.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                var model = new PetsViewModel
                {
                    Pets = petsSkipped,
                    PagingInfo = pagingInfo
                };

                model.CrudInfo.Deleted = deleted;
                model.CrudInfo.Updated = updated;
                model.CrudInfo.Error = error;

                return View(model);             
            }
            return RedirectToAction("Index", "NotAuthorized");
        }

        public async Task<IActionResult> Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewData["PetTypeId"] = await _petService.GetPetTypesAsync();
                return View();
            }
            return RedirectToAction("Index", "NotAuthorized");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create
            ([Bind("PetId,PetName,Gender,DOB,Photo,ActivityLevel,BodyCondtionScore,Spayed,UserId,PetTypeId")] Pet newPet, 
              float weight, IFormFile file)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {
                    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    newPet.UserId = userId;

                    var files = HttpContext.Request.Form.Files.FirstOrDefault();
                    if (files != null)
                    {
                        var fileName = Path.GetFileName(files.FileName);
                        var path = await _petService.SavePhoto(files, fileName, userId);
                        var imageName = path.Split("\\").Last();
                        newPet.Photo = Url.Content(imageName);
                    }
                    var returnValuePet = await _petService.CreatePetAsync(newPet, weight);
                    if (!returnValuePet)
                    {
                        return RedirectToAction(nameof(Index), new { error = true });
                    }
                    return RedirectToAction(nameof(CreatePetInfo), newPet);
                }
                ViewData["PetTypeId"] = await _petService.GetPetTypesAsync();
                return View(newPet);
            }
            return RedirectToAction("Index", "NotAuthorized");
        }

        public async Task<IActionResult> Edit(int id, int page = 1)
        {
            if (User.Identity.IsAuthenticated)
            {               
                var petModel = await _petService.ReadPetDetailsAsync(id);
                if (petModel == null)
                {
                    return NotFound();
                }
                ViewBag.Page = page;
                return View(petModel);
            }
            return RedirectToAction("Index", "NotAuthorized");
        }

        [HttpPost]
        
        public async Task<IActionResult> Edit(int id,
            [Bind("PetId,PetName,Gender,DOB,Photo,ActivityLevel,BodyCondtionScore,Spayed,TargetActivity,TargetCalories,TargetWeight,UserId,PetTypeId")] Pet petToUpdate,
            IFormFile file, string oldPhoto, int page = 1)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (id != petToUpdate.PetId)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    var files = HttpContext.Request.Form.Files.FirstOrDefault();
                    if (files != null)
                    {
                        var fileName = Path.GetFileName(files.FileName);
                        var path = await _petService.SavePhoto(files, fileName, userId);
                        var imageName = path.Split("\\").Last();
                        petToUpdate.Photo = Url.Content(imageName);
                    }

                    if (files == null && oldPhoto != null)
                    {
                        petToUpdate.Photo = Url.Content(oldPhoto);
                    }
                    var updateStatus = await _petService.UpdatePetAsync(petToUpdate);
                    if (!updateStatus)
                    {
                        return RedirectToAction(nameof(Index), new { error = true });
                    }
                    return RedirectToAction(nameof(Index), new { id = page, updated = true });
                }
                ViewBag.Page = page;
                ViewData["PetTypeId"] = await _petService.GetPetTypesAsync();
                return View(petToUpdate);
            }
            return RedirectToAction("Index", "NotAuthorized");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, int page = 1)
        {
            if (User.Identity.IsAuthenticated)
            {
                var deleteStatus = await _petService.DeletePetAsync(id);
                if (!deleteStatus)
                {
                    return RedirectToAction(nameof(Index), new { error = true });
                }
                return RedirectToAction(nameof(Index), new { id = page, deleted = true });
            }
            return RedirectToAction("Index", "NotAuthorized");
        }

        public IActionResult CreatePetInfo(Pet newPet)
        {
            var petViewModel = _petMapper.MapPet(newPet);
            return View(petViewModel);
        }
    }
}