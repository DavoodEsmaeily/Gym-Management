using GymManagement.Application.Services;
using GymManagement.Contracts.Subscription;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/Subscriptions", ([FromBody] CreateSubscriptionRequest request , ISubscriptionService subscriptionService) =>
{

    var subscriptionId = subscriptionService.CreateSubscription(request.SubscriptionType.ToString(), request.AdminId);

    var response = new SubscriptionResponse(subscriptionId,request.SubscriptionType);

    return Results.Ok(response);
})
.WithName("CreateSubscription")
.WithOpenApi();

app.Run();
