namespace Okane.Application.Expenses.Update;

public class UpdateExpenseHandler
{
    private readonly IExpensesRepository _expensesRepository;

    public UpdateExpenseHandler(IExpensesRepository expensesRepository) => 
        _expensesRepository = expensesRepository;

    public IExpenseResponse Handle(UpdateExpenseRequest updateExpenseRequest) {
        var expense = _expensesRepository.ById(updateExpenseRequest.Id);
        if (expense == null) {

            throw new NotImplementedException("Expense not found.");
        }

        // Actualiza los campos del gasto
        expense.Amount = updateExpenseRequest.Amount;
        expense.Category = updateExpenseRequest.Category;
        expense.Description = updateExpenseRequest.Description;

        // Guarda los cambios en el repositorio
        _expensesRepository.Update(expense);

        // Devuelve una respuesta adecuada
        return new ExpenseResponse
        {
            Id = expense.Id,
            Amount = expense.Amount,
            Category = expense.Category,
            Description = expense.Description
        };
    }

    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) { }
    }

    public class ExpenseResponse : IExpenseResponse
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public string? Category { get; set; }
        public string? Description { get; set; }
    }
}