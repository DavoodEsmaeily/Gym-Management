
using GymManagement.Application.Common.Interfaces;
using GymManagement.Infrastructure.Common.Persistence;
using GymManagement.Infrastructure.Subscriptions.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace GymManagement.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<GymManagementDbContext>(option => option.UseSqlite("Data Source = GymManagement.db"));
            services.AddScoped<IUnitOfWork>(provider => provider.GetRequiredService<GymManagementDbContext>());
            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
            return services;
        }
    }
}
