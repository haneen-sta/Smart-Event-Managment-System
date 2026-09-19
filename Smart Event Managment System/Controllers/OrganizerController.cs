using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smart_Event_Managment_System.Data;
using Smart_Event_Managment_System.Models;

namespace Smart_Event_Managment_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizerController : ControllerBase
    {
        private readonly AppDbContext _context;
        public OrganizerController()
        {
            _context = new AppDbContext();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var or = _context.Organizer.ToList();
            if (or == null || or.Count == 0)
            {
                return NotFound("not event found");
            }

            return Ok(or);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var or = _context.Organizer.FirstOrDefault(e => e.OrganizerId == id);
            if (or == null)
            {
                return NotFound("not event found");
            }

            return Ok(or);
        }

        [HttpPost]
        public IActionResult Create(Organizer o)
        {
            if (o == null)
            {
                return BadRequest("event cannot be creted");
            }
            if (_context.Organizer.Any(or => or.Email == o.Email))
            {
                return BadRequest("Email already exists.");
            }
            _context.Organizer.Add(o);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = o.OrganizerId }, o);

        }
    }
}
