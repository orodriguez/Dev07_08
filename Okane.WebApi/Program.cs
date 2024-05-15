using Okane.Application;
using Okane.Application.Expenses.Create;
using Okane.WebApi;

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

app.MapPost("/expenses", (Handler handler, Request request) =>
        handler.Handle(request))
    .WithOpenApi();

app.MapGet("/expenses", (Okane.Application.Expenses.Retrieve.Handler handler) =>
        handler.Handle())
    .WithOpenApi();

app.MapGet("/expenses/{id}", void (Okane.Application.Expenses.ById.Handler handler, int id) => 
        handler.Handle(id).ToResult())
    .WithOpenApi();

app.Run();