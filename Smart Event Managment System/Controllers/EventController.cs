using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smart_Event_Managment_System.Data;
using Smart_Event_Managment_System.Models;

namespace Smart_Event_Managment_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly AppDbContext _context;
        public EventController()
        {
            _context = new AppDbContext();
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var ev = _context.Events.Include(e => e.Registries).ToList();
            if (ev == null || ev.Count == 0)
            {
                return NotFound("not event found");
            }

            return Ok(ev);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var ev = _context.Events.Include(e => e.Registries).FirstOrDefault(e => e.EventId == id);
            if (ev == null)
            {
                return NotFound("not event found");
            }

            return Ok(ev);
        }
        [HttpPost]
        public IActionResult Create(Event e)
        {
            if (e == null)
            {
                return BadRequest("event cannot be creted");
            }
            _context.Events.Add(e);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = e.EventId }, e);

        }


        [HttpPut("{id}")]
        public IActionResult Update(Event e, int id)
        {

            var eve = _context.Events.FirstOrDefault(e => e.EventId == id);
            if (eve == null)
            {
                return NotFound("Event not found.");

            }

            eve.Title = e.Title;
            eve.Description = e.Description;
            eve.EventDate = e.EventDate;
            eve.Category = e.Category;
            eve.Capacity = e.Capacity;
            eve.StartTime = e.StartTime;
            eve.EndTime = e.EndTime;

            _context.SaveChanges();

            return Ok(eve);
        }

        [HttpPatch("{id}")]

        public IActionResult PartUpdateCategory(string category, int id)
        {

            var eve = _context.Events.FirstOrDefault(e => e.EventId == id);
            if (eve == null)
            {
                return NotFound("Event not found.");

            }

            eve.Category = category;
            _context.SaveChanges();
            return Ok(eve);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEvent(int id)
        {
            var eve = _context.Events.FirstOrDefault(e => e.EventId == id);
            if (eve == null)
            {
                return NotFound("Event not found.");
            }

            var HasRegistrations = _context.Registration.Any(a => a.EventId == id);
            if (HasRegistrations)
            {
                return Conflict("Cannot delete event with existing registrations.");
            }
            _context.Events.Remove(eve);
            _context.SaveChanges();
            return NoContent();

        }



    }
}
