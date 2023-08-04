using Microsoft.OpenApi.Models;
using NotificationOrders.API.Infrastructure;
using NotificationOrders.API.Subscribers;
using SendGrid.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddScoped<INotificationService, EmailService>();
builder.Services.AddSendGrid(options => { options.ApiKey = configuration.GetSection("SendGrid:ApiKey").Value; });

builder.Services.AddHostedService<ShippingOrderUpdatedSubscriber>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("V1", new OpenApiInfo
    {
        Title = "Notification Orders API Swagger Documentation",
        Version = "V1",
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(opt => { opt.SwaggerEndpoint("/swagger/V1/swagger.json", "Notification Orders API"); });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();