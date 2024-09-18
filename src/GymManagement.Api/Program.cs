
using GymManagement.Contracts.Subscription;
using Microsoft.AspNetCore.Mvc;
using GymManagement.Application;
using GymManagement.Infrastructure;
using MediatR;
using GymManagement.Application.Subscriptions.Commands.CreateSubscription;
using ErrorOr;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication()
    .AddInfrastructure();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapPost("/Subscriptions", async (CreateSubscriptionRequest request, ISender sender) =>
{
    var command = new CreateSubscriptionCommand(request.SubscriptionType.ToString(), request.AdminId);

    var createSubscriptionResult = await sender.Send(command);

    return createSubscriptionResult.MatchFirst(
            subscription => Results.Ok(new SubscriptionResponse(subscription.Id.Value, request.SubscriptionType)),
            error => Results.Problem());
})
.WithName("CreateSubscription")
.WithOpenApi();

app.Run();
