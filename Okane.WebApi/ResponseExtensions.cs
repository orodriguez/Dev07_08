using Okane.Application;
using Okane.Application.Category;
using Okane.Application.Expenses;

namespace Okane.WebApi;

public static class ResponseExtensions
{
    public static IResult ToResult(this IExpenseResponse response) =>
        response switch
        {
            ExpensesSuccessResponse success => Results.Ok(success),
            NotFoundResponseExpenses => Results.NotFound(),
            ValidationErrorsExpenseResponse errors => Results.BadRequest(errors),
            _ => throw new ArgumentOutOfRangeException(nameof(response))
        };
    
    public static IResult ToResultCategory(this ICategoryResponse rcategory) =>
        rcategory switch
        {
            CategorySuccessResponse catsuccess => Results.Ok(catsuccess),
            NotFoundResponseCategory => Results.NotFound(),
            ValidationErrorsCategoryResponse caterrors => Results.BadRequest(caterrors),
            _ => throw new ArgumentOutOfRangeException(nameof(rcategory))
        };
}

