using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Buco.InfoModels;
using Buco.Services;
using Buco.Validation;
using Buco.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Buco.Controllers
{
    public class GetEntriesController : Controller
    {
        private readonly ClaimsPrincipal currentUser;
        private readonly IPetService _petService;
        private readonly IDateValidation _dateValidation;
        private readonly EntryTypeConstants EntryConstants;

        public GetEntriesController(IPetService petService, IDateValidation dateValidation)
        {
            _dateValidation = dateValidation;
            _petService = petService;
            currentUser = User;
            EntryConstants = new EntryTypeConstants();
        }

        public async Task<IActionResult> Index(bool error = false)
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var petsList = await _petService.GetPetsAsync(userId);
                var model = new GetEntriesViewModel
                {
                    DropDownPets = new SelectList(petsList, "PetId", "PetName"),
                    Error = error
                };
                
                if (petsList.Count() == 0)
                {
                    ViewBag.NoPets = true;
                }
                else
                {
                    ViewBag.NoPets = false;
                }
                return View(model);
            }
            return RedirectToAction("Index", "NotAuthorized");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FilterEntries(int petId, DateTime startDate, DateTime endDate, string entryType)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (_dateValidation.ValidateDates(startDate, endDate))
                {
                    if (entryType == EntryConstants.WEIGHT_ENTRY)
                    {
                        return RedirectToAction("Index", "WeightEntries", new { petId, startDate, endDate });
                    }
                    else if (entryType == EntryConstants.ACTIVITY_ENTRY)
                    {
                        return RedirectToAction("Index", "ActivityEntries", new { petId, startDate, endDate });
                    }
                    else
                    {
                        return RedirectToAction("Index", "MealEntries", new { petId, startDate, endDate });
                    }
                }
                return RedirectToAction(nameof(Index), new { error = true });
            }
            return RedirectToAction("Index", "NotAuthorized");
        }
    }
}