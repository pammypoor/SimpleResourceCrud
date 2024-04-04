using ExpenseReporter.Core.Consts;
using System.ComponentModel.DataAnnotations;

namespace ExpenseReporter.Core.Models
{
    public class Category
    {
        public long Id { get; set; }

        [Required]
        [StringLength(CategoryConsts.MaxNameLength)]
        public string Name { get; set; }
    }
}
