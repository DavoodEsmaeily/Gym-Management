using GymManagement.Application.Common.Interfaces;

namespace GymManagement.Application.Subscriptions.Queries.ListSubscription
{
    public class ListSubscriptionQueryHandler : IRequestHandler<ListSubscriptionQuery, ErrorOr<List<Subscription>>>
    {

        private readonly ISubscriptionRepository _subscriptionRepository;

        public ListSubscriptionQueryHandler(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task<ErrorOr<List<Subscription>>> Handle(ListSubscriptionQuery request, CancellationToken cancellationToken)
        {
            var subscriptions = await _subscriptionRepository.SubscriptionsAsync();

            return subscriptions;
        }
    }
}
