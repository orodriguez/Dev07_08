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
//Modificar los endpoints GET /expenses y POST /expenses para que manejen la propiedad Description en los gastos.
//Description es de tipo string y es opcional.
//Agregar un endpoint nuevo GET /expenses/:id. Este endpoint retorna un solo expense según el id que se pase.

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