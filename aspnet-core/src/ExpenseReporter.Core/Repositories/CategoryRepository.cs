using ExpenseReporter.Core.Models;

namespace ExpenseReporter.Core.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private List<Category> _categories;
        public CategoryRepository() 
        {
            _categories = InitializeCategoryList();
        }
        public IEnumerable<Category> GetAll()
        {
            return _categories.AsEnumerable();
        }

        public Category FirstOrDefault(long id)
        {
            return _categories.Where(x => x.Id == id).FirstOrDefault();
        }

        #region private 

        protected List<Category> InitializeCategoryList()
        {
            return new List<Category>()
            {
                new Category()
                {
                    Id = 1,
                    Name = "Postage",
                },
                new Category()
                {
                    Id = 2,
                    Name = "Advertisement",
                },
                new Category()
                {
                    Id = 3,
                    Name="Office Supplies",
                },
                new Category()
                {
                    Id = 4,
                    Name = "Furniture",
                },
            };
        }



        #endregion
    }


}
