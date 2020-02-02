using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Buco.Mappers;
using Buco.Models;
using Buco.Services;
using Buco.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Buco.Controllers
{
    public class WeightEntriesController : Controller
    {
        private readonly IWeightEntryService _weightEntryService;
        private readonly IWeightEntryMapper _weightEntryMapper;
        private readonly IPetService _petService;

        public WeightEntriesController(IWeightEntryService weightEntryService, 
            IWeightEntryMapper weightEntryMapper, IPetService petService)
        {
            _weightEntryService = weightEntryService;
            _weightEntryMapper = weightEntryMapper;
            _petService = petService;
            CultureInfo nonInvariantCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = nonInvariantCulture;
        }

        public async Task<IActionResult> Index(int petId, DateTime startDate, DateTime endDate)
        {
            if (User.Identity.IsAuthenticated)
            {
                var entries = _weightEntryMapper.MapWeightEntries(await _weightEntryService.FilterWeightEntriesAsync(petId, startDate, endDate));
                var pet = await _petService.ReadPetDetailsAsync(petId);

                var model = new WeightEntriesViewModel
                {
                    WeightEntries = entries,
                    WeightGoal = pet.TargetWeight
                };
                return View(model);
            }
            return RedirectToAction("Index", "NotAuthorized");
        }

        public async Task<IActionResult> Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var pets = await _petService.GetPetsSelectListAsync(userId);
                if (pets.Count() == 0)
                {
                    ViewBag.NoPets = true;
                }
                else
                {
                    ViewBag.NoPets = false;
                }
                ViewData["PetId"] = pets;
                return View();
            }
            return RedirectToAction("Index", "NotAuthorized");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WeightEntryId,WeightTime,MesuredWeight,PetId")] WeightEntry newWeightEntry)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {
                   newWeightEntry.WeightTime = DateTime.Now;
                   var returnValue = await _weightEntryService.CreateWeightEntryAsync(newWeightEntry);
                   if (!returnValue)
                   {
                       return RedirectToAction("Index", "Home", new { error = true, msgToDisplay = "An error has occured with the database" });
                   }
                    var goalReached = _weightEntryService.WeightGoalReached(newWeightEntry);
                   return RedirectToAction("Index", "Home", new { goalReached = goalReached, goalText = "weight goal", added = true, msgToDisplay = "New weight entry has been addded!" });
                }
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                ViewBag.NoPets = false;
                ViewData["PetId"] = await _petService.GetPetsSelectListAsync(userId);
                return View(newWeightEntry);
            }
            return RedirectToAction("Index", "NotAuthorized");
        }

        public async Task<IActionResult> Edit(int id, int page = 1)
        {
            if (User.Identity.IsAuthenticated)
            {
                var weightEntry = await _weightEntryService.ReadWeightEntryDetailsAsync(id);
                if (weightEntry == null)
                {
                    return NotFound();
                }
                ViewBag.Page = page;
                return View(weightEntry);
            }
            return RedirectToAction("Index", "NotAuthorized");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("WeightEntryId,WeightTime,MesuredWeight,PetId")] WeightEntry weightEntryToUpdate, int page = 1)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (id != weightEntryToUpdate.WeightEntryId)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    var updateStatus = await _weightEntryService.UpdateWeightEntryAsync(weightEntryToUpdate);
                    if (!updateStatus)
                    {
                        return RedirectToAction("Index", "EditEntries", new { error = true, msgToDisplay = "An error has occured with the databse." });
                    }
                    var goalReached = _weightEntryService.WeightGoalReached(weightEntryToUpdate);
                    return RedirectToAction("Index", "EditEntries", new { id = page, updated = true, msgToDisplay = "Weight entry has been successfully updated." });
                }
                ViewBag.Page = page;
                return View(weightEntryToUpdate);
            }
            return RedirectToAction("Index", "NotAuthorized");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, int page = 1)
        {
            if (User.Identity.IsAuthenticated)
            {
                var deleteStatus = await _weightEntryService.DeleteWeightEntryAsync(id);
                if (!deleteStatus)
                {
                    return RedirectToAction("Index", "EditEntries", new { error = true, msgToDisplay = "An error has occured with the database." });
                }
                return RedirectToAction("Index", "EditEntries", new { id = page, deleted = true, msgToDisplay = "Weight entry has successfully been deleted." });
            }
            return RedirectToAction("Index", "NotAuthorized");
        }
    }
}