using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Okane.Application;
using Okane.Application.Auth.SignIn;
using Okane.Application.Auth.Signup;
using Okane.Application.Categories;
using Okane.Application.Categories.ById;
using Okane.Application.Categories.Create;
using Okane.Application.Categories.Delete;
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

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        { 
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "http://okane.com",
            ValidAudience = "public",
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes("Super secret key, it must be long enough to work"))
        };
    });

builder.Services.AddAuthorization();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOkane()
    .AddOkaneEFStorage()
    .AddOkaneWebApi();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapPost("/auth/signup", (IRequestHandler<SignUpRequest, ISignUpResponse> handler, SignUpRequest request) =>
        handler.Handle(request).ToResult())
    .WithOpenApi();

app.MapPost("/auth/token", (IRequestHandler<SignInRequest, ISignInResponse> handler, SignInRequest request) =>
        handler.Handle(request).ToResult())
    .WithOpenApi();

app.MapPost("/categories", (CreateCategoryHandler handler, CreateCategoryRequest request) =>
        handler.Handle(request).ToResult())
    .Produces<CategoryResponse>()
    .Produces<ConflictResponse>(StatusCodes.Status409Conflict)
    .RequireAuthorization()
    .WithOpenApi();

app.MapGet("/categories/{Id}", (GetCategoryByIdHandler handler, int id) =>
        handler.Handle(id).ToResult())
    .Produces<CategoryResponse>()
    .Produces<NotFoundResponse>(StatusCodes.Status404NotFound)
    .RequireAuthorization()
    .WithOpenApi();

app.MapDelete("/categories/{Id}", (DeleteCategoryHandler handler, int id) =>
        handler.Handle(id).ToResult())
    .Produces<CategoryResponse>()
    .Produces<NotFoundResponse>(StatusCodes.Status404NotFound)
    .RequireAuthorization()
    .WithOpenApi();

app.MapPost("/expenses", (CreateExpenseHandler handler, CreateExpenseRequest request) =>
        handler.Handle(request).ToResult())
    .Produces<ExpenseResponse>()
    .Produces<ValidationErrorsResponse>(StatusCodes.Status400BadRequest)
    .RequireAuthorization()
    .WithOpenApi();

app.MapPut("/expenses/{id}", (UpdateExpenseHandler handler, int id, UpdateExpenseRequest request) =>
        handler.Handle(id, request).ToResult())
    .Produces<ExpenseResponse>()
    .Produces<NotFoundResponse>(StatusCodes.Status404NotFound)
    .RequireAuthorization()
    .WithOpenApi();

app.MapDelete("/expenses/{id}", (DeleteExpenseHandler handler, int id) =>
        handler.Handle(id).ToResult())
    .Produces<ExpenseResponse>()
    .Produces<NotFoundResponse>(StatusCodes.Status404NotFound)
    .RequireAuthorization()
    .WithOpenApi();

app.MapGet("/expenses", (RetrieveExpensesHandler handler) =>
        handler.Handle())
    .RequireAuthorization()
    .WithOpenApi();

app.MapGet("/expenses/{id}", (GetExpenseByIdHandler handler, int id) => 
        handler.Handle(id).ToResult())
    .Produces<ExpenseResponse>()
    .Produces<NotFoundResponse>(StatusCodes.Status404NotFound)
    .RequireAuthorization()
    .WithOpenApi();

app.Run();