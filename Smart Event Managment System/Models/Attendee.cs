using System.ComponentModel.DataAnnotations;

namespace Smart_Event_Managment_System.Models
{
    public class Attendee
    {
        public int AttendeeId { get; set; }

        [Required]
        [StringLength(99)]
        public string FullName { get; set; }

        [Required]
        [StringLength(149)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }
        //has many regi
        public ICollection<Registration> Registrations { get; set; } = new List<Registration>();
    }
}
