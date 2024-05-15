using System.Security.Principal;
using Okane.Application;
using Okane.Application.Expenses.Create;
using Okane.Application.Expenses.Retrieve; // Asegúrate de agregar este using para el namespace Retrieve

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOkane();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/expenses", (Okane.Application.Expenses.Create.Handler handler, Request request) =>
        handler.Handle(request))
    .WithOpenApi();

app.MapGet("/expenses", (Okane.Application.Expenses.Retrieve.Handler handler) =>
        handler.Handle())
    .WithOpenApi();

app.MapGet("/expenses/{id}", (Okane.Application.Expenses.Retrieve.Handler handlerByID, string id) =>
{
    if (id == "")
    {
        return Results.BadRequest("Invalid expense ID");
    }
    var response = handlerByID.HandleById((id));
    if (response == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(response);
})
.WithOpenApi();

app.Run();
