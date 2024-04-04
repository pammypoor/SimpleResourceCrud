using ExpenseReporter.Core.Models;

namespace ExpenseReporter.Core.Repositories
{
    public interface IExpenseRepository
    {
        IEnumerable<Expense> GetAll();

        long Insert(Expense entity);

        long Update(Expense entity);

        void Delete(long id);
    }
}
