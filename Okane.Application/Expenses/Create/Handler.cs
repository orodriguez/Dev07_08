// To reference Domain that has Expenses class
using Okane.Domain;

namespace Okane.Application.Expenses.Create;

public class Handler
{   // IExpensesRepository interface
    private readonly IExpensesRepository _expensesRepository;
    
    // Constructor that recives the implement the Interface IExpensesRepository
    public Handler(IExpensesRepository expensesRepository) => 
        _expensesRepository = expensesRepository;

    /* Using record Request to manage inmutable data types 
    in this case is category and amount
    ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
    Como Espera un Response, returnamos un nuevo Response, 
    con un new ID and 
    ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓*/

    public Response Handle(Request request)
    {   // we set a new Expense Amount and Category
        var expense = new Expense
        {
            Amount = request.Amount,
            Category = request.Category,
            Description  = request.Description
           
        };
        // We add the new Amount 
        _expensesRepository.Add(expense);
        
        return new Response(expense.Id, request.Amount, request.Category,request.Description);
    }
    
}