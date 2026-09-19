using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Smart_Event_Managment_System.Data;
using Smart_Event_Managment_System.Models;

namespace Smart_Event_Managment_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenueController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VenueController()
        {
            _context = new AppDbContext();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var venues = _context.Venue.ToList();

            if (venues == null || venues.Count == 0)
            {
                return NotFound("No venues found.");
            }

            return Ok(venues);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var venue = _context.Venue.FirstOrDefault(v => v.VenueId == id);

            if (venue == null)
            {
                return NotFound("Venue not found.");
            }

            return Ok(venue);
        }

        [HttpPost]
        public IActionResult Create(Venue v)
        {
            if (v == null)
            {
                return BadRequest("Venue cannot be created.");
            }

            if (_context.Venue.Any(ve => ve.Name == v.Name))
            {
                return BadRequest("Venue name already exists.");
            }

            _context.Venue.Add(v);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = v.VenueId }, v);
        }
    }
}
