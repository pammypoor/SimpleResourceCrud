namespace ExpenseReporter.Application.Dtos.Expenses
{
    public class ExpenseGetForEditDto
    {
        public ExpenseCreateOrEditDto Expense { get; set; }

        public string CategoryName { get; set; }
    }
}
