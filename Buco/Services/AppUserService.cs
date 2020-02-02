using Buco.Data;
using Buco.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buco.Services
{
    public class AppUserService : IAppUserService
    {
        private readonly ApplicationDbContext _dbContext;

        public AppUserService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<ApplicationUser> GetAllUsers()
        {
            return _dbContext.Users.ToArray();
        }
    }
}
