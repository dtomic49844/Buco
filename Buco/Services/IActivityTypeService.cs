using Buco.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Buco.Services
{
    public interface IActivityTypeService
    {
        IEnumerable<ActivityType> GetAllActivityTypes();

        Task<ActivityType> GetActivityType(int activityId);

        Task<bool> CreateActivityTypeAsync(ActivityType activityType);

        Task<bool> UpdateActivityTypeAsync(ActivityType activityTypeToUpdate);

        Task<bool> DeleteActivityTypeAsnyc(int activityTypeId);
    }
}
