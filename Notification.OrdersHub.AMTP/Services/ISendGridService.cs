namespace Notification.OrdersHub.API.Infrastructure;

public interface ISendGridService
{
	Task Send(NotificationTemplate template);
}