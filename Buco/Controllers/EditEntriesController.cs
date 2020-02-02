using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Buco.InfoModels;
using Buco.Mappers;
using Buco.Services;
using Buco.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Buco.Controllers
{
    public class EditEntriesController : Controller
    {
        private readonly IWeightEntryService _weightEntryService;
        private readonly IWeightEntryMapper _weightEntryMapper;
        private readonly IMealEntryMapper _mealEntryMapper;
        private readonly IMealEntryService _mealEntryService;
        private readonly IActivityEntryService _activityEntryService;
        private readonly IActivityEntryMapper _activityEntryMapper;
        private readonly IPetService _petService;
        private readonly AppSettings appData;

        public EditEntriesController(IWeightEntryService weightEntryService, IWeightEntryMapper weightEntryMapper,
            IPetService petService, IOptionsSnapshot<AppSettings> options,
            IMealEntryMapper mealEntryMapper, IMealEntryService mealEntryService,
            IActivityEntryService activityEntryService, IActivityEntryMapper activityEntryMapper)
        {
            _weightEntryMapper = weightEntryMapper;
            _weightEntryService = weightEntryService;
            _mealEntryService = mealEntryService;
            _mealEntryMapper = mealEntryMapper;
            _activityEntryMapper = activityEntryMapper;
            _activityEntryService = activityEntryService;
            _petService = petService;
            appData = options.Value;
        }

        public async Task<IActionResult> Index(string msgToDisplay, int id = 1, bool deleted = false,
            bool updated = false, bool error = false)
        {
            if (User.Identity.IsAuthenticated)
            {
                var page = id;
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var pets = await _petService.GetPetsAsync(userId);
                var pageSize = appData.PageSize;

                var latestEntries = new HashSet<LatestEntryViewModel>();
                foreach (var pet in pets)
                {
                    var latestEntry = new LatestEntryViewModel()
                    {
                        PetId = pet.PetId,
                        PetName = pet.PetName,
                    };

                    var latestWeightEntry = await _weightEntryService.GetLatestWeightEntryAsync(pet.PetId);
                    if (latestWeightEntry != null)
                    {
                        latestEntry.LatestWeightEntry = _weightEntryMapper.MapWeightEntry(latestWeightEntry);
                    }

                    var latestMealEntry = await _mealEntryService.GetLatestMealEntryAsync(pet.PetId);
                    if (latestMealEntry != null)
                    {
                        latestEntry.LatestMealEntry = _mealEntryMapper.MapMealEntry(latestMealEntry);
                    }

                    var latestActivityEntry = await _activityEntryService.GetLatestActivityEntryAsync(pet.PetId);
                    if (latestActivityEntry != null)
                    {
                        latestEntry.LatestActivityEntry = _activityEntryMapper.MapActivityEntry(latestActivityEntry);
                    }

                    latestEntries.Add(latestEntry);
                }

                var skippedEntries = latestEntries.Skip((page - 1) * pageSize)
                     .Take(pageSize);

                var pagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = pets.Count()
                };

                if (page > pagingInfo.TotalPages && pagingInfo.TotalPages != 0)
                {
                    return RedirectToAction(nameof(Index),
                        new { page = pagingInfo.TotalPages });
                }

                var model = new LatestEntriesViewModel
                {
                    LatestEntries = skippedEntries,
                    PagingInfo = pagingInfo
                };

                model.CrudInfo.Deleted = deleted;
                model.CrudInfo.Updated = updated;
                model.CrudInfo.Error = error;
                model.MsgToDisplay = msgToDisplay;
                return View(model);
            }
            return RedirectToAction("Index", "NotAuthorized");
        }
    }
}