using Okane.Application.Expenses;
using Okane.Application.Expenses.Create;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Okane dependencies
builder.Services.AddTransient<Handler>();
builder.Services.AddTransient<IExpensesRepository, InMemoryRepository>();

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

app.MapGet("/expenses", () =>
    {
        throw new NotImplementedException();
    })
    .WithOpenApi();

app.Run();