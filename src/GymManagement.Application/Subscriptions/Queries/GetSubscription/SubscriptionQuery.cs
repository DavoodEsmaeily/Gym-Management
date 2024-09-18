namespace GymManagement.Application.Subscriptions.Queries.GetSubscription
{
    public record SubscriptionQuery(string SubscriptionId) : IRequest<ErrorOr<Subscription>>;
}
