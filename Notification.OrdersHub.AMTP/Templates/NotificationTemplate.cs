namespace Notification.OrdersHub.API.Infrastructure;

public class NotificationTemplate(string trackingCode, string to, string description)
{
	public string Subject { get; set; } = $"Your shipping order with code {trackingCode} was updated.";
	public string Content { get; set; } = $"Hi, how are you? This is a notification about your shipping order with code {trackingCode}. Update: {description}";
	public string To { get; set; } = to;
}