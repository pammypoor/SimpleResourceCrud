using ExpenseReporter.Core.Models;

namespace ExpenseReporter.Core.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();

        Category FirstOrDefault(long id);

    }
}
