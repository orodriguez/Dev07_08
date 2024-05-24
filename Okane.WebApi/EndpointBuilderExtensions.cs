using MediatR;
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

namespace Okane.WebApi;

public static class EndpointBuilderExtensions
{
    private const string IdPath = "/{id}";

    public static void MapOkanePaths(this WebApplication app)
    {
        app.MapAuth();
        app.MapCategories();
        app.MapExpenses();
    }

    private static void MapAuth(this IEndpointRouteBuilder app)
    {
        var auth = app.MapGroup("/auth");
        auth.MapPost("/signup", async (IMediator mediator, SignUpRequest request) =>
                (await mediator.Send(request)).ToResult())
            .WithOpenApi();

        auth.MapPost("/token", async (IMediator mediator, SignInRequest request) =>
                (await mediator.Send(request)).ToResult())
            .WithOpenApi();
    }

    private static void MapCategories(this IEndpointRouteBuilder app)
    {
        var categories = app.MapGroup("/categories").RequireAuthorization();
        categories.MapPost("/", async (IMediator mediator, CreateCategoryRequest request) =>
                (await mediator.Send(request)).ToResult())
            .Produces<CategoryResponse>()
            .Produces<ConflictResponse>(StatusCodes.Status409Conflict)
            .WithOpenApi();

        categories.MapGet(IdPath, async (IMediator mediator, int id) =>
                (await mediator.Send(new GetCategoryByIdRequest(id))).ToResult())
            .Produces<CategoryResponse>()
            .Produces<NotFoundResponse>(StatusCodes.Status404NotFound)
            .WithOpenApi();

        categories.MapDelete(IdPath, async (IMediator mediator, int id) =>
                (await mediator.Send(new DeleteCategoryRequest(id))).ToResult())
            .Produces<CategoryResponse>()
            .Produces<NotFoundResponse>(StatusCodes.Status404NotFound)
            .WithOpenApi();
    }

    private static void MapExpenses(this IEndpointRouteBuilder app)
    {
        var expenses = app.MapGroup("/expenses").RequireAuthorization();
        expenses.MapPost("/", async (IMediator mediator, CreateExpenseRequest request) =>
                (await mediator.Send(request)).ToResult())
            .Produces<ExpenseResponse>()
            .Produces<ValidationErrorsResponse>(StatusCodes.Status400BadRequest)
            .WithOpenApi();

        expenses.MapPut(IdPath, async (IMediator mediator, int id, UpdateExpenseRequest request) =>
                (await mediator.Send(request with { Id = id })).ToResult())
            .Produces<ExpenseResponse>()
            .Produces<NotFoundResponse>(StatusCodes.Status404NotFound)
            .WithOpenApi();

        expenses.MapDelete(IdPath, async (IMediator mediator, int id) =>
                (await mediator.Send(new DeleteExpenseRequest(id))).ToResult())
            .Produces<ExpenseResponse>()
            .Produces<NotFoundResponse>(StatusCodes.Status404NotFound)
            .WithOpenApi();

        expenses.MapGet("/", (IMediator mediator) =>
                mediator.Send(new RetrieveExpensesRequest()))
            .WithOpenApi();

        expenses.MapGet(IdPath, async (IMediator mediator, int id) => 
                (await mediator.Send(new GetExpenseByIdRequest(id))).ToResult())
            .Produces<ExpenseResponse>()
            .Produces<NotFoundResponse>(StatusCodes.Status404NotFound)
            .WithOpenApi();
    }
}