using Notification.OrdersHub.API.Templates;

namespace Notification.OrdersHub.API.Services;

public interface ISendGridService
{
	Task Send(NotificationTemplate template);
}