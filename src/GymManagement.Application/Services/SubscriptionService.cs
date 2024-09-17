
namespace GymManagement.Application.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        public Guid CreateSubscription(string SubscriptionType, Guid AdminId)
        {
            return Guid.NewGuid();
        }
    }
}