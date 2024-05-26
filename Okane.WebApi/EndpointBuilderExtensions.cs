using Okane.Application;
using Okane.Application.Auth.SignIn;
using Okane.Application.Auth.Signup;
using Okane.Application.Budget;
using Okane.Application.Budget.Create;
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

namespace Okane.WebApi;

public static class EndpointBuilderExtensions
{
    private const string IdPath = "/{id}";

    public static void MapOkanePaths(this WebApplication app)
    {
        app.MapAuth();
        app.MapCategories();
        app.MapExpenses();
        app.MapBudgets();
    }

    private static void MapAuth(this IEndpointRouteBuilder app)
    {
        var auth = app.MapGroup("/auth");
        auth.MapPost("/signup", (IRequestHandler<SignUpRequest, ISignUpResponse> handler, SignUpRequest request) =>
                handler.Handle(request).ToResult())
            .WithOpenApi();

        auth.MapPost("/token", (IRequestHandler<SignInRequest, ISignInResponse> handler, SignInRequest request) =>
                handler.Handle(request).ToResult())
            .WithOpenApi();
    }

    private static void MapCategories(this IEndpointRouteBuilder app)
    {
        var categories = app.MapGroup("/categories").RequireAuthorization();
        categories.MapPost("/", (CreateCategoryHandler handler, CreateCategoryRequest request) =>
                handler.Handle(request).ToResult())
            .Produces<CategoryResponse>()
            .Produces<ConflictResponse>(StatusCodes.Status409Conflict)
            .WithOpenApi();

        categories.MapGet(IdPath, (GetCategoryByIdHandler handler, int id) =>
                handler.Handle(id).ToResult())
            .Produces<CategoryResponse>()
            .Produces<NotFoundResponse>(StatusCodes.Status404NotFound)
            .WithOpenApi();

        categories.MapDelete(IdPath, (DeleteCategoryHandler handler, int id) =>
                handler.Handle(id).ToResult())
            .Produces<CategoryResponse>()
            .Produces<NotFoundResponse>(StatusCodes.Status404NotFound)
            .WithOpenApi();
    }

    private static void MapExpenses(this IEndpointRouteBuilder app)
    {
        var expenses = app.MapGroup("/expenses").RequireAuthorization();
        expenses.MapPost("/", (CreateExpenseHandler handler, CreateExpenseRequest request) =>
                handler.Handle(request).ToResult())
            .Produces<ExpenseResponse>()
            .Produces<ValidationErrorsResponse>(StatusCodes.Status400BadRequest)
            .WithOpenApi();

        expenses.MapPut(IdPath, (UpdateExpenseHandler handler, int id, UpdateExpenseRequest request) =>
                handler.Handle(id, request).ToResult())
            .Produces<ExpenseResponse>()
            .Produces<NotFoundResponse>(StatusCodes.Status404NotFound)
            .WithOpenApi();

        expenses.MapDelete(IdPath, (DeleteExpenseHandler handler, int id) =>
                handler.Handle(id).ToResult())
            .Produces<ExpenseResponse>()
            .Produces<NotFoundResponse>(StatusCodes.Status404NotFound)
            .WithOpenApi();

        expenses.MapGet("/", (RetrieveExpensesHandler handler) =>
                handler.Handle())
            .WithOpenApi();

        expenses.MapGet(IdPath, (GetExpenseByIdHandler handler, int id) =>
                handler.Handle(id).ToResult())
            .Produces<ExpenseResponse>()
            .Produces<NotFoundResponse>(StatusCodes.Status404NotFound)
            .WithOpenApi();
    }

    private static void MapBudgets(this IEndpointRouteBuilder app)
    {
        var budgets = app.MapGroup("/budgets").RequireAuthorization();
        budgets.MapPost("/", (CreateBudgetHandler handler, CreateBudgetRequest request) =>
                handler.Handle(request).ToResult())
            .Produces<BudgetResponse>()
            .Produces<ConflictResponse>(StatusCodes.Status409Conflict)
            .Produces<ValidationErrorsResponse>(StatusCodes.Status400BadRequest)
            .WithOpenApi();
    }
}