using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Buco.InfoModels;
using Buco.Models;
using Buco.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Buco.ViewModels;
using System.Globalization;
using System.Threading;

namespace Buco.Controllers
{
    public class MealEntriesController : Controller
    {
        private readonly IMealEntryService _mealEntryService;
        private readonly IPetService _petService;

        public MealEntriesController(IMealEntryService mealEntryService,
            IPetService petService)
        {
            _mealEntryService = mealEntryService;
            _petService = petService;
            CultureInfo nonInvariantCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = nonInvariantCulture;
        }

        public async Task<IActionResult> Index(int petId, DateTime startDate, DateTime endDate)
        {
            if (User.Identity.IsAuthenticated)
            {
                var entries = await _mealEntryService.FilterMealEntriesAsync(petId, startDate, endDate);
                var pet = await _petService.ReadPetDetailsAsync(petId);

                var model = new MealEntriesPerDayViewModel
                {
                    MealEntries = entries,
                    DailyCalorieGoal = pet.TargetCalories
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
        public async Task<IActionResult> Create([Bind("MealEntryId,MealTime,Calories,PetId")] MealEntry newMealEntry)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {
                    newMealEntry.MealTime = DateTime.Now;
                    var returnValue = await _mealEntryService.CreateMealEntryAsync(newMealEntry);
                    if (!returnValue)
                    {
                        return RedirectToAction("Index", "Home", new { error = true, msgToDisplay = "An error has occured with the database" });
                    }
                    var goalReached = _mealEntryService.DailyMealGoalReached(newMealEntry.PetId);
                    return RedirectToAction("Index", "Home", new { goalReached = goalReached, goalText ="daily calorie goal", added = true, msgToDisplay = "New meal entry has been addded!" });
                }
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                ViewBag.NoPets = false;
                ViewData["PetId"] = await _petService.GetPetsSelectListAsync(userId);
                return View(newMealEntry);
            }
            return RedirectToAction("Index", "NotAuthorized");
        }

        public async Task<IActionResult> Edit(int id, int page = 1)
        {
            if (User.Identity.IsAuthenticated)
            {
                var mealEntry = await _mealEntryService.ReadMealEntryDetailsAsync(id);
                if (mealEntry == null)
                {
                    return NotFound();
                }
                ViewBag.Page = page;
                return View(mealEntry);
            }
            return RedirectToAction("Index", "NotAuthorized");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, 
            [Bind("MealEntryId,MealTime,Calories,PetId")] MealEntry mealEntryToUpdate, int page = 1)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (id != mealEntryToUpdate.MealEntryId)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    var updateStatus = await _mealEntryService.UpdateMealEntryAsync(mealEntryToUpdate);
                    if (!updateStatus)
                    {
                        return RedirectToAction("Index", "EditEntries", new { error = true, msgToDisplay = "An error has occured with the databse." });
                    }
                    var goalReached = _mealEntryService.DailyMealGoalReached(mealEntryToUpdate.PetId);
                    return RedirectToAction("Index", "EditEntries", new { id = page, updated = true, msgToDisplay = "Meal entry has been successfully updated." });
                }
                ViewBag.Page = page;
                return View(mealEntryToUpdate);
            }
            return RedirectToAction("Index", "NotAuthorized");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, int page = 1)
        {
            if (User.Identity.IsAuthenticated)
            {
                var deleteStatus = await _mealEntryService.DeleteMealEntryAsync(id);
                if (!deleteStatus)
                {
                    return RedirectToAction("Index", "EditEntries", new { error = true, msgToDisplay = "An error has occured with the database." });
                }
                return RedirectToAction("Index", "EditEntries", new { id = page, deleted = true, msgToDisplay = "Meal entry has successfully been deleted." });
            }
            return RedirectToAction("Index", "NotAuthorized");
        }
    }
}