using ExpenseReporter.Core.Consts;
using System.ComponentModel.DataAnnotations;

namespace ExpenseReporter.Application.Dtos
{
    public class ExpenseCreateOrEditDto
    {
        public virtual long Id { get; set; }

        [Required]
        public virtual string Date { get; set; }

        [Required]
        public virtual decimal Amount { get; set; }

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
    }
}
