using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Buco.InfoModels;
using Buco.Models;
using Buco.Services;
using Buco.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Buco.Controllers
{
    public class ActivityEntriesController : Controller
    {
        private readonly IActivityEntryService _activityEntryService;
        private readonly IPetService _petService;

        public ActivityEntriesController(IActivityEntryService activityEntryService,
            IPetService petService)
        {
            _activityEntryService = activityEntryService;
            _petService = petService;
            CultureInfo nonInvariantCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = nonInvariantCulture;
        }

        public async Task<IActionResult> Index(int petId, DateTime startDate, DateTime endDate)
        {
            if (User.Identity.IsAuthenticated)
            {
                var entries = await _activityEntryService.FilterActivityEntriesAysnc(petId, startDate, endDate);
                var pet = await _petService.ReadPetDetailsAsync(petId);

                var model = new ActivityEntriesPerDayViewModel
                {
                    ActivityEntries = entries,
                    ActivityGoal = pet.TargetActivity
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
                ViewData["ActivityTypeId"] = await _activityEntryService.GetActivityTypesAsync();
                return View();
            }
            return RedirectToAction("Index", "NotAuthorized");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ActivityEntryId,ActivityTime,ActivityDuration,PetId,ActivityTypeId")] ActivityEntry newActivityEntry)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {
                    newActivityEntry.ActivityTime = DateTime.Now;
                    var returnValue = await _activityEntryService.CreateActivityEntryAsync(newActivityEntry);
                    if (!returnValue)
                    {
                        return RedirectToAction("Index", "Home", new { error = true, msgToDisplay = "An error has occured with the database" });
                    }
                    var goalReached = _activityEntryService.DailyActivityGoalReached(newActivityEntry.PetId);
                    return RedirectToAction("Index", "Home", new { goalReached = goalReached, goalText = "daily activity goal", added = true, msgToDisplay = "New activity entry has been addded!" });
                }
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                ViewData["PetId"] = await _petService.GetPetsSelectListAsync(userId);
                ViewData["ActivityTypeId"] = await _activityEntryService.GetActivityTypesAsync();
                return View(newActivityEntry);
            }
            return RedirectToAction("Index", "NotAuthorized");
        }

        public async Task<IActionResult> Edit(int id, int page = 1)
        {
            if (User.Identity.IsAuthenticated)
            {
                var activityEntry = await _activityEntryService.ReadDetailsActivityEntryAsync(id);
                ViewData["ActivityTypeId"] = await _activityEntryService.GetActivityTypesAsync();
                if (activityEntry == null)
                {
                    return NotFound();
                }
                ViewBag.Page = page;
                return View(activityEntry);
            }
            return RedirectToAction("Index", "NotAuthorized");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ActivityEntryId,ActivityTime,ActivityDuration,PetId,ActivityTypeId")] ActivityEntry activityEntryToUpdate, int page = 1)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (id != activityEntryToUpdate.ActivityEntryId)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    var updateStatus = await _activityEntryService.UpdateActivityEntryAsync(activityEntryToUpdate);
                    if (!updateStatus)
                    {
                        return RedirectToAction("Index", "EditEntries", new { error = true, msgToDisplay = "An error has occured with the databse." });
                    }
                    var goalReached = _activityEntryService.DailyActivityGoalReached(activityEntryToUpdate.PetId);
                    return RedirectToAction("Index", "EditEntries", new { id = page, updated = true, msgToDisplay = "Activity entry has been successfully updated." });
                }
                ViewBag.Page = page;
                ViewData["ActivityTypeId"] = await _activityEntryService.GetActivityTypesAsync();
                return View(activityEntryToUpdate);
            }
            return RedirectToAction("Index", "NotAuthorized");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, int page = 1)
        {
            if (User.Identity.IsAuthenticated)
            {
                var deleteStatus = await _activityEntryService.DeleteActivityEntryAsync(id);
                if (!deleteStatus)
                {
                    return RedirectToAction("Index", "EditEntries", new { error = true, msgToDisplay = "An error has occured with the database." });
                }
                return RedirectToAction("Index", "EditEntries", new { id = page, deleted = true, msgToDisplay = "Activity entry has successfully been deleted." });
            }
            return RedirectToAction("Index", "NotAuthorized");
        }

    }
}