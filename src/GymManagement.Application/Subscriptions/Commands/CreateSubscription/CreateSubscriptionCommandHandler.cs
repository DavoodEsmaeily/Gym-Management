using GymManagement.Application.Common.Interfaces;

namespace GymManagement.Application.Subscriptions.Commands.CreateSubscription
{
    public class CreateSubscriptionCommandHandler : IRequestHandler<CreateSubscriptionCommand, ErrorOr<Subscription>>
    {
        private ISubscriptionRepository _subscriptionRepository;
       // private IUnitOfWork _unitOfWork;


        public CreateSubscriptionCommandHandler(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
           // _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<Subscription>> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
        {

            var subscription = new Subscription
            {
                Id = Guid.NewGuid(),
                SubscriptonType = request.SubscriptionType,
            };

            await _subscriptionRepository.CreateSubscriptionAsync(subscription);
          //  await _unitOfWork.CommitChangesAsync();

            return subscription;
        }
    }
}
