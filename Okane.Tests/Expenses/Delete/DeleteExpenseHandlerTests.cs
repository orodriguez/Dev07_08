using Okane.Application;
using Okane.Application.Expenses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okane.Tests.Expenses.Delete
{
    public class DeleteExpenseHandlerTests : AbstractHandlerTests
    {
        [Fact]
        public void DeleteExisting()
        {
            var createdExpense = Assert.IsType<SuccessResponse>(CreateExpense(new ValidCreateExpenseRequest()));

            var deletedExpense = Assert.IsType<SuccessResponse>(DeleteExpense(createdExpense.Id));
            Assert.NotNull(deletedExpense);
            Assert.Empty(RetrieveExpenses());
        }

        [Fact]
        public void DeleteNotExisting()
        {
            Assert.IsType<NotFoundResponse>(DeleteExpense(5));
        }
    }
}
