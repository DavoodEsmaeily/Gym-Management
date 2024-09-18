namespace GymManagement.Application.Common.Interfaces
{
    public interface ISubscriptionRepository
    {
        Task CreateSubscriptionAsync(Subscription subscription); 
        Task<Subscription?> GetSubscriptionByIdAsync(string subscriptionId);
        Task<List<Subscription>> SubscriptionsAsync();
    }
}
