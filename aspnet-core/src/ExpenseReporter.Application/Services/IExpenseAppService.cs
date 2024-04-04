using ExpenseReporter.Application.Dtos;
using ExpenseReporter.Application.Dtos.Expenses;

namespace ExpenseReporter.Application.Services
{
    public interface IExpenseAppService
    {
        IEnumerable<ExpenseListDto> GetAll(ExpenseGetAllInput input);

        long Create(ExpenseCreateOrEditDto input);

        long Update(ExpenseCreateOrEditDto input);

        void Delete(long id);

        ExpenseGetForEditDto GetForEdit(long id);

        ExpenseGetForViewDto GetForView(long id);
    }
}
