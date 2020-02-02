using Buco.Models;
using Buco.Services;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System;
using Buco.Data;
using System.Threading.Tasks;

namespace BucoDesktop.Providers
{
    public class ActivityTypesProvider
    {
        private readonly ActivityTypeService _activityTypeService;
        private readonly int pageSize;

        public ActivityTypesProvider(ApplicationDbContext dataContext)
        {
            _activityTypeService = new ActivityTypeService(dataContext);
            pageSize = Convert.ToInt32(ConfigurationManager.AppSettings["pageSize"]);
        }

        public IEnumerable<ActivityType> PopulateGrid(int page = 1)
        {
            return  _activityTypeService.GetAllActivityTypes().Skip((page - 1) * pageSize).Take(pageSize).ToArray();
        }

        public async Task<bool> CreateActivityType(ActivityType activityType)
        {
            return await _activityTypeService.CreateActivityTypeAsync(activityType);
        }

        public async Task<bool> UpdateActivityType(int activityId, string newDesc)
        {
            var activity = await _activityTypeService.GetActivityType(activityId);
            activity.ActivityTypeDesc = newDesc;
            return await _activityTypeService.UpdateActivityTypeAsync(activity);
        }

        public async Task<bool> DeleteActivityType(int activityTypeId)
        {
            return await _activityTypeService.DeleteActivityTypeAsnyc(activityTypeId);
        }

        public int GetTotalPages()
        {
            var totalItems = _activityTypeService.GetAllActivityTypes().Count();
            return (int)Math.Ceiling((decimal)totalItems / (pageSize));
        }
    }
}
