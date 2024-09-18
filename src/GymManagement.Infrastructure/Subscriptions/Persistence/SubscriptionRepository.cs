using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Subscriptions;

namespace GymManagement.Infrastructure.Subscriptions.Persistence
{
    public class SubscriptionRepository : ISubscriptionRepository
    {

        private readonly static List<Subscription> _subscriptions = new();   
        public async Task CreateSubscriptionAsync(Subscription subscription)
        {
            _subscriptions.Add(subscription);
           await Task.CompletedTask;
        }

        public Task<Subscription?> GetSubscriptionByIdAsync(string subscriptionId)
        {
            var subscription = _subscriptions.FirstOrDefault(x => x.Id == Guid.Parse(subscriptionId));

            return Task.FromResult(subscription);
        }

        public async Task<List<Subscription>> SubscriptionsAsync()
        {
           var subscriptions =  _subscriptions.ToList();
            return subscriptions;
        }
    }
}
