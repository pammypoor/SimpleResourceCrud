namespace ExpenseReporter.Application.Dtos
{
    public class ExpenseListDto 
    {
        public long Id { get; set; }

        public string Date { get; set; }

        public decimal Amount { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Description { get; set; }

        public string CategoryName { get; set; }
    }
}
