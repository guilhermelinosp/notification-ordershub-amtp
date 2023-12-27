namespace Notification.OrdersHub.API.Infrastructure;

public interface INotificationService
{
	Task Send(IEmailTemplate template);
}