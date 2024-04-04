using ExpenseReporter.Application.Dtos;
using ExpenseReporter.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseReporter.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseAppService _expenseAppService;
        private readonly ILogger<ExpenseController> _logger;
        
        public ExpenseController(ILogger<ExpenseController> logger, IExpenseAppService expenseAppService)
        {
            _logger = logger;
            _expenseAppService = expenseAppService;
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery]ExpenseGetAllInput input)
        {
            return Ok(_expenseAppService.GetAll(input));
        }

        [HttpGet]

        [Route("getForEdit/{id}")]
        public IActionResult GetForEdit([FromRoute] long id)
        {
            return Ok(_expenseAppService.GetForEdit(id));
        }

        [HttpGet]

        [Route("getForView/{id}")]
        public IActionResult GetForView([FromRoute] long id)
        {
            return Ok(_expenseAppService.GetForView(id));
        }

        [HttpPost]
        public IActionResult Create(ExpenseCreateOrEditDto input)
        {
            return Ok(_expenseAppService.Create(input));
        }

        [HttpPut]
        public IActionResult Update(ExpenseCreateOrEditDto input)
        {
            return Ok(_expenseAppService.Update(input));
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] long id)
        {
            _expenseAppService.Delete(id);
            return Ok();
        }
    }
}
