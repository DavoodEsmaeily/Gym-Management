
using GymManagement.Contracts.Subscription;
using Microsoft.AspNetCore.Mvc;
using GymManagement.Application;
using GymManagement.Infrastructure;
using MediatR;
using GymManagement.Application.Subscriptions.Commands.CreateSubscription;
using GymManagement.Application.Subscriptions.Queries.GetSubscription;
using GymManagement.Application.Subscriptions.Queries.ListSubscription;

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
    var command = new CreateSubscriptionCommand(request.SubscriptionType.ToString());

    var createSubscriptionResult = await sender.Send(command);

    return createSubscriptionResult.MatchFirst(
            subscription => Results.Ok(new SubscriptionResponse(subscription.Id.Value, request.SubscriptionType)),
            error => Results.Problem());
})
.WithName("CreateSubscription")
.WithOpenApi();

app.MapGet("/Subscriptions/GetSubscription", async ([FromQuery] string SubscriptionId, ISender sender) =>
{
    var subscriptionQuery = new SubscriptionQuery(SubscriptionId.ToString());

    var createSubscriptionResult = await sender.Send(subscriptionQuery);

    return createSubscriptionResult.MatchFirst(
            subscription => Results.Ok(new SubscriptionResponse(Guid.Parse(SubscriptionId), Enum.Parse<SubscriptionType>(subscription?.SubscriptonType?.ToString() ?? "Free"))),
            error => Results.Problem());
})
.WithName("GetSubscription/{SubscriptionId:string}")
.WithOpenApi();


app.MapGet("/Subscriptions/ListSubscription", async (ISender sender) =>
{
    var listSubscriptionQuery = new ListSubscriptionQuery();

    var createSubscriptionResult = await sender.Send(listSubscriptionQuery);
    return createSubscriptionResult.MatchFirst(
        subscriptions =>
            Results.Ok(subscriptions.Select(x =>
                new SubscriptionResponse(x.Id.Value, Enum.Parse<SubscriptionType>(x?.SubscriptonType?.ToString() ?? "Free")))),
        error =>
        {
            // Log error details here
            Console.WriteLine(error);  // Replace with proper logging
            return Results.Problem();
        });
})
.WithName("ListSubscription")
.WithOpenApi();





app.Run();
