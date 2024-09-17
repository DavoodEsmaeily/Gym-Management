namespace GymManagement.Contracts.Subscription
{
    public record CreateSubscriptionRequest(SubscriptionType SubscriptionType , Guid AdminId);
}
