using Buco.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buco.Services
{
    public interface IAppUserService
    {
        IEnumerable<ApplicationUser> GetAllUsers();
    }
}
