using Notification.OrdersHub.API.Services;
using Notification.OrdersHub.API.Subscribers;
using SendGrid.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var services = builder.Services;

services.AddScoped<ISendGridService, SendGridService>();
services.AddSendGrid(options => { options.ApiKey = configuration["SendGrid_ApiKey"]; });
services.AddHostedService<NotificationSubscriber>();
services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
	configuration.AddUserSecrets<Program>();
}


app.UseHttpsRedirection();
app.MapControllers();
app.Run();