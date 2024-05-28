using Okane.Application.Auth;
using Okane.Application.Expenses;

namespace Okane.Application;

public class App
{
    public AuthService Auth { get; }
    public ExpensesService Expenses { get; set; }

    public App(AuthService auth, ExpensesService expenses)
    {
        Auth = auth;
        Expenses = expenses;
    }
}