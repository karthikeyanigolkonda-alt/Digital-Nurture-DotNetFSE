using EmployeeManagementAPI.Models;
using EmployeeManagementAPI.Services;
using EmployeeManagementAPI.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.Controllers;

[Route("api/employee")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<EmployeeDto>> GetAll()
    {
        try
        {
            var items = _employeeService.GetAll()
                .Select(e => new EmployeeDto
                {
                    Id = e.Id,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Email = e.Email,
                    Department = e.Department
                });

            return Ok(items);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred.");
        }
    }

    [HttpGet("{id:int}")]
    public ActionResult<EmployeeDto> GetById(int id)
    {
        try
        {
            var e = _employeeService.GetById(id);
            if (e is null) return NotFound();

            var dto = new EmployeeDto
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                Department = e.Department
            };

            return Ok(dto);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred.");
        }
    }

    [HttpPost]
    public ActionResult<EmployeeDto> Create([FromBody] CreateEmployeeDto createDto)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var employee = new Employee
            {
                FirstName = createDto.FirstName,
                LastName = createDto.LastName,
                Email = createDto.Email,
                Department = createDto.Department
            };

            var created = _employeeService.Create(employee);

            var dto = new EmployeeDto
            {
                Id = created.Id,
                FirstName = created.FirstName,
                LastName = created.LastName,
                Email = created.Email,
                Department = created.Department
            };

            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred.");
        }
    }

    [HttpPut("{id:int}")]
    public ActionResult<EmployeeDto> Update(int id, [FromBody] UpdateEmployeeDto updateDto)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var employee = new Employee
            {
                FirstName = updateDto.FirstName,
                LastName = updateDto.LastName,
                Email = updateDto.Email,
                Department = updateDto.Department
            };

            var updated = _employeeService.Update(id, employee);
            if (updated is null) return NotFound();

            var dto = new EmployeeDto
            {
                Id = updated.Id,
                FirstName = updated.FirstName,
                LastName = updated.LastName,
                Email = updated.Email,
                Department = updated.Department
            };

            return Ok(dto);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred.");
        }
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        try
        {
            var deleted = _employeeService.Delete(id);
            return deleted ? NoContent() : NotFound();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred.");
        }
    }
}
