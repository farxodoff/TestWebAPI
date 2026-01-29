using Microsoft.AspNetCore.Mvc;
using TestWebAPI.Data;
using TestWebAPI.Entities;

namespace TestWebAPI.Controllers
{
    [ApiController]
    [Route("api/role")]
    public class RolesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RolesController(AppDbContext context)
        {
            _context = context;
        }



        // GET: api/roles
        [HttpGet]
        public IActionResult GetRoles()
        {
            var roles = _context.Roles.ToList();

            return Ok(roles);
        }

        // GET: api/roles/id
        [HttpGet("{id}")]
        public IActionResult GetByIdRole(int id)
        {
            var role = _context.Roles
                .FirstOrDefault(e => e.Id == id);

            if (role == null)
                return NotFound("Employee Topilmadi! (NULL qaytdi)");

            return Ok(role);
        }


        // POST: api/roles
        [HttpPost]
        public IActionResult CreateRole(Role role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();

            return Ok(role);
        }
    }
}
