using SendGrid;
using SendGrid.Helpers.Mail;

namespace Notification.OrdersHub.API.Infrastructure;

public class EmailService(IConfiguration configuration, ISendGridClient client) : INotificationService
{
	public async Task Send(IEmailTemplate template)
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