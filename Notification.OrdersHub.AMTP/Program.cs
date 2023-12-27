using Notification.OrdersHub.API.Infrastructure;
using Notification.OrdersHub.API.Subscribers;
using SendGrid.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddScoped<INotificationService, EmailService>();
services.AddSendGrid(options => { options.ApiKey = builder.Configuration["SendGrid_ApiKey"]; });
services.AddHostedService<ShippingOrderUpdatedSubscriber>();
services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();
app.Run();