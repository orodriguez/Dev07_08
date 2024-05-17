namespace Okane.Application.Expenses.Delete
{
    public record DeleteExpenseRequest(int Id);

    public class DeleteExpenseHandler
    {
        private readonly IExpensesRepository _expensesRepository;

        public DeleteExpenseHandler(IExpensesRepository expensesRepository)
        {
            _expensesRepository = expensesRepository;
        }

        public IExpenseResponse Handle(DeleteExpenseRequest deleteExpenseRequest)
        {
            var expense = _expensesRepository.ById(deleteExpenseRequest.Id);
            if (expense == null)
            {
                return new NotFoundResponse();
            }

            _expensesRepository.Delete(deleteExpenseRequest.Id);
            return new SuccessResponse(expense.Id, expense.Amount, expense.Category, expense.Description);
        }
    }
}