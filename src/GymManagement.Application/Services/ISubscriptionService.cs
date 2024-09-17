namespace GymManagement.Application.Services
{
    public interface ISubscriptionService
    {
        Guid CreateSubscription(string SubscriptionType, Guid AdminId);
    }
}

