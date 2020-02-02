using Buco.Data;
using Buco.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buco.Services
{
    public class ActivityTypeService : IActivityTypeService
    {
        private readonly ApplicationDbContext _dbContext;

        public ActivityTypeService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CreateActivityTypeAsync(ActivityType activityType)
        {
            await _dbContext.ActivityTypes.AddAsync(activityType);
            var created = await _dbContext.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> DeleteActivityTypeAsnyc(int activityTypeId)
        {
            var activityType = await _dbContext.ActivityTypes.SingleOrDefaultAsync(t => t.ActivityTypeId == activityTypeId);
            if (activityTypeId != activityType.ActivityTypeId)
            {
                return false;
            }
            _dbContext.Remove(activityType);
            var deleted = await _dbContext.SaveChangesAsync();
            return deleted > 0;
        }

        public async Task<ActivityType> GetActivityType(int activityId)
        {
            return await _dbContext.ActivityTypes.SingleOrDefaultAsync(t => t.ActivityTypeId == activityId);
        }

        public IEnumerable<ActivityType> GetAllActivityTypes()
        {
            return _dbContext.ActivityTypes.AsEnumerable();
        }

        public async Task<bool> UpdateActivityTypeAsync(ActivityType activityTypeToUpdate)
        {
            _dbContext.ActivityTypes.Update(activityTypeToUpdate);
            var updated = await _dbContext.SaveChangesAsync();
            return updated > 0;
        }
    }
}
