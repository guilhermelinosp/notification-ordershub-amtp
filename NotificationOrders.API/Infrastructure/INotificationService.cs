namespace NotificationOrders.API.Infrastructure
{
    public interface INotificationService
    {
        Task Send(IEmailTemplate template);
    }
}