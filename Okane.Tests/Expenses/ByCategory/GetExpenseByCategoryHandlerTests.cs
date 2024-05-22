using Okane.Application.Categories;
using Okane.Application.Expenses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okane.Tests.Expenses.ByCategory
{
    public class GetExpenseByCategoryHandlerTests : AbstractHandlerTests
    {
        [Fact]
        public void Finds2()
        {
            Assert.IsType<CategoryResponse>(CreateCategory(new("Taxes")));
            Assert.IsType<ExpenseResponse>(CreateExpense(new(20, "Taxes")));
            Assert.IsType<ExpenseResponse>(CreateExpense(new(20, "Taxes")));

            var found = RetrieveByCategory(1);

            Assert.Equal(2, found.Count());
        }
    }
}
