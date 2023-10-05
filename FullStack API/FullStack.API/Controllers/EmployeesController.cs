using FullStack.API.Data;
using FullStack.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FullStack.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : Controller
{
	private readonly FullStackDbContext _fullStackDbContext;
	public EmployeesController(FullStackDbContext fullStackDbContext)
	{
		_fullStackDbContext = fullStackDbContext;
	}

	[HttpGet]
	public async Task<IActionResult> GetAllEmployees()
	{
		var employees  = await _fullStackDbContext.Employees.ToListAsync();
		return Ok(employees);
	}

	[HttpPost]
	/*
	Атрибут FromBody указывает, что параметр метода контроллера 
	должен быть извлечен из данных тела http-запроса и затем десериализован 
	с помощью форматтера входных данных (input formatter). 
	По умолчанию имеется только форматтер JSON.
	*/
	public async Task<IActionResult> AddEmployee([FromBody] Employee employeeRequest)
	{
		//Guid - структура 128-бит вида "0f8fad5b-d9cb-469f-a165-70867728950e" для Id
		employeeRequest.Id = Guid.NewGuid();
		await _fullStackDbContext.Employees.AddAsync(employeeRequest);
		await _fullStackDbContext.SaveChangesAsync();

		return Ok(employeeRequest);
	}

	[HttpGet]
	[Route("{id:Guid}")]
	public async Task<IActionResult> GetEmployee(Guid id)
	{
		var employee = 
			await _fullStackDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);

		if (employee == null)
		{
			return NotFound();
		}

		return Ok(employee);
	}

	[HttpPut]
	[Route("{id:Guid}")]
	public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id, Employee updateEmployeeRequest)
	{
		var employee = await _fullStackDbContext.Employees.FindAsync(id);
		
		if (employee == null)
		{
			return NotFound();
		}

		employee.Name = updateEmployeeRequest.Name;
		employee.Email = updateEmployeeRequest.Email;
		employee.Salary = updateEmployeeRequest.Salary;
		employee.Phone = updateEmployeeRequest.Phone;
		employee.Department = updateEmployeeRequest.Department;

		await _fullStackDbContext.SaveChangesAsync();

		return Ok(employee);
	}

	[HttpDelete]
	[Route("{id:Guid}")]
	public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
	{ 
		var employee = await _fullStackDbContext.Employees.FindAsync(id);
		
		if (employee == null)
		{
			return NotFound();
		}

		_fullStackDbContext.Employees.Remove(employee);
		await _fullStackDbContext.SaveChangesAsync();
		return Ok(employee);
	}
}
