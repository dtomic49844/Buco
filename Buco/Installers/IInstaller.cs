using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Buco.Installers
{
    public interface IInstaller
    {
        void InstallService(IServiceCollection services, IConfiguration configuration);
    }
}
