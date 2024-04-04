namespace ExpenseReporter.Application.Dtos.Expenses
{
    public class ExpenseGetForViewDto
    {
        public virtual long Id { get; set; }

        public virtual string Date { get; set; }

        public virtual decimal Amount { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Description { get; set; }

        public long CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}
