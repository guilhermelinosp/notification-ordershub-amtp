namespace Notification.OrdersHub.API.Infrastructure;

public class ShippingOrderUpdateTemplate(string trackingCode, string to, string description) : IEmailTemplate
{
	public string Subject { get; set; } = $"Your shipping order with code {trackingCode} was updated.";
	public string Content { get; set; } = $"Hi, how are you? This is a notification about your shipping order with code {trackingCode}. Update: {description}";
	public string To { get; set; } = to;
}