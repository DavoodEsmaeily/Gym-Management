using GymManagement.Application.Common.Interfaces;

namespace GymManagement.Application.Subscriptions.Queries.GetSubscription
{
    public class SubscriptionQueryHandler : IRequestHandler<SubscriptionQuery, ErrorOr<Subscription>>
    {
        private readonly ISubscriptionRepository _subscriptionRepository;

        public SubscriptionQueryHandler(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task<ErrorOr<Subscription>> Handle(SubscriptionQuery request, CancellationToken cancellationToken)
        {
            var subscrition = await _subscriptionRepository.GetSubscriptionByIdAsync(request.SubscriptionId);

            if (subscrition is null)
                return Error.NotFound("Subscription not found!!");
            return subscrition;
        }
    }
}
