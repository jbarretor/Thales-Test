using EmployeeService.Business;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController(IEmployeeBusiness employeeBusiness) : ControllerBase
    {
        private readonly IEmployeeBusiness _employeeBusiness = employeeBusiness;

        [HttpGet]
        public IActionResult GetEmployees()
        {
            try
            {
                var employees = _employeeBusiness.GetEmployeesAsync();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            try
            {
                var employee = _employeeBusiness.GetEmployeeByIdAsync(id);
                if (employee == null)
                {
                    return NotFound();
                }
                return Ok(employee);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
