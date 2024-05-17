using Okane.Application.Expenses.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okane.Application.Expenses.Delete
{
    public class DeleteExpenseHandler
    {
        private readonly IExpensesRepository _expensesRepository;

        public DeleteExpenseHandler(IExpensesRepository expensesRepository) =>
            _expensesRepository = expensesRepository;

        public IExpenseResponse Handle(int id)
        {
            var expense = _expensesRepository
                .ById(id);

            if (expense == null)
                return new NotFoundResponse();
            else
                _expensesRepository.Delete(expense);

            return expense.ToExpenseResponse();
        }
    }
}
