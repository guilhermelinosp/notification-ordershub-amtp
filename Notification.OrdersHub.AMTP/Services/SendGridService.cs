using Notification.OrdersHub.API.Templates;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Notification.OrdersHub.API.Services;

public class SendGridService(IConfiguration configuration, ISendGridClient client) : ISendGridService
{
	public async Task Send(NotificationTemplate template)
	{
		var message = new SendGridMessage
		{
			From = new EmailAddress(configuration["SendGrid_FromEmail"], configuration["SendGrid_FromName"]),
			Subject = template.Subject,
			PlainTextContent = template.Content
		};

		message.AddTo(template.To);

		await client.SendEmailAsync(message);
	}
}