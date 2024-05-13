using Microsoft.Extensions.DependencyInjection.Extensions;
using Okane.WebApi;
using Okane.WebApi.DTOs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Okane dependencies
builder.Services.AddTransient<CreateExpenseRequestHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/expenses", (CreateExpenseRequestHandler handler, CreateExpenseRequest request) => 
        handler.Handle(request))
    .WithOpenApi();

app.MapGet("/expenses", () =>
    {
        var expenses = new[]
        { 
            new Expense(10, "Food"),
            new Expense(20, "Education")
        };

        return expenses;
    })
    .WithOpenApi();

app.Run();