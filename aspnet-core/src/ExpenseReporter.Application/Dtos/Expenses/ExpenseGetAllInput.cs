namespace ExpenseReporter.Application.Dtos
{
    public class ExpenseGetAllInput
    {
        public string? MaxDateFilter { get; set; }

        public string? MinDateFilter { get; set; }

        public string? FirstNameFilter { get; set; }

        public string? LastNameFilter { get; set; }

        public string? DescriptionFilter { get; set; }

        public string? CategoryNameFilter { get; set; }
    }
}
