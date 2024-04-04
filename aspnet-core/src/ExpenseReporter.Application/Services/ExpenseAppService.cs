using ExpenseReporter.Application.Dtos;
using ExpenseReporter.Application.Dtos.Expenses;
using ExpenseReporter.Core.Models;
using ExpenseReporter.Core.Repositories;

namespace ExpenseReporter.Application.Services
{
    public class ExpenseAppService : IExpenseAppService
    {
        private IExpenseRepository repository; 
        public ExpenseAppService() 
        {
            repository = new ExpenseRepository();
        }

        public IEnumerable<ExpenseListDto> GetAll(ExpenseGetAllInput input)
        {
            return repository.GetAll()
                .WhereIf(!string.IsNullOrEmpty(input.MaxDateFilter), x => x.Date >= DateOnly.Parse(input.MaxDateFilter))
                .WhereIf(!string.IsNullOrEmpty(input.MinDateFilter), x => x.Date <= DateOnly.Parse(input.MinDateFilter))
                .WhereIf(!string.IsNullOrEmpty(input.FirstNameFilter), x => x.FirstName == input.FirstNameFilter)
                .WhereIf(!string.IsNullOrEmpty(input.LastNameFilter), x => x.LastName == input.LastNameFilter)
                .WhereIf(!string.IsNullOrEmpty(input.DescriptionFilter), x => x.Description == input.DescriptionFilter)
                .WhereIf(!string.IsNullOrEmpty(input.CategoryNameFilter), x => x.Category.Name == input.CategoryNameFilter)
                .Select(x => new ExpenseListDto
                {
                    Id = x.Id,
                    Date = x.Date.ToShortDateString(),
                    Amount = x.Amount,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Description = x.Description,
                    CategoryName = x.Category.Name,
                });
        }

        public long Create(ExpenseCreateOrEditDto input)
        {
            return repository.Insert(Map(input));
        }

        public long Update(ExpenseCreateOrEditDto input)
        {
            return repository.Update(Map(input));
        }

        public void Delete(long id)
        {
            repository.Delete(id);
        }

        public ExpenseGetForEditDto GetForEdit(long id)
        {
            return repository.GetAll().Where(x => x.Id == id)
                .Select(x => new ExpenseGetForEditDto
                {
                    Expense = new ExpenseCreateOrEditDto
                    {
                        Id = x.Id,
                        Date = x.Date.ToShortDateString(),
                        Amount = x.Amount,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Description = x.Description,
                        CategoryId = x.CategoryId,
                    },
                    CategoryName = x.Category.Name,
                }).FirstOrDefault();
        }

        public ExpenseGetForViewDto GetForView(long id)
        {
            return repository.GetAll().Where(x => x.Id == id)
                .Select(x => new ExpenseGetForViewDto
                {
                    Id = x.Id,
                    Date = x.Date.ToShortDateString(),
                    Amount = x.Amount,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Description = x.Description,
                    CategoryId = x.CategoryId,
                    CategoryName = x.Category.Name,
                }).FirstOrDefault();
        }

        #region private 

        public Expense Map(ExpenseCreateOrEditDto dto)
        {
            return new Expense
            {
                Id = dto.Id,
                Date = DateOnly.Parse(dto.Date),
                Amount = dto.Amount,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Description = dto.Description,
                CategoryId = dto.CategoryId,
            };
        }
        #endregion
    }
}
