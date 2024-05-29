using Okane.Application.Auth;
using Okane.Application.Categories;
using Okane.Application.Expenses;

namespace Okane.Application;

public class App
{
    public AuthService Auth { get; }
    public CategoriesService Categories { get; set; }
    public ExpensesService Expenses { get; set; }

    public App(
        AuthService auth, 
        CategoriesService categories, 
        ExpensesService expenses)
    {
        Auth = auth;
        Categories = categories;
        Expenses = expenses;
    }
}