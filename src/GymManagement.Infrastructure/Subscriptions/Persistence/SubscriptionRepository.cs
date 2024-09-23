using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Subscriptions;
using GymManagement.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GymManagement.Infrastructure.Subscriptions.Persistence
{
    public class SubscriptionRepository : ISubscriptionRepository
    {

        private readonly GymManagementDbContext _context = null!;

        public SubscriptionRepository(GymManagementDbContext context)
        {
            _context = context;
        }

        public async Task CreateSubscriptionAsync(Subscription subscription)
        {
            await _context.Subscriptions.AddAsync(subscription);

        }

        public async Task<Subscription?> GetSubscriptionByIdAsync(string subscriptionId)
        {
            return await _context.Subscriptions.FirstOrDefaultAsync(x => x.Id == Guid.Parse(subscriptionId));
        }

        public async Task<List<Subscription>> SubscriptionsAsync()
        {
            return await _context.Subscriptions.ToListAsync();
        }
    }
}
