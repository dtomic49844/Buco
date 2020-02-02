using Buco.Mappers;
using Buco.Services;
using Buco.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Buco.Installers
{
    public class MvcInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddScoped<IActivityEntryMapper, ActivityEntryMapper>();
            services.AddScoped<IMealEntryMapper, MealEntryMapper>();
            services.AddScoped<IPetMapper, PetMapper>();
            services.AddScoped<IWeightEntryMapper, WeightEntryMapper>();
            services.AddScoped<IDateValidation, DateValidation>();
        }
    }
}
