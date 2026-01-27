using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestWebAPI.Data;
using TestWebAPI.Entities;

namespace TestWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeesController(AppDbContext context)
        {
            _context = context;
        }


        // GET: api/employees
        [HttpGet]
        public IActionResult GetEmployees()
        {
            var employees = _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Role)
                .ToList();

            return Ok(employees);
        }

        // GET: api/employees/id
        [HttpGet("{id}")]
        public IActionResult GetEmployeeId(int id)
        {
            var employee = _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Role)
                .FirstOrDefault(e => e.Id == id);

            if (employee == null)
                return NotFound("Employee Topilmadi! (NULL qaytdi)");

            return Ok(employee);
        }

        // POST: api/employees
        [HttpPost]
        public IActionResult CreateEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();

            return Ok(employee);
        }

        // PUT: api/employees/id
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
                return BadRequest("Bunday Id dagi Employee topilmadi!");

            _context.Employees.Update(employee);
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/employees/id
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = _context.Employees.Find(id);

            if (employee == null)
                return NotFound("Topilmadi! (NULL qaytdi)");

            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
