namespace GymManagement.Application.Common.Interfaces
{
    public interface ISubscriptionRepository
    {
        Task CreateSubscriptionAsync(Subscription subscription);    
    }
}
