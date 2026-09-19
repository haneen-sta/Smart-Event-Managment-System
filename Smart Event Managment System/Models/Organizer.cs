using System.ComponentModel.DataAnnotations;

namespace Smart_Event_Managment_System.Models
{
    public class Organizer
    {
        public int OrganizerId { get; set; }

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

         //organizer has many events
        public ICollection<Event>Events { get; set; } = new List<Event>();



    }
}
