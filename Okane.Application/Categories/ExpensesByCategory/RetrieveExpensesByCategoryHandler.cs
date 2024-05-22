using Okane.Application.Expenses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Okane.Application.Responses;

namespace Okane.Application.Categories.ExpensesByCategory
{
    public class RetrieveExpensesByCategoryHandler
    {
        private readonly IExpensesRepository _expensesRepository;

        public RetrieveExpensesByCategoryHandler(IExpensesRepository expensesRepository)
        {
            _expensesRepository = expensesRepository;
        }
        public IEnumerable<ExpenseResponse> Handle(int id) =>
            _expensesRepository
                .All()
                .Where(expense => expense.Category.Id == id)
                .Select(expense => expense.ToExpenseResponse());
    }
}
