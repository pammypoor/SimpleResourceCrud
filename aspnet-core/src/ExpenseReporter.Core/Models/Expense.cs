using ExpenseReporter.Core.Consts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseReporter.Core.Models
{
    public class Expense
    {
        public long Id { get; set; }

        public DateOnly Date { get; set; }

        public decimal Amount { get; set; }

        [Required]
        [StringLength(ExpenseConsts.MaxFirstNameLength)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(ExpenseConsts.MaxLastNameLength)]
        public string LastName { get; set; }

        [Required]
        [StringLength(ExpenseConsts.MaxDescriptionLength)]
        public string Description { get; set; }

        [Required]
        public long CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
