using Buco.Data;
using Buco.Models;
using Buco.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Buco.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddDefaultUI()
                .AddEntityFrameworkStores<ApplicationDbContext>();


            services.AddScoped<IActivityEntryService, ActivityEntryService>();
            services.AddScoped<IMealEntryService, MealEntryService>();
            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IWeightEntryService, WeightEntryService>();
        }
    }
}
