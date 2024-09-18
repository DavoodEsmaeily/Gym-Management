namespace GymManagement.Application.Subscriptions.Commands.CreateSubscription
{
    public record CreateSubscriptionCommand(string SubscriptionType, Guid Id) : IRequest<ErrorOr<Subscription>>;
}
