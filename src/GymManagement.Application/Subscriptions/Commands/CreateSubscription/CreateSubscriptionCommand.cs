namespace GymManagement.Application.Subscriptions.Commands.CreateSubscription
{
    public record CreateSubscriptionCommand(string SubscriptionType) : IRequest<ErrorOr<Subscription>>;
}
