using Okane.Application;
using Okane.Application.Categories;
using Okane.Application.Categories.ById;
using Okane.Application.Categories.Create;
using Okane.Application.Categories.Delete;
using Okane.Application.Categories.ExpensesByCategory;
using Okane.Application.Expenses;
using Okane.Application.Expenses.ById;
using Okane.Application.Expenses.Create;
using Okane.Application.Expenses.Delete;
using Okane.Application.Expenses.Retrieve;
using Okane.Application.Expenses.Update;
using Okane.Application.Responses;
using Okane.Storage.EF;
using Okane.WebApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOkane()
    .AddOkaneEFStorage();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/categories", (CreateCategoryHandler handler, CreateCategoryRequest request) =>
        handler.Handle(request).ToResult())
    .Produces<CategoryResponse>()
    .Produces<ConflictResponse>(StatusCodes.Status409Conflict)
    .WithOpenApi();

app.MapGet("/categories/{Id}", (GetCategoryByIdHandler handler, int id) =>
        handler.Handle(id).ToResult())
    .Produces<CategoryResponse>()
    .Produces<NotFoundResponse>(StatusCodes.Status404NotFound)
    .WithOpenApi();

app.MapDelete("/categories/{Id}", (DeleteCategoryHandler handler, int id) =>
        handler.Handle(id).ToResult())
    .Produces<CategoryResponse>()
    .Produces<NotFoundResponse>(StatusCodes.Status404NotFound)
    .WithOpenApi();

app.MapGet("/category/{id}/expenses", (RetrieveExpensesByCategoryHandler handler, int id) =>
        handler.Handle(id))
    .WithOpenApi();

app.MapPost("/expenses", (CreateExpenseHandler handler, CreateExpenseRequest request) =>
        handler.Handle(request).ToResult())
    .Produces<ExpenseResponse>()
    .Produces<ValidationErrorsResponse>(StatusCodes.Status400BadRequest)
    .WithOpenApi();

app.MapPut("/expenses/{id}", (UpdateExpenseHandler handler, int id, UpdateExpenseRequest request) =>
        handler.Handle(id, request).ToResult())
    .Produces<ExpenseResponse>()
    .Produces<NotFoundResponse>(StatusCodes.Status404NotFound)
    .WithOpenApi();

app.MapDelete("/expenses/{id}", (DeleteExpenseHandler handler, int id) =>
        handler.Handle(id).ToResult())
    .Produces<ExpenseResponse>()
    .Produces<NotFoundResponse>(StatusCodes.Status404NotFound)
    .WithOpenApi();

app.MapGet("/expenses", (RetrieveExpensesHandler handler) =>
        handler.Handle())
    .WithOpenApi();

app.MapGet("/expenses/{id}", (GetExpenseByIdHandler handler, int id) => 
        handler.Handle(id).ToResult())
    .Produces<ExpenseResponse>()
    .Produces<NotFoundResponse>(StatusCodes.Status404NotFound)
    .WithOpenApi();

app.Run();