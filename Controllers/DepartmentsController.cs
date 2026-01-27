using System;
using Microsoft.AspNetCore.Mvc;
using TestWebAPI.Data;
using TestWebAPI.Entities;

namespace TestWebAPI.Controllers
{
    [ApiController]
    [Route("api/department")]
    public class DepartmentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DepartmentsController(AppDbContext context)
        {
            _context = context;
        }


        // GET: api/departments
        [HttpGet]
        public IActionResult GetDepartments()
        {
            var departments = _context.Departments.ToList();
            return Ok(departments);
        }

        // POST: api/departments
        [HttpPost]
        public IActionResult CreateDepartment(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();

            return Ok(department);
        }
    }
}
