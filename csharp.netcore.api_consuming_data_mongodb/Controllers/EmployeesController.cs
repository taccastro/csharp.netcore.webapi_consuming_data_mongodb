using csharp.netcore.api_consuming_data_mongodb.Models;
using csharp.netcore.api_consuming_data_mongodb.Services;
using Microsoft.AspNetCore.Mvc;

namespace csharp.netcore.api_consuming_data_mongodb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : Controller
    {
        private readonly EmployeeService _employeeService;

        public EmployeesController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public ActionResult<List<Employee>> Get() =>
            _employeeService.Get();

        [HttpGet("{id:length(24)}", Name = "GetEmployee")]
        public ActionResult<Employee> Get(string id)
        {
            var emp = _employeeService.Get(id);

            if (emp == null)
            {
                return NotFound();
            }

            return emp;
        }
    }
}
