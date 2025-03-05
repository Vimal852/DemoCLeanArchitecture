using ApplicationLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using InfrastructureLayer;
using DomainLayer.Entities;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        public readonly IEmployee _employeeService;

        public EmployeeController (IEmployee employeeService)
        {
            this._employeeService = employeeService;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var employees = await _employeeService.Getasync();

            if(employees == null || !employees.Any())
            {
                return NotFound("No employees found.");
            }

            return Ok(employees);
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _employeeService.Getbyidasync(id);
            if (employee == null)
                return NotFound($"Employee with ID {id} not found.");

            return Ok(employee);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<IActionResult> Addemp([FromBody] Employee employee)
        {
            if (employee == null)
                return BadRequest("Invalid employee data.");

            var createdEmployee = await _employeeService.Addasync(employee);
            return Ok(createdEmployee);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]

        public async Task<IActionResult> Updateemp(int id, [FromBody] Employee employee)
        {
            if (employee == null || id != employee.Id)
                return BadRequest("Invalid employee data.");

            var existingEmployee = await _employeeService.Getbyidasync(id);
            if (existingEmployee == null)
                return NotFound($"Employee with ID {id} not found.");

            await _employeeService.Updateasync(employee);
            return NoContent(); // 204 - Updated successfully
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteemp(int id)
        {
            var employee = await _employeeService.Deleteasync(id);
            if (employee == null)
                return NotFound($"Employee with ID {id} not found.");

            await _employeeService.Deleteasync(id);
            return NoContent(); // 204 - Deleted successfully
        }
    }
}
