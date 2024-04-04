using ExpenseReporter.Core.Models;

namespace ExpenseReporter.Core.Repositories
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<TSource> WhereIf<TSource>(
            this IEnumerable<TSource> source, bool condition, Func<TSource, bool> predicate)
        {
            return condition ? source.Where(predicate) : source;
        }
    }

    public class ExpenseRepository : IExpenseRepository
    {
        private ICategoryRepository _categoryRepository;
        private List<Expense> _expenses;
        private int _nextId;
        public ExpenseRepository()
        {
            _categoryRepository = new CategoryRepository();
            _expenses = new List<Expense>();
            _nextId = 1;
            InitializeExpenseList();
        }

        public virtual IEnumerable<Expense> GetAll()
        {
            return _expenses.AsEnumerable();
        }

        public virtual long Insert(Expense entity)
        {
            entity.Id = _nextId;
            entity.Category = _categoryRepository.FirstOrDefault(entity.CategoryId);
            _expenses.Add(entity);
            _nextId++;
            return entity.Id;
        }

        public virtual void Delete(long id)
        {
            var entity = _expenses.FirstOrDefault(e => e.Id == id);
            if (entity != null)
            {
               _expenses.Remove(entity);
            }
        }

        public long Update(Expense entity)
        {
            Expense existingEntity = _expenses.FirstOrDefault(x => x.Id == entity.Id);
            if (existingEntity != null)
            {
                existingEntity.Date = entity.Date;
                existingEntity.Amount = entity.Amount;
                existingEntity.FirstName = entity.FirstName;
                existingEntity.LastName = entity.LastName;
                existingEntity.Description = entity.Description;
                existingEntity.CategoryId = entity.CategoryId;
                existingEntity.Category = _categoryRepository.FirstOrDefault(entity.CategoryId);
            }
            return entity.Id;
        }

        #region private 

        protected void InitializeExpenseList()
        {
            Insert(new Expense()
            {
                Date = new DateOnly(2023, 12, 14),
                Amount = 24.23m,
                FirstName = "Pamela",
                LastName = "Poor",
                Description = "Expense for shipping out letter.",
                CategoryId = 1,
                Category = _categoryRepository.FirstOrDefault(1),
            });
        }

        #endregion
    }
}
