using GymManagement.Application.Common.Interfaces;

namespace GymManagement.Application.Subscriptions.Commands.CreateSubscription
{
    public class CreateSubscriptionCommandHandler : IRequestHandler<CreateSubscriptionCommand, ErrorOr<Subscription>>
    {
        private ISubscriptionRepository _subscriptionRepository;
        private IUnitOfWork _unitOfWork;


        public CreateSubscriptionCommandHandler(ISubscriptionRepository subscriptionRepository, IUnitOfWork unitOfWork)
        {
            _subscriptionRepository = subscriptionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<Subscription>> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
        {

            var subscription = new Subscription(request.SubscriptionType, request.AdminId);
            
            await _subscriptionRepository.CreateSubscriptionAsync(subscription);
            await _unitOfWork.CommitChangesAsync();

            return subscription;
        }
    }
}
