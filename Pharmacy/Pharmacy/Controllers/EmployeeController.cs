
using AutoMapper;
using Pharmacy.BL.Interfaces;
using Pharmacy.Models.DTO;
using Pharmacy.Models.Requests;
using Pharmacy.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Pharmacy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]

        public IActionResult GetAll()
        {
            var result = _employeeService.GetAll();

            return Ok(result);
        }

        [HttpGet("GetById")]

        public IActionResult GetById(int id)
        {
            if (id <= 0) return BadRequest();

            var result = _employeeService.GetById(id);

            if (result == null) return NotFound(id);

            var response = _mapper.Map<EmployeeResponse>(result);

            return Ok(response);
        }

        [HttpPost("Create")]

        public IActionResult CreateEmployee([FromBody] EmployeeRequests employeeRequests)
        {
            if (employeeRequests == null) return BadRequest();

            var employee = _mapper.Map<Employee>(employeeRequests);

            var result = _employeeService.Create(employee);

            return Ok(result);

        }

        [HttpDelete]

        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest(id);

            var result = _employeeService.Delete(id);

            if (result == null) return NotFound(id);

            return Ok(result);
        }

        [HttpPost("Update")]

        public IActionResult Update([FromBody] EmployeeUpdateRequests employeeRequests)
        {
            if (employeeRequests == null) return BadRequest();

            var searchEmployee = _employeeService.GetById(employeeRequests.Id);

            if (searchEmployee == null) return NotFound(employeeRequests.Id);

            searchEmployee.Name = employeeRequests.Name;

            searchEmployee.Salary = employeeRequests.Salary;

            var result = _employeeService.Update(searchEmployee);

            return Ok(result);
        }
    }
}
