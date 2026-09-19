using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Smart_Event_Managment_System.Data;
using Smart_Event_Managment_System.Models;

namespace Smart_Event_Managment_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrtionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RegistrtionController()
        {
            _context = new AppDbContext();
        }
        [HttpPost]
        public IActionResult Create(Registration re)
        {
            if (re == null)
            {
                return BadRequest("Registration cannot be created.");
            }
            var eve=_context.Events.FirstOrDefault(ev=>ev.EventId == re.EventId);
            if (eve == null)
            {
                return BadRequest("Event Not Found.");
            }

            var att=_context.Attendee.FirstOrDefault(at=>at.AttendeeId == at.AttendeeId);
            if (att == null)
            {
                return BadRequest("attendee Not Found.");
            }
            _context.Registration.Add(re);
            _context.SaveChanges();

            return Ok(re);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var registrations = _context.Registration.ToList();

            if (registrations == null || registrations.Count == 0)
            {
                return NotFound("No registrations found.");
            }

            return Ok(registrations);
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateStatus(string status, int id)
        {
            var registration = _context.Registration.FirstOrDefault(r => r.RegistrationId == id);

            if (registration == null)
            {
                return NotFound("Registration not found.");
            }

            registration.Status = status;

            _context.SaveChanges();

            return Ok(registration);
        }



    }
}
