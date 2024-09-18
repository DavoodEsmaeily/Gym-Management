namespace GymManagement.Application.Subscriptions.Queries.ListSubscription
{
    public record ListSubscriptionQuery():IRequest<ErrorOr<List<Subscription>>>;
}
