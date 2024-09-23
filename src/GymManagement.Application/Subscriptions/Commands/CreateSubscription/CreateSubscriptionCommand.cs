﻿namespace GymManagement.Application.Subscriptions.Commands.CreateSubscription
{
    public record CreateSubscriptionCommand(SubscriptionType SubscriptionType , Guid AdminId) : IRequest<ErrorOr<Subscription>>;
}
