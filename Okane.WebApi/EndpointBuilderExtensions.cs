using MediatR;
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
using Okane.Application.Results;
using Request = Okane.Application.Categories.Delete.Request;
using Response = Okane.Application.Expenses.Response;

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
        auth.MapPost("/signup", async (IMediator mediator, Application.Auth.Signup.Request request) =>
                (await mediator.Send(request)).ToActionResult())
            .WithOpenApi();

        auth.MapPost("/token", async (IMediator mediator, Application.Auth.SignIn.Request request) =>
                (await mediator.Send(request)).ToActionResult())
            .WithOpenApi();
    }

    private static void MapCategories(this IEndpointRouteBuilder app)
    {
        var categories = app.MapGroup("/categories").RequireAuthorization();
        categories.MapPost("/", async (IMediator mediator, Application.Categories.Create.Request request) =>
                (await mediator.Send(request)).ToActionResult())
            .Produces<Application.Categories.Response>()
            .Produces<ConflictError>(StatusCodes.Status409Conflict)
            .WithOpenApi();

        categories.MapGet(IdPath, async (IMediator mediator, int id) =>
                (await mediator.Send(new Application.Categories.ById.Request(id))).ToActionResult())
            .Produces<Application.Categories.Response>()
            .Produces<NotFoundResponse>(StatusCodes.Status404NotFound)
            .WithOpenApi();

        categories.MapDelete(IdPath, async (IMediator mediator, int id) =>
                (await mediator.Send(new Request(id))).ToActionResult())
            .Produces<Application.Categories.Response>()
            .Produces<NotFoundResponse>(StatusCodes.Status404NotFound)
            .WithOpenApi();
    }

    private static void MapExpenses(this IEndpointRouteBuilder app)
    {
        var expenses = app.MapGroup("/expenses").RequireAuthorization();
        expenses.MapPost("/", async (IMediator mediator, Application.Expenses.Create.Request request) =>
                (await mediator.Send(request)).ToActionResult())
            .Produces<Response>()
            .Produces<PropertyValidationErrors>(StatusCodes.Status400BadRequest)
            .WithOpenApi();

        expenses.MapPut(IdPath, async (IMediator mediator, int id, Application.Expenses.Update.Request request) =>
                (await mediator.Send(request with { Id = id })).ToActionResult())
            .Produces<Response>()
            .Produces<NotFoundResponse>(StatusCodes.Status404NotFound)
            .WithOpenApi();

        expenses.MapDelete(IdPath, async (IMediator mediator, int id) =>
                (await mediator.Send(new DeleteExpenseRequest(id))).ToActionResult())
            .Produces<Response>()
            .Produces<NotFoundResponse>(StatusCodes.Status404NotFound)
            .WithOpenApi();

        expenses.MapGet("/", (IMediator mediator) =>
                mediator.Send(new RetrieveExpensesRequest()))
            .WithOpenApi();

        expenses.MapGet(IdPath, async (IMediator mediator, int id) => 
                (await mediator.Send(new Application.Expenses.ById.Request(id))).ToActionResult())
            .Produces<Response>()
            .Produces<NotFoundResponse>(StatusCodes.Status404NotFound)
            .WithOpenApi();
    }
}