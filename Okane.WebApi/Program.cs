using Okane.Application;
using Okane.Application.Expenses.Create;

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

app.MapGet("/expenses/{id}", (Okane.Application.Expenses.Retrieve.Handler handler, string id) => 
    handler.HandleOne(id))
    .WithOpenApi();


app.Run();