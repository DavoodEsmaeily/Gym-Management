namespace GymManagement.Domain.Subscriptions
{
    public class Subscription
    {
        private readonly Guid? _adminId;
        public Guid Id { get; set; }
        public SubscriptionType SubscriptonType { get; private set; }

        public Subscription(SubscriptionType subscriptionType  , Guid adminId , Guid? id = null )
        {
            SubscriptonType = subscriptionType;
            _adminId = adminId ;
            Id = id ?? Guid.NewGuid();
        }

        private Subscription()
        {
                
        }

    }
}
