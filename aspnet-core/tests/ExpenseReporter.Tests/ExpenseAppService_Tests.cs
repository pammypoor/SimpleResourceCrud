using ExpenseReporter.Application.Dtos;
using ExpenseReporter.Application.Services;
using Shouldly;

namespace ExpenseReporter.Tests
{
    
    public class ExpenseAppService_Tests
    {
        private readonly IExpenseAppService _expenseAppService;
        
        public ExpenseAppService_Tests()
        {
            _expenseAppService = new ExpenseAppService();
        }

        [Fact]
        public void Should_GetForEdit()
        {
            //Arrange
            var expense = new ExpenseCreateOrEditDto
            {
                Date = "1/11/2022",
                Amount = 33.12m,
                FirstName = "Adam",
                LastName = "Sandler",
                Description = "Postage stamps",
                CategoryId = 1,
            };
            expense.Id = _expenseAppService.Create(expense);

            //Act
            var result = _expenseAppService.GetForEdit(expense.Id);

            //Assert
            result.ShouldNotBeNull();
            result.Expense.ShouldNotBeNull();
            result.Expense.Id.ShouldBe(expense.Id);
            result.Expense.Date.ShouldBe(expense.Date);
            result.Expense.Amount.ShouldBe(expense.Amount);
            result.Expense.FirstName.ShouldBe(expense.FirstName);
            result.Expense.LastName.ShouldBe(expense.LastName);
            result.Expense.Description.ShouldBe(expense.Description);
            result.Expense.CategoryId.ShouldBe(expense.CategoryId);
        }

        [Fact]
        public void Should_GetForView()
        {
            //Arrange
            var expense = new ExpenseCreateOrEditDto
            {
                Date = "10/31/1998",
                Amount = 102.33m,
                FirstName = "Joe",
                LastName = "Shmoe",
                Description = "News article",
                CategoryId = 2,
            };
            expense.Id = _expenseAppService.Create(expense);

            //Act
            var result = _expenseAppService.GetForView(expense.Id);

            //Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(expense.Id);
            result.Date.ShouldBe(expense.Date);
            result.Amount.ShouldBe(expense.Amount);
            result.FirstName.ShouldBe(expense.FirstName);
            result.LastName.ShouldBe(expense.LastName);
            result.Description.ShouldBe(expense.Description);
            result.CategoryId.ShouldBe(expense.CategoryId);
        }

        [Fact]
        public void Should_Get_All()
        {
            //Arrange

            //Act
            IEnumerable<ExpenseListDto> results = _expenseAppService.GetAll(new ExpenseGetAllInput());

            //Assert
            results.Count().ShouldBe(1);
        }

        [Fact]
        public void Should_Create()
        {
            //Arrange
            var expense = new ExpenseCreateOrEditDto
            {
                Date = "9/2/2003",
                Amount = 10.33m,
                FirstName = "Pamela",
                LastName = "Poor",
                Description = "Envelopes",
                CategoryId = 1,
            };

            //Act
            var id = _expenseAppService.Create(expense);

            //Assert
            id.ShouldBeGreaterThan(1);
        }

        [Fact]
        public void Should_Update()
        {
            //Arrange
            var expense = new ExpenseCreateOrEditDto
            {
                Date = "5/2/2001",
                Amount = 20.22m,
                FirstName = "Pammy",
                LastName = "Poor",
                Description = "Ads",
                CategoryId = 2,
            };
            expense.Id = _expenseAppService.Create(expense);
            var updatedExpense = new ExpenseCreateOrEditDto
            {
                Id = expense.Id,
                Date = "8/2/2003",
                Amount = 9.21m,
                FirstName = "Berenice",
                LastName = "Orozco",
                Description = "Envelope glue",
                CategoryId = 1,
            };


            //Act
            var id = _expenseAppService.Update(expense);

            //Assert
            id.ShouldBe(expense.Id);
        }

        [Fact]
        public void Should_Delete()
        {
            var expense = new ExpenseCreateOrEditDto
            {
                Date = "5/2/2001",
                Amount = 20.22m,
                FirstName = "Pammy",
                LastName = "Poor",
                Description = "Ads",
                CategoryId = 2,
            };
            expense.Id = _expenseAppService.Create(expense);

            //Act
            _expenseAppService.Delete(expense.Id);
        }
    }
}
